using iText.IO.Font;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Path = System.IO.Path;
using Point = System.Drawing.Point;

namespace ProjetoFinal
{
    public partial class Frm_MainMenu : Form
    {

        // Variables for custom form dragging/movement
        private bool isDragging = false;
        private Point lastCursor;
        private Point lastForm;

        private string loggedInUsername;

        public Frm_MainMenu(string loggedInUsername)
        {
            InitializeComponent();
            this.loggedInUsername = loggedInUsername;
            DisplayUsername();

            // Wire up all HeaderControl events (Logout and Export)
            hc_network.LogoutClicked += HeaderControl_LogoutClicked;
            hc_system.LogoutClicked += HeaderControl_LogoutClicked;
            hc_security.LogoutClicked += HeaderControl_LogoutClicked;
            hc_maintenance.LogoutClicked += HeaderControl_LogoutClicked;

            hc_network.ExportRequested += HeaderControl_ExportRequested;
            hc_system.ExportRequested += HeaderControl_ExportRequested;
            hc_security.ExportRequested += HeaderControl_ExportRequested;
            hc_maintenance.ExportRequested += HeaderControl_ExportRequested;
        }

        /// <summary>
        /// Updates the username text displayed in all header controls.
        /// </summary>
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
            txt_output_network.Text = "";

            // Use StringBuilder for efficient string concatenation
            StringBuilder output = new StringBuilder();
            output.AppendLine("::: NETWORK CONFIGURATION REPORT :::");
            output.AppendLine("------------------------------------");

            // Get all network interfaces on the computer
            NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface adapter in networkInterfaces)
            {
                // Skip interfaces that are not active
                if (adapter.OperationalStatus != OperationalStatus.Up)
                    continue;

                output.AppendLine($"\n[INTERFACE] {adapter.Name}");
                output.AppendLine($"  Description: {adapter.Description}");
                output.AppendLine($"  Type: {adapter.NetworkInterfaceType}");
                output.AppendLine($"  Status: {adapter.OperationalStatus}");
                output.AppendLine($"  MAC Address: {adapter.GetPhysicalAddress().ToString()}");

                // Get IP and DNS properties
                IPInterfaceProperties properties = adapter.GetIPProperties();

                // Iterate over IP addresses (IPv4 and IPv6)
                foreach (UnicastIPAddressInformation ip in properties.UnicastAddresses)
                {
                    if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork) // IPv4 only
                    {
                        output.AppendLine($"  IPv4 Address: {ip.Address}");
                        output.AppendLine($"  Subnet Mask:  {ip.IPv4Mask}");
                    }
                }

                // Display Default Gateways
                foreach (GatewayIPAddressInformation gateway in properties.GatewayAddresses)
                {
                    output.AppendLine($"  Default Gateway: {gateway.Address}");
                }

                // Display DNS Servers
                foreach (System.Net.IPAddress dns in properties.DnsAddresses)
                {
                    output.AppendLine($"  DNS Server: {dns}");
                }
                output.AppendLine("------------------------------------");
            }

            // Assign the built text to the output box and scroll to the top
            txt_output_network.Text = output.ToString();
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

            // Send 4 ICMP packets, simulating the CMD behavior
            for (int i = 0; i < sent; i++)
            {
                try
                {
                    PingReply reply = pingSender.Send(target, timeoutMs);

                    if (reply.Status == IPStatus.Success)
                    {
                        txt_output_network.AppendText($"Reply from {reply.Address}: time={reply.RoundtripTime}ms\r\n");
                        roundtripTimes.Add(reply.RoundtripTime);
                        received++;
                    }
                    else
                    {
                        txt_output_network.AppendText($"Request timed out or failed. Status: {reply.Status}\r\n");
                    }
                }
                catch (Exception ex)
                {
                    // Catch DNS or general network errors
                    txt_output_network.AppendText($"Error during ping to {target}: {ex.Message}\r\n");
                    // Stop sending packets on major failure
                    break;
                }
            }

            // Display Statistics Summary
            txt_output_network.AppendText("\r\n--- PING STATISTICS ---\r\n");

            int lost = sent - received;
            double lossPercentage = (double)lost / sent * 100;

            // Packet Summary
            txt_output_network.AppendText($"Packets: Sent = {sent}, Received = {received}, Lost = {lost} ({lossPercentage:F0}% loss)\r\n");

            // Roundtrip Times
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
                // Get global IP properties and active TCP connections
                IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
                TcpConnectionInformation[] tcpConnections = properties.GetActiveTcpConnections();

                StringBuilder output = new StringBuilder();
                output.AppendLine($"Total TCP Connections: {tcpConnections.Length}\r\n");
                output.AppendLine($"{"PROTOCOL",-8} {"LOCAL ADDRESS",-25} {"REMOTE ADDRESS",-25} {"STATE",-15}");
                output.AppendLine($"{"--------",-8} {"---------------",-25} {"----------------",-25} {"-----",-15}");

                foreach (TcpConnectionInformation info in tcpConnections)
                {
                    // Format output for terminal-like alignment
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

        /// <summary>
        /// Handles the Logout event raised by any of the Header controls.
        /// </summary>
        private void HeaderControl_LogoutClicked(object sender, EventArgs e)
        {
            // Close the main form and open the login form
            Frm_login frm_Login = new Frm_login();
            frm_Login.Show();
            this.Close();
        }

        /// <summary>
        /// Retrieves and displays core Operating System and hardware information.
        /// </summary>
        private void LoadSystemInfo()
        {
            txt_output_system.Text = "::: SYSTEM INFORMATION SCAN :::\r\n";
            txt_output_system.AppendText("-------------------------------------\r\n");

            try
            {
                // 1. Operating System Information
                txt_output_system.AppendText($"[OS] Version: {Environment.OSVersion.VersionString}\r\n");
                txt_output_system.AppendText($"[OS] Machine Name: {Environment.MachineName}\r\n");
                txt_output_system.AppendText($"[OS] 64-bit OS: {Environment.Is64BitOperatingSystem}\r\n");
                txt_output_system.AppendText($"[OS] User Domain: {Environment.UserDomainName}\r\n");

                // 2. Processor Information
                txt_output_system.AppendText("\r\n--- PROCESSOR INFO ---\r\n");
                txt_output_system.AppendText($"[CPU] Cores/Threads: {Environment.ProcessorCount}\r\n");

                // 3. Memory (RAM) Information
                long totalRamBytes = GetTotalPhysicalMemory();
                txt_output_system.AppendText($"[RAM] Total Physical Memory: {(totalRamBytes / 1024 / 1024):N0} MB\r\n");

                // 4. Other Configuration Details
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

        /// <summary>
        /// Uses Windows Management Instrumentation (WMI) to get the total physical memory in bytes.
        /// </summary>
        private long GetTotalPhysicalMemory()
        {
            ObjectQuery wmiQuery = new ObjectQuery("SELECT TotalVisibleMemorySize FROM Win32_OperatingSystem");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(wmiQuery);
            ManagementObjectCollection results = searcher.Get();

            long totalMemory = 0;
            foreach (ManagementObject result in results)
            {
                // Value is in KiloBytes, convert to Bytes
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
                // 1. Get Real-Time CPU Usage
                // PerformanceCounter requires a short pause for a valid reading
                PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
                cpuCounter.NextValue();
                System.Threading.Thread.Sleep(500);
                float cpuUsage = cpuCounter.NextValue();

                // 2. Get Memory Information
                PerformanceCounter ramCounter = new PerformanceCounter("Memory", "Available MBytes");
                float availableRam = ramCounter.NextValue();

                // Calculate used RAM using the helper method
                long totalRam = GetTotalPhysicalMemory();
                long usedRam = totalRam - (long)(availableRam * 1024 * 1024); // Convert available MB to bytes and subtract

                // 3. Display formatted output
                txt_output_system.AppendText($"[CPU LOAD] {cpuUsage:F2}%\r\n");
                txt_output_system.AppendText($"[RAM USED] {(usedRam / 1024 / 1024):N0} MB\r\n");
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
                Process[] allProcesses = Process.GetProcesses();
                StringBuilder output = new StringBuilder();

                // Column Headers for terminal-like alignment
                output.AppendLine($"{"PID",-8} {"CPU TIME",-10} {"MEMORY (MB)",-15} {"PROCESS NAME"}");
                output.AppendLine($"{"---",-8} {"--------",-10} {"-----------",-15} {"------------"}");

                // Iterate over all processes
                foreach (Process p in allProcesses)
                {
                    try
                    {
                        TimeSpan cpuTime = p.TotalProcessorTime;
                        // WorkingSet64 is physical memory in bytes used by the process
                        long memoryUsageMB = p.WorkingSet64 / (1024 * 1024);

                        // Format the output line
                        output.AppendLine(
                            $"{p.Id,-8} " +
                            $"{cpuTime.TotalSeconds,-10:F2} " +
                            $"{memoryUsageMB,-15:N0} " +
                            $"{p.ProcessName}"
                        );
                    }
                    catch (Exception)
                    {
                        // Ignore processes we can't access (often system processes)
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

            // Input validation
            if (string.IsNullOrWhiteSpace(target))
            {
                txt_output_security.Text = "ERROR: Target Host/IP is required.\r\n";
                System.Media.SystemSounds.Hand.Play();
                return;
            }

            // Validate port number
            if (!int.TryParse(txt_port_number.Text, out int port) || port < 1 || port > 65535)
            {
                txt_output_security.Text = "ERROR: Invalid port number (must be 1-65535).\r\n";
                System.Media.SystemSounds.Hand.Play();
                return;
            }

            txt_output_security.Text = $"INITIATING PORT SCAN:\r\nTarget: {target} | Port: {port}\r\n";
            txt_output_security.AppendText("--------------------------------------------------\r\n");

            // Attempt TCP connection with a timeout
            using (TcpClient tcpClient = new TcpClient())
            {
                try
                {
                    // Use asynchronous connect with a timeout of 1.5 seconds
                    IAsyncResult result = tcpClient.BeginConnect(target, port, null, null);
                    bool success = result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(1.5));

                    if (success && tcpClient.Connected)
                    {
                        txt_output_security.AppendText($"[RESULT] Port {port}: **OPEN**\r\nSTATUS: Connection successful.\r\n");
                        System.Media.SystemSounds.Asterisk.Play();
                    }
                    else
                    {
                        // Connection failed or timed out
                        txt_output_security.AppendText($"[RESULT] Port {port}: **CLOSED/FILTERED**\r\nSTATUS: Connection failed or timed out.\r\n");
                        System.Media.SystemSounds.Exclamation.Play();
                    }
                    tcpClient.EndConnect(result);
                }
                catch (Exception ex)
                {
                    // DNS or unreachable host error
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
                // Execute 'netsh' command to get firewall state for all profiles
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "netsh",
                    Arguments = "advfirewall show allprofiles state",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (Process process = Process.Start(startInfo))
                {
                    string result = process.StandardOutput.ReadToEnd();
                    process.WaitForExit();

                    txt_output_security.AppendText("STATUS REPORT:\r\n\r\n");

                    // Filter the output to show only the active/inactive state lines
                    string[] lines = result.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string line in lines)
                    {
                        if (line.Contains("State") || line.Contains("Estado"))
                        {
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

            // Logs to analyze (System and Application)
            string[] logNames = { "System", "Application" };
            int maxEntries = 20; // Limit the number of entries for quick display

            try
            {
                StringBuilder output = new StringBuilder();

                foreach (string logName in logNames)
                {
                    EventLog log = new EventLog(logName);
                    int entryCount = log.Entries.Count;

                    output.AppendLine($"[LOG] Scanning '{logName}' Log ({entryCount} total entries)...");

                    int entriesFound = 0;
                    // Iterate over the latest entries, starting from the most recent
                    for (int i = entryCount - 1; i >= 0 && entriesFound < maxEntries; i--)
                    {
                        EventLogEntry entry = log.Entries[i];

                        // Filter for Error and Critical Warning entries
                        if (entry.EntryType == EventLogEntryType.Error || entry.EntryType == EventLogEntryType.Warning)
                        {
                            // Format the output line
                            output.AppendLine($">> TIME: {entry.TimeGenerated.ToString("HH:mm:ss")}");
                            output.AppendLine($">> TYPE: {entry.EntryType}");
                            output.AppendLine($">> SOURCE: {entry.Source}");
                            // Show the beginning of the message (limited to 80 chars for clarity)
                            output.AppendLine($"  MSG: {entry.Message.Substring(0, Math.Min(entry.Message.Length, 80))}...");
                            output.AppendLine("  ---");
                            entriesFound++;
                        }
                    }
                    log.Dispose(); // Release the log resource

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

        // Custom form dragging implementation (MouseDown)
        private void Frm_MainMenu_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                lastCursor = Cursor.Position;
                lastForm = this.Location;
            }
        }

        // Custom form dragging implementation (MouseMove)
        private void Frm_MainMenu_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                // Calculate the difference between the old and new cursor position
                int deltaX = Cursor.Position.X - lastCursor.X;
                int deltaY = Cursor.Position.Y - lastCursor.Y;

                // Move the form by the difference
                this.Location = new Point(lastForm.X + deltaX, lastForm.Y + deltaY);
            }
        }

        // Custom form dragging implementation (MouseUp)
        private void Frm_MainMenu_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
            lastForm = this.Location;
        }

        private void btn_system_shutdown_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "WARNING: Initiating system shutdown.\r\nAre you absolutely sure you want to proceed?",
                "SECURITY ALERT",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Stop
            );

            // Check for user confirmation
            if (result == DialogResult.Yes)
            {
                txt_output_maintenance.Text = "INITIATING SHUTDOWN SEQUENCE...\r\n";
                txt_output_maintenance.AppendText("--------------------------------------------------\r\n");

                try
                {
                    // Execute the system shutdown command (immediate)
                    Process.Start("shutdown", "/s /t 0"); // /s = shutdown, /t 0 = zero time

                    txt_output_maintenance.AppendText("[STATUS] Shutdown command issued successfully.\r\n");
                    txt_output_maintenance.AppendText("System will power off momentarily.");

                    // Close the application quickly
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
                txt_output_maintenance.Text = "SHUTDOWN ABORTED: Operation cancelled by user.\r\n";
                System.Media.SystemSounds.Exclamation.Play();
            }
        }

        private void btn_restart_system_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "WARNING: Initiating system restart.\r\nAre you absolutely sure you want to proceed?",
                "SECURITY ALERT",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Stop
            );

            // Check for user confirmation
            if (result == DialogResult.Yes)
            {
                txt_output_maintenance.Text = "INITIATING RESTART SEQUENCE...\r\n";
                txt_output_maintenance.AppendText("--------------------------------------------------\r\n");

                try
                {
                    // Execute the system restart command (immediate)
                    Process.Start("shutdown", "/r /t 0"); // /r = restart, /t 0 = zero time

                    txt_output_maintenance.AppendText("[STATUS] Restart command issued successfully.\r\n");
                    txt_output_maintenance.AppendText("System will reboot momentarily.");

                    // Close the application
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
                txt_output_maintenance.Text = "RESTART ABORTED: Operation cancelled by user.\r\n";
                System.Media.SystemSounds.Exclamation.Play();
            }
        }

        // Allows the user to initiate a Ping by pressing Enter in the target host text box.
        private void txt_targetHost_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btn_ping.PerformClick();
            }
        }

        // Allows the user to initiate a Port Scan by pressing Enter in the port number text box.
        private void txt_port_number_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btn_port_scan.PerformClick();
            }
        }

        private void HeaderControl_ExportRequested(object sender, EventArgs e)
        {
            TextBox activeTextBox = GetActiveOutputTextBox();

            // CONTENT CHECK (Warning message if output is empty)
            if (activeTextBox == null || string.IsNullOrWhiteSpace(activeTextBox.Text))
            {
                MessageBox.Show("You must have OUTPUT information on the screen for the export to work.",
                                "Empty Content", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Assumes 'saveFileDialog1' is defined on Frm_MainMenu
            saveFileDialog1.Filter = "PDF File (*.pdf)|*.pdf|Text File (*.txt)|*.txt|CSV (*.csv)|*.csv";
            saveFileDialog1.Title = "Save Report";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                HandleExport(saveFileDialog1.FileName, activeTextBox.Text);
            }
        }

        private TextBox GetActiveOutputTextBox()
        {
            // We use the control name you provided: 'tc_controller'
            TabPage selectedTab = tc_controller.SelectedTab;

            if (selectedTab != null)
            {
                // Map the TabPage Name to the specific TextBox Name
                // Adjust these names if your TabPage names differ from the control name prefixes.
                if (selectedTab.Name == "tp_network")
                    return txt_output_network;

                if (selectedTab.Name == "tp_system")
                    return txt_output_system;

                if (selectedTab.Name == "tp_security")
                    return txt_output_security;

                if (selectedTab.Name == "tp_maintenance")
                    return txt_output_maintenance;
            }

            return null;
        }

        private void HandleExport(string filePath, string content)
        {
            string extension = Path.GetExtension(filePath).ToLower();

            try
            {
                if (extension == ".txt" || extension == ".csv")
                {
                    // TXT/CSV LOGIC: Use standard .NET StreamWriter for plaintext export.
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        writer.Write(content); // Writes all content at once
                    }
                }
                else if (extension == ".pdf")
                {
                    // PDF LOGIC: Use iText 7 to create the document.

                    // 1. Create PdfWriter and PdfDocument within 'using' blocks for automatic resource disposal.
                    using (var writer = new PdfWriter(filePath))
                    using (var pdf = new PdfDocument(writer))
                    {
                        // 2. Create the main Document object using the default A4 page size.
                        var document = new Document(pdf, PageSize.A4);

                        // Set standard margins.
                        document.SetMargins(40, 40, 40, 40);

                        // 3. Define the font and size for the text. 
                        // Helvetica is a built-in standard PDF font, ensuring compatibility without external files.
                        PdfFont font = PdfFontFactory.CreateFont(FontConstants.HELVETICA);
                        float fontSize = 10f;

                        // 4. Create a Paragraph element with the report content.
                        // The Paragraph automatically handles text wrapping and line breaks.
                        var paragraph = new Paragraph(content)
                            .SetFont(font)
                            .SetFontSize(fontSize)
                            .SetFixedLeading(14f); // Set line spacing for better readability

                        // Add the formatted content to the document.
                        document.Add(paragraph);

                        // 5. Document closure (handled by the 'using' block).
                    }
                }
                else
                {
                    MessageBox.Show("Unsupported file format.", "Error");
                    return;
                }

                // Success message and automatically open the exported file
                MessageBox.Show($"Report successfully exported to:\n{filePath}",
                                "Export Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Open the file with the default associated application
                Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                // Handle all file saving or iText errors
                MessageBox.Show("An error occurred while saving the file: " + ex.Message,
                                "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
