using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ProjetoFinal
{
    public partial class Frm_MainMenu : Form
    {

        // Variáveis para o movimento do formulário
        private bool isDragging = false;
        private Point lastCursor;
        private Point lastForm;

        private string loggedInUsername;
        public Frm_MainMenu(string loggedInUsername)
        {
            InitializeComponent();
            this.loggedInUsername = loggedInUsername;
            DisplayUsername();
            
            hc_network.LogoutClicked += HeaderControl_LogoutClicked;
            hc_system.LogoutClicked += HeaderControl_LogoutClicked;
            hc_security.LogoutClicked += HeaderControl_LogoutClicked;
            hc_maintenance.LogoutClicked += HeaderControl_LogoutClicked;
        }

        private void DisplayUsername()
        {
            string formattedUsername = "ACCESS: " + this.loggedInUsername.ToUpper();

            hc_network.UsernameText = formattedUsername;
            hc_system.UsernameText = formattedUsername;
            hc_security.UsernameText = formattedUsername;
            hc_maintenance.UsernameText = formattedUsername;
        }
        private void btn_ipconfiguration_Click(object sender, EventArgs e)
        {
            // 1. Limpa a área de output antes de mostrar o novo resultado
            txt_output_network.Text = "";

            // 2. Constrói a string de saída usando StringBuilder (mais eficiente)
            StringBuilder output = new StringBuilder();
            output.AppendLine("::: NETWORK CONFIGURATION REPORT :::");
            output.AppendLine("------------------------------------");

            // 3. Obtém todas as interfaces de rede no teu computador
            NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface adapter in networkInterfaces)
            {
                // Ignora interfaces que não estão ativas ou não são relevantes
                if (adapter.OperationalStatus != OperationalStatus.Up)
                    continue;

                output.AppendLine($"\n[INTERFACE] {adapter.Name}");
                output.AppendLine($"  Description: {adapter.Description}");
                output.AppendLine($"  Type: {adapter.NetworkInterfaceType}");
                output.AppendLine($"  Status: {adapter.OperationalStatus}");
                output.AppendLine($"  MAC Address: {adapter.GetPhysicalAddress().ToString()}");

                // Obtém as configurações de IP e DNS
                IPInterfaceProperties properties = adapter.GetIPProperties();

                // Itera sobre os endereços IP (IPv4 e IPv6)
                foreach (UnicastIPAddressInformation ip in properties.UnicastAddresses)
                {
                    if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork) // Apenas IPv4
                    {
                        output.AppendLine($"  IPv4 Address: {ip.Address}");
                        output.AppendLine($"  Subnet Mask:  {ip.IPv4Mask}");
                    }
                }

                // Exibe os Gateways (portas de ligação)
                foreach (GatewayIPAddressInformation gateway in properties.GatewayAddresses)
                {
                    output.AppendLine($"  Default Gateway: {gateway.Address}");
                }

                // Exibe os servidores DNS
                foreach (System.Net.IPAddress dns in properties.DnsAddresses)
                {
                    output.AppendLine($"  DNS Server: {dns}");
                }
                output.AppendLine("------------------------------------");
            }

            // 4. Atribui o texto construído à tua caixa de output
            txt_output_network.Text = output.ToString();

            // 5. Rola para o topo (opcional, para garantir que o utilizador vê o início)
            txt_output_network.SelectionStart = 0;
            txt_output_network.ScrollToCaret();
        }

        private void btn_ping_Click(object sender, EventArgs e)
        {
            string target = txt_targetHost.Text.Trim();
            if (string.IsNullOrWhiteSpace(target))
            {
                txt_output_network.Text = "ERROR: Target Host/IP is required.\r\n";
                System.Media.SystemSounds.Hand.Play();
                return;
            }

            txt_output_network.Text = $"Pinging {target}...\r\n";
            txt_output_network.AppendText("--------------------------------------------------\r\n");

            Ping pingSender = new Ping();
            List<long> roundtripTimes = new List<long>();
            int sent = 4;
            int received = 0;
            int timeoutMs = 4000;

            // Simula a repetição de 4 pacotes, como o CMD
            for (int i = 0; i < sent; i++)
            {
                try
                {
                    PingReply reply = pingSender.Send(target, timeoutMs);

                    if (reply.Status == IPStatus.Success)
                    {
                        // 1. Output para cada pacote
                        txt_output_network.AppendText($"Reply from {reply.Address}: time={reply.RoundtripTime}ms\r\n");
                        roundtripTimes.Add(reply.RoundtripTime);
                        received++;
                    }
                    else
                    {
                        // 1. Output para falha
                        txt_output_network.AppendText($"Request timed out or failed. Status: {reply.Status}\r\n");
                    }
                }
                catch (Exception ex)
                {
                    // Captura erros de DNS ou rede
                    txt_output_network.AppendText($"Error during ping to {target}: {ex.Message}\r\n");
                    // Se falhar, não adianta continuar a enviar
                    break;
                }
            }

            // --------------------------------------------------
            // 2. Apresentar as Estatísticas e o Sumário (Estilo CMD)
            // --------------------------------------------------
            txt_output_network.AppendText("\r\n--- PING STATISTICS ---\r\n");

            // Cálculo de Perda
            int lost = sent - received;
            double lossPercentage = (double)lost / sent * 100;

            // Sumário de Pacotes
            txt_output_network.AppendText($"Packets: Sent = {sent}, Received = {received}, Lost = {lost} ({lossPercentage:F0}% loss)\r\n");

            // Tempos de Viagem
            if (received > 0)
            {
                long minTime = roundtripTimes.Min();
                long maxTime = roundtripTimes.Max();
                long avgTime = (long)roundtripTimes.Average();

                txt_output_network.AppendText("\r\nApproximate round trip times in milli-seconds:\r\n");
                txt_output_network.AppendText($" Minimum = {minTime}ms, Maximum = {maxTime}ms, Average = {avgTime}ms\r\n");
            }

            txt_output_network.AppendText("--------------------------------------------------");

        }

        private void btn_active_ports_Click(object sender, EventArgs e)
        {
            txt_output_network.Text = "::: ACTIVE NETWORK CONNECTIONS :::\r\n";
            txt_output_network.AppendText("--------------------------------------------------\r\n");

            try
            {
                // Obtém as propriedades do IP Global
                IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();

                // Obtém todas as ligações TCP ativas
                TcpConnectionInformation[] tcpConnections = properties.GetActiveTcpConnections();

                // Construtor de texto
                StringBuilder output = new StringBuilder();
                output.AppendLine($"Total TCP Connections: {tcpConnections.Length}\r\n");
                output.AppendLine($"{"PROTOCOL",-8} {"LOCAL ADDRESS",-25} {"REMOTE ADDRESS",-25} {"STATE",-15}");
                output.AppendLine($"{"--------",-8} {"---------------",-25} {"----------------",-25} {"-----",-15}");

                foreach (TcpConnectionInformation info in tcpConnections)
                {
                    // Formata a linha de output para parecer um terminal
                    string local = $"{info.LocalEndPoint.Address}:{info.LocalEndPoint.Port}";
                    string remote = $"{info.RemoteEndPoint.Address}:{info.RemoteEndPoint.Port}";

                    output.AppendLine($"{"TCP",-8} {local,-25} {remote,-25} {info.State,-15}");
                }

                txt_output_network.AppendText(output.ToString());
                txt_output_network.AppendText("\r\n--------------------------------------------------");

                txt_output_network.SelectionStart = 0;
                txt_output_network.ScrollToCaret();

            }
            catch (Exception ex)
            {
                txt_output_network.Text = "ERROR: Could not retrieve connection data.\r\n";
                txt_output_network.AppendText($"DETAILS: {ex.Message}");
                System.Media.SystemSounds.Hand.Play();
            }
        }

        private void HeaderControl_LogoutClicked(object sender, EventArgs e)
        {
            // Lógica para fechar o formulário principal e abrir o de login

            // 1. Cria uma nova instância do formulário de Login
            Frm_login frm_Login = new Frm_login();

            // 2. Mostra o formulário de Login
            frm_Login.Show();

            // 3. FECHA ESTE FORMULÁRIO (o MainMenu)
            this.Close();
        }

        private void LoadSystemInfo()
        {
            // Limpar o Output antes de carregar nova informação
            txt_output_system.Text = "::: SYSTEM INFORMATION SCAN :::\r\n";
            txt_output_system.AppendText("-------------------------------------\r\n");

            try
            {
                // 1. Informação do Sistema Operativo
                txt_output_system.AppendText($"[OS] Version: {Environment.OSVersion.VersionString}\r\n");
                txt_output_system.AppendText($"[OS] Machine Name: {Environment.MachineName}\r\n");
                txt_output_system.AppendText($"[OS] 64-bit OS: {Environment.Is64BitOperatingSystem}\r\n");
                txt_output_system.AppendText($"[OS] User Domain: {Environment.UserDomainName}\r\n");

                // 2. Informação do Processador
                txt_output_system.AppendText("\r\n--- PROCESSOR INFO ---\r\n");
                txt_output_system.AppendText($"[CPU] Cores/Threads: {Environment.ProcessorCount}\r\n");

                // 3. Informação da Memória (RAM)
                // Usa o método auxiliar que criámos anteriormente
                long totalRamBytes = GetTotalPhysicalMemory();
                txt_output_system.AppendText($"[RAM] Total Physical Memory: {(totalRamBytes / 1024 / 1024):N0} MB\r\n");

                // 4. Outras Configurações
                txt_output_system.AppendText("\r\n--- CONFIGURATION ---\r\n");
                txt_output_system.AppendText($"[FS] Current Directory: {Environment.CurrentDirectory}\r\n");
                txt_output_system.AppendText($"[FS] System Directory: {Environment.SystemDirectory}\r\n");

            }
            catch (Exception ex)
            {
                txt_output_system.AppendText($"SYSTEM ERROR: Could not retrieve core system info.\r\nDetails: {ex.Message}");
            }

            txt_output_system.AppendText("-------------------------------------\r\n");
        }

        private long GetTotalPhysicalMemory()
        {
            // Usa WMI para obter a memória física total em bytes
            ObjectQuery wmiQuery = new ObjectQuery("SELECT TotalVisibleMemorySize FROM Win32_OperatingSystem");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(wmiQuery);
            ManagementObjectCollection results = searcher.Get();

            long totalMemory = 0;
            foreach (ManagementObject result in results)
            {
                // O valor vem em KiloBytes, convertemos para Bytes
                totalMemory = Convert.ToInt64(result["TotalVisibleMemorySize"]) * 1024;
            }
            return totalMemory;
        }

        private void btn_scan_system_Click(object sender, EventArgs e)
        {
            LoadSystemInfo();
        }

        private void btn_check_health_Click(object sender, EventArgs e)
        {

            txt_output_system.Text = "::: SYSTEM HEALTH REPORT :::\r\n";
            txt_output_system.AppendText("-------------------------------------\r\n");

            try
            {
                // 1. Obter Uso da CPU em Tempo Real
                // PerformanceCounter é a classe padrão do Windows para este fim
                PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
                cpuCounter.NextValue(); // Primeira leitura é sempre 0, precisamos de uma pausa.

                // Esperar 500ms para obter um valor real e representativo
                System.Threading.Thread.Sleep(500);
                float cpuUsage = cpuCounter.NextValue();

                // 2. Obter Informação da Memória
                PerformanceCounter ramCounter = new PerformanceCounter("Memory", "Available MBytes");
                float availableRam = ramCounter.NextValue();

                // Calcular RAM usada usando o método auxiliar
                long totalRam = GetTotalPhysicalMemory();
                long usedRam = totalRam - (long)(availableRam * 1024 * 1024); // Converte MB disponíveis para bytes e subtrai

                // 3. Exibir no Output com formatação ciber
                txt_output_system.AppendText($"[CPU LOAD] {cpuUsage:F2}%\r\n");
                txt_output_system.AppendText($"[RAM USED] {(usedRam / 1024 / 1024):N0} MB\r\n"); // :N0 para formatar o número
                txt_output_system.AppendText($"[RAM FREE] {availableRam:N0} MB\r\n");
                txt_output_system.AppendText($"[RAM TOTAL] {(totalRam / 1024 / 1024):N0} MB\r\n");

            }
            catch (Exception ex)
            {
                txt_output_system.Text = $"SYSTEM ERROR: Could not retrieve system metrics.\r\nDetails: {ex.Message}";
                System.Media.SystemSounds.Hand.Play();
            }

            txt_output_system.AppendText("-------------------------------------");

        }

        private void btn_view_processes_Click(object sender, EventArgs e)
        {
            txt_output_system.Text = "::: ACTIVE PROCESSES LIST :::\r\n";
            txt_output_system.AppendText("--------------------------------------------------\r\n");

            try
            {
                // Obtém todos os processos em execução no sistema
                Process[] allProcesses = Process.GetProcesses();

                // Construtor de texto para formatar o output
                StringBuilder output = new StringBuilder();

                // Cabeçalhos de coluna: usar um espaçamento fixo para o alinhamento de terminal
                output.AppendLine($"{"PID",-8} {"CPU TIME",-10} {"MEMORY (MB)",-15} {"PROCESS NAME"}");
                output.AppendLine($"{"---",-8} {"--------",-10} {"-----------",-15} {"------------"}");

                // Itera sobre todos os processos
                foreach (Process p in allProcesses)
                {
                    try
                    {
                        // Calcula o tempo total de CPU e a memória usada
                        // Nota: p.TotalProcessorTime pode lançar exceções para alguns processos do sistema
                        TimeSpan cpuTime = p.TotalProcessorTime;

                        // WorkingSet64 é a memória física em uso pelo processo (em bytes)
                        long memoryUsageMB = p.WorkingSet64 / (1024 * 1024);

                        // Formata a linha de output
                        output.AppendLine(
                            $"{p.Id,-8} " +
                            $"{cpuTime.TotalSeconds,-10:F2} " + // Tempo total de CPU em segundos (2 casas decimais)
                            $"{memoryUsageMB,-15:N0} " + // Memória em MB (sem casas decimais)
                            $"{p.ProcessName}"
                        );
                    }
                    catch (Exception)
                    {
                        // Ignora processos para os quais não temos acesso ou que falham a leitura
                        output.AppendLine($"{p.Id,-8} {"N/A",-10} {"N/A",-15} {p.ProcessName} (Access Denied)");
                    }
                }

                txt_output_system.AppendText(output.ToString());
                txt_output_system.AppendText("\r\n--------------------------------------------------");
                txt_output_system.AppendText($"\r\nTotal Processes: {allProcesses.Length}");

                txt_output_system.SelectionStart = 0;
                txt_output_system.ScrollToCaret();
            }
            catch (Exception ex)
            {
                txt_output_system.Text = $"ERROR: Could not list processes.\r\nDetails: {ex.Message}";
                System.Media.SystemSounds.Hand.Play();
            }
        }

        private void btn_port_scan_Click(object sender, EventArgs e)
        {
            string target = txt_port_scan_target.Text.Trim();

            // 1. Validação do Input
            if (string.IsNullOrWhiteSpace(target))
            {
                txt_output_security.Text = "ERROR: Target Host/IP is required.\r\n";
                System.Media.SystemSounds.Hand.Play();
                return;
            }

            // Tenta converter o texto da porta para um número válido
            if (!int.TryParse(txt_port_number.Text, out int port) || port < 1 || port > 65535)
            {
                txt_output_security.Text = "ERROR: Invalid port number (must be 1-65535).\r\n";
                System.Media.SystemSounds.Hand.Play();
                return;
            }

            txt_output_security.Text = $"INITIATING PORT SCAN:\r\nTarget: {target} | Port: {port}\r\n";
            txt_output_security.AppendText("--------------------------------------------------\r\n");

            // Tentativa de ligação TCP
            // Usamos 'using' para garantir que o TcpClient é descartado corretamente
            using (TcpClient tcpClient = new TcpClient())
            {
                try
                {
                    // Define um timeout de 1.5 segundos para não bloquear a interface
                    IAsyncResult result = tcpClient.BeginConnect(target, port, null, null);
                    bool success = result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(1.5));

                    if (success && tcpClient.Connected)
                    {
                        txt_output_security.AppendText($"[RESULT] Port {port}: **OPEN**\r\nSTATUS: Connection successful.\r\n");
                        System.Media.SystemSounds.Asterisk.Play();
                    }
                    else
                    {
                        // Se falhou ou o timeout expirou
                        txt_output_security.AppendText($"[RESULT] Port {port}: **CLOSED/FILTERED**\r\nSTATUS: Connection failed or timed out.\r\n");
                        System.Media.SystemSounds.Exclamation.Play();
                    }
                    tcpClient.EndConnect(result);
                }
                catch (Exception ex)
                {
                    // Erro de DNS, Host inalcançável, ou outro erro grave
                    txt_output_security.AppendText($"[RESULT] ERROR: Host unreachable or DNS failure.\r\n");
                    txt_output_security.AppendText($"DETAILS: {ex.Message.Substring(0, Math.Min(ex.Message.Length, 60))}...\r\n");
                    System.Media.SystemSounds.Hand.Play();
                }
            }

            txt_output_security.AppendText("--------------------------------------------------");
        }

        private void btn_firewall_Click(object sender, EventArgs e)
        {
            txt_output_security.Text = "::: FIREWALL STATUS SCAN :::\r\n";
            txt_output_security.AppendText("--------------------------------------------------\r\n");

            try
            {
                // Cria um novo processo para executar um comando da linha de comandos
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "netsh", // Executa o utilitário de rede do Windows
                    Arguments = "advfirewall show allprofiles state", // Comando para obter o estado
                    RedirectStandardOutput = true, // Permite-nos ler o resultado
                    UseShellExecute = false, // Não usa a shell do Windows diretamente
                    CreateNoWindow = true    // Não mostra a janela preta da linha de comandos
                };

                // Inicia e espera pelo processo
                using (Process process = Process.Start(startInfo))
                {
                    // Lê todo o output do comando
                    string result = process.StandardOutput.ReadToEnd();
                    process.WaitForExit();

                    // Formata o output e envia para a TextBox
                    txt_output_security.AppendText("STATUS REPORT:\r\n\r\n");

                    // O output é extenso, vamos filtrar apenas o essencial para o ecrã
                    string[] lines = result.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string line in lines)
                    {
                        // Filtra as linhas que contêm o estado Ativo/Inativo
                        if (line.Contains("State") || line.Contains("Estado"))
                        {
                            // Usa '>>' para imitar um redirecionamento de terminal
                            txt_output_security.AppendText($">> {line.Trim()}\r\n");
                        }
                    }

                    txt_output_security.AppendText("\r\n--- SCAN COMPLETE ---");
                }
            }
            catch (Exception ex)
            {
                txt_output_security.Text = $"SECURITY ERROR: Could not execute firewall command.\r\nDETAILS: {ex.Message}";
                System.Media.SystemSounds.Hand.Play();
            }
        }

        private void btn_logs_Click(object sender, EventArgs e)
        {
            txt_output_security.Text = "::: SCANNING CRITICAL EVENT LOGS :::\r\n";
            txt_output_security.AppendText("--------------------------------------------------\r\n");

            // Registos a analisar (Sistema e Aplicação)
            string[] logNames = { "System", "Application" };
            int maxEntries = 20; // Limite para não demorar muito

            try
            {
                StringBuilder output = new StringBuilder();

                foreach (string logName in logNames)
                {
                    EventLog log = new EventLog(logName);
                    int entryCount = log.Entries.Count;

                    output.AppendLine($"[LOG] Scanning '{logName}' Log ({entryCount} total entries)...");

                    int entriesFound = 0;
                    // Itera sobre as últimas entradas, começando pela mais recente
                    for (int i = entryCount - 1; i >= 0 && entriesFound < maxEntries; i--)
                    {
                        EventLogEntry entry = log.Entries[i];

                        // Filtra apenas entradas de Erro (Error) e Aviso Crítico (Warning)
                        if (entry.EntryType == EventLogEntryType.Error || entry.EntryType == EventLogEntryType.Warning)
                        {
                            // Formata a linha de output no estilo ciber
                            output.AppendLine($">> TIME: {entry.TimeGenerated.ToString("HH:mm:ss")}");
                            output.AppendLine($">> TYPE: {entry.EntryType}");
                            output.AppendLine($">> SOURCE: {entry.Source}");
                            // Mostra o início da mensagem (limitado a 80 caracteres para limpar a visualização)
                            output.AppendLine($"   MSG: {entry.Message.Substring(0, Math.Min(entry.Message.Length, 80))}...");
                            output.AppendLine("   ---");
                            entriesFound++;
                        }
                    }
                    log.Dispose(); // Liberta o recurso

                    if (entriesFound == 0)
                    {
                        output.AppendLine($"[STATUS] No recent Critical or Warning entries found in {logName}.\r\n");
                    }
                }

                txt_output_security.AppendText(output.ToString());
                txt_output_security.AppendText("\r\n--- SCAN COMPLETE ---");

                txt_output_security.SelectionStart = 0;
                txt_output_security.ScrollToCaret();
            }
            catch (Exception ex)
            {
                txt_output_security.Text = $"LOG SCAN ERROR: Could not access Windows Event Logs.\r\nDETAILS: {ex.Message}";
                System.Media.SystemSounds.Hand.Play();
            }
        }

        private void Frm_MainMenu_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                lastCursor = Cursor.Position;
                lastForm = this.Location;
            }
        }

        private void Frm_MainMenu_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                // Calcula a diferença entre a posição antiga e a nova
                int deltaX = Cursor.Position.X - lastCursor.X;
                int deltaY = Cursor.Position.Y - lastCursor.Y;

                // Move o formulário pela diferença
                this.Location = new Point(lastForm.X + deltaX, lastForm.Y + deltaY);
            }
        }

        private void Frm_MainMenu_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
            // Opcional: Atualiza a posição inicial para o próximo arrasto
            lastForm = this.Location;
        }

        private void btn_system_shutdown_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                "WARNING: Initiating system shutdown.\r\nAre you absolutely sure you want to proceed?",
                "SECURITY ALERT",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Stop // Usamos o ícone de 'Stop' para dar ênfase
            );

            // Verifica se o utilizador confirmou
            if (resultado == DialogResult.Yes)
            {
                txt_output_maintenance.Text = "INITIATING SHUTDOWN SEQUENCE...\r\n";
                txt_output_maintenance.AppendText("--------------------------------------------------\r\n");

                try
                {
                    // 2. Executar o Comando do Sistema (shutdown.exe)

                    Process.Start("shutdown", "/s /t 0"); // /s = shutdown, /t 0 = tempo zero (imediato)

                    txt_output_maintenance.AppendText("[STATUS] Shutdown command issued successfully.\r\n");
                    txt_output_maintenance.AppendText("System will power off momentarily.");

                    // É crucial fechar a tua aplicação rapidamente para evitar problemas.
                    Application.Exit();
                }
                catch (Exception ex)
                {
                    txt_output_maintenance.Text = $"ERROR: Failed to execute shutdown command.\r\nDETAILS: {ex.Message}";
                    System.Media.SystemSounds.Hand.Play();
                }
            }
            else
            {
                // Se o utilizador disser 'Não'
                txt_output_maintenance.Text = "SHUTDOWN ABORTED: Operation cancelled by user.\r\n";
                System.Media.SystemSounds.Exclamation.Play();
            }
        }

        private void btn_restart_system_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                "WARNING: Initiating system restart.\r\nAre you absolutely sure you want to proceed?",
                "SECURITY ALERT",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Stop
            );

            // Verifica se o utilizador confirmou
            if (resultado == DialogResult.Yes)
            {
                txt_output_maintenance.Text = "INITIATING RESTART SEQUENCE...\r\n";
                txt_output_maintenance.AppendText("--------------------------------------------------\r\n");

                try
                {
                    // 2. Executar o Comando do Sistema (shutdown.exe)
                    // O argumento chave é '/r' (reboot) em vez de '/s' (shutdown)
                    Process.Start("shutdown", "/r /t 0"); // /r = restart, /t 0 = tempo zero (imediato)

                    txt_output_maintenance.AppendText("[STATUS] Restart command issued successfully.\r\n");
                    txt_output_maintenance.AppendText("System will reboot momentarily.");

                    // Fechar a tua aplicação
                    Application.Exit();
                }
                catch (Exception ex)
                {
                    txt_output_maintenance.Text = $"ERROR: Failed to execute restart command.\r\nDETAILS: {ex.Message}";
                    System.Media.SystemSounds.Hand.Play();
                }
            }
            else
            {
                // Se o utilizador disser 'Não'
                txt_output_maintenance.Text = "RESTART ABORTED: Operation cancelled by user.\r\n";
                System.Media.SystemSounds.Exclamation.Play();
            }
        }

        private void txt_targetHost_KeyDown(object sender, KeyEventArgs e)
        {
            // Verifica se a tecla pressionada foi o ENTER
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btn_ping.PerformClick();
            }
        }

        private void txt_port_number_KeyDown(object sender, KeyEventArgs e)
        {
            // Verifica se a tecla pressionada foi o ENTER
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btn_port_scan.PerformClick();
            }
        }
    }
}
