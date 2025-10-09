namespace ProjetoFinal
{
    partial class Frm_MainMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tc_controller = new System.Windows.Forms.TabControl();
            this.tp_network = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.hc_network = new ProjetoFinal.HeaderControl();
            this.txt_output_network = new System.Windows.Forms.TextBox();
            this.btn_active_ports = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_targetHost = new System.Windows.Forms.TextBox();
            this.btn_ping = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_ipconfiguration = new System.Windows.Forms.Button();
            this.tp_system = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_view_processes = new System.Windows.Forms.Button();
            this.hc_system = new ProjetoFinal.HeaderControl();
            this.txt_output_system = new System.Windows.Forms.TextBox();
            this.btn_check_health = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_scan_system = new System.Windows.Forms.Button();
            this.tp_security = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_port_scan_target = new System.Windows.Forms.TextBox();
            this.txt_port_number = new System.Windows.Forms.TextBox();
            this.btn_logs = new System.Windows.Forms.Button();
            this.hc_security = new ProjetoFinal.HeaderControl();
            this.txt_output_security = new System.Windows.Forms.TextBox();
            this.btn_port_scan = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_firewall = new System.Windows.Forms.Button();
            this.tp_maintenance = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.btn_restart_system = new System.Windows.Forms.Button();
            this.txt_output_maintenance = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btn_system_shutdown = new System.Windows.Forms.Button();
            this.hc_maintenance = new ProjetoFinal.HeaderControl();
            this.label15 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tc_controller.SuspendLayout();
            this.tp_network.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tp_system.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tp_security.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tp_maintenance.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tc_controller
            // 
            this.tc_controller.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tc_controller.Controls.Add(this.tp_network);
            this.tc_controller.Controls.Add(this.tp_system);
            this.tc_controller.Controls.Add(this.tp_security);
            this.tc_controller.Controls.Add(this.tp_maintenance);
            this.tc_controller.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tc_controller.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tc_controller.Location = new System.Drawing.Point(0, 0);
            this.tc_controller.Name = "tc_controller";
            this.tc_controller.SelectedIndex = 0;
            this.tc_controller.Size = new System.Drawing.Size(804, 839);
            this.tc_controller.TabIndex = 0;
            // 
            // tp_network
            // 
            this.tp_network.BackColor = System.Drawing.Color.Black;
            this.tp_network.BackgroundImage = global::ProjetoFinal.Properties.Resources.login_background;
            this.tp_network.Controls.Add(this.panel1);
            this.tp_network.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tp_network.ForeColor = System.Drawing.Color.Lime;
            this.tp_network.Location = new System.Drawing.Point(4, 31);
            this.tp_network.Name = "tp_network";
            this.tp_network.Padding = new System.Windows.Forms.Padding(3);
            this.tp_network.Size = new System.Drawing.Size(796, 804);
            this.tp_network.TabIndex = 0;
            this.tp_network.Text = "Network";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.hc_network);
            this.panel1.Controls.Add(this.txt_output_network);
            this.panel1.Controls.Add(this.btn_active_ports);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txt_targetHost);
            this.panel1.Controls.Add(this.btn_ping);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btn_ipconfiguration);
            this.panel1.Location = new System.Drawing.Point(27, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(740, 749);
            this.panel1.TabIndex = 9;
            // 
            // hc_network
            // 
            this.hc_network.BackColor = System.Drawing.Color.Black;
            this.hc_network.Location = new System.Drawing.Point(452, 4);
            this.hc_network.Margin = new System.Windows.Forms.Padding(4);
            this.hc_network.Name = "hc_network";
            this.hc_network.Size = new System.Drawing.Size(284, 58);
            this.hc_network.TabIndex = 14;
            this.hc_network.UsernameText = "";
            // 
            // txt_output_network
            // 
            this.txt_output_network.BackColor = System.Drawing.Color.Black;
            this.txt_output_network.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_output_network.ForeColor = System.Drawing.Color.Lime;
            this.txt_output_network.Location = new System.Drawing.Point(20, 294);
            this.txt_output_network.Multiline = true;
            this.txt_output_network.Name = "txt_output_network";
            this.txt_output_network.ReadOnly = true;
            this.txt_output_network.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_output_network.Size = new System.Drawing.Size(701, 433);
            this.txt_output_network.TabIndex = 4;
            // 
            // btn_active_ports
            // 
            this.btn_active_ports.BackColor = System.Drawing.Color.Transparent;
            this.btn_active_ports.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.btn_active_ports.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btn_active_ports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_active_ports.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_active_ports.ForeColor = System.Drawing.Color.Lime;
            this.btn_active_ports.Location = new System.Drawing.Point(490, 156);
            this.btn_active_ports.Name = "btn_active_ports";
            this.btn_active_ports.Size = new System.Drawing.Size(161, 59);
            this.btn_active_ports.TabIndex = 3;
            this.btn_active_ports.Text = "ACTIVE PORTS";
            this.btn_active_ports.UseVisualStyleBackColor = false;
            this.btn_active_ports.Click += new System.EventHandler(this.btn_active_ports_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Lime;
            this.label1.Location = new System.Drawing.Point(16, 254);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 22);
            this.label1.TabIndex = 7;
            this.label1.Text = "OUTPUT:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 19);
            this.label2.TabIndex = 12;
            this.label2.Text = "TARGET IP/HOST:";
            // 
            // txt_targetHost
            // 
            this.txt_targetHost.BackColor = System.Drawing.Color.Black;
            this.txt_targetHost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_targetHost.ForeColor = System.Drawing.Color.White;
            this.txt_targetHost.Location = new System.Drawing.Point(52, 140);
            this.txt_targetHost.Name = "txt_targetHost";
            this.txt_targetHost.Size = new System.Drawing.Size(161, 26);
            this.txt_targetHost.TabIndex = 0;
            this.txt_targetHost.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_targetHost_KeyDown);
            // 
            // btn_ping
            // 
            this.btn_ping.BackColor = System.Drawing.Color.Transparent;
            this.btn_ping.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.btn_ping.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btn_ping.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ping.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ping.ForeColor = System.Drawing.Color.Lime;
            this.btn_ping.Location = new System.Drawing.Point(234, 118);
            this.btn_ping.Name = "btn_ping";
            this.btn_ping.Size = new System.Drawing.Size(161, 48);
            this.btn_ping.TabIndex = 1;
            this.btn_ping.Text = "PING HOST";
            this.btn_ping.UseVisualStyleBackColor = false;
            this.btn_ping.Click += new System.EventHandler(this.btn_ping_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Lime;
            this.label3.Location = new System.Drawing.Point(16, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(502, 24);
            this.label3.TabIndex = 7;
            this.label3.Text = "NETWORK DIAGNOSTICS";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btn_ipconfiguration
            // 
            this.btn_ipconfiguration.BackColor = System.Drawing.Color.Transparent;
            this.btn_ipconfiguration.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.btn_ipconfiguration.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btn_ipconfiguration.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ipconfiguration.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ipconfiguration.ForeColor = System.Drawing.Color.Lime;
            this.btn_ipconfiguration.Location = new System.Drawing.Point(490, 80);
            this.btn_ipconfiguration.Name = "btn_ipconfiguration";
            this.btn_ipconfiguration.Size = new System.Drawing.Size(161, 59);
            this.btn_ipconfiguration.TabIndex = 2;
            this.btn_ipconfiguration.Text = "IP CONFIGURATION";
            this.btn_ipconfiguration.UseVisualStyleBackColor = false;
            this.btn_ipconfiguration.Click += new System.EventHandler(this.btn_ipconfiguration_Click);
            // 
            // tp_system
            // 
            this.tp_system.BackColor = System.Drawing.Color.Black;
            this.tp_system.BackgroundImage = global::ProjetoFinal.Properties.Resources.login_background;
            this.tp_system.Controls.Add(this.panel2);
            this.tp_system.Location = new System.Drawing.Point(4, 31);
            this.tp_system.Name = "tp_system";
            this.tp_system.Padding = new System.Windows.Forms.Padding(3);
            this.tp_system.Size = new System.Drawing.Size(796, 804);
            this.tp_system.TabIndex = 1;
            this.tp_system.Text = "System";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Controls.Add(this.btn_view_processes);
            this.panel2.Controls.Add(this.hc_system);
            this.panel2.Controls.Add(this.txt_output_system);
            this.panel2.Controls.Add(this.btn_check_health);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.btn_scan_system);
            this.panel2.Location = new System.Drawing.Point(27, 28);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(740, 751);
            this.panel2.TabIndex = 10;
            // 
            // btn_view_processes
            // 
            this.btn_view_processes.BackColor = System.Drawing.Color.Transparent;
            this.btn_view_processes.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.btn_view_processes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btn_view_processes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_view_processes.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_view_processes.ForeColor = System.Drawing.Color.Lime;
            this.btn_view_processes.Location = new System.Drawing.Point(450, 104);
            this.btn_view_processes.Name = "btn_view_processes";
            this.btn_view_processes.Size = new System.Drawing.Size(161, 59);
            this.btn_view_processes.TabIndex = 2;
            this.btn_view_processes.Text = "VIEW PROCESSES";
            this.btn_view_processes.UseVisualStyleBackColor = false;
            this.btn_view_processes.Click += new System.EventHandler(this.btn_view_processes_Click);
            // 
            // hc_system
            // 
            this.hc_system.BackColor = System.Drawing.Color.Black;
            this.hc_system.Location = new System.Drawing.Point(450, 4);
            this.hc_system.Margin = new System.Windows.Forms.Padding(4);
            this.hc_system.Name = "hc_system";
            this.hc_system.Size = new System.Drawing.Size(286, 58);
            this.hc_system.TabIndex = 14;
            this.hc_system.UsernameText = "";
            // 
            // txt_output_system
            // 
            this.txt_output_system.BackColor = System.Drawing.Color.Black;
            this.txt_output_system.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_output_system.ForeColor = System.Drawing.Color.Lime;
            this.txt_output_system.Location = new System.Drawing.Point(20, 294);
            this.txt_output_system.Multiline = true;
            this.txt_output_system.Name = "txt_output_system";
            this.txt_output_system.ReadOnly = true;
            this.txt_output_system.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_output_system.Size = new System.Drawing.Size(701, 438);
            this.txt_output_system.TabIndex = 3;
            // 
            // btn_check_health
            // 
            this.btn_check_health.BackColor = System.Drawing.Color.Transparent;
            this.btn_check_health.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.btn_check_health.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btn_check_health.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_check_health.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_check_health.ForeColor = System.Drawing.Color.Lime;
            this.btn_check_health.Location = new System.Drawing.Point(258, 104);
            this.btn_check_health.Name = "btn_check_health";
            this.btn_check_health.Size = new System.Drawing.Size(161, 59);
            this.btn_check_health.TabIndex = 1;
            this.btn_check_health.Text = "CHECK HEALTH";
            this.btn_check_health.UseVisualStyleBackColor = false;
            this.btn_check_health.Click += new System.EventHandler(this.btn_check_health_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Lime;
            this.label4.Location = new System.Drawing.Point(16, 254);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 22);
            this.label4.TabIndex = 7;
            this.label4.Text = "OUTPUT:";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Lime;
            this.label6.Location = new System.Drawing.Point(16, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(527, 24);
            this.label6.TabIndex = 7;
            this.label6.Text = "SYSTEM HEALTH";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btn_scan_system
            // 
            this.btn_scan_system.BackColor = System.Drawing.Color.Transparent;
            this.btn_scan_system.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.btn_scan_system.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btn_scan_system.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_scan_system.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_scan_system.ForeColor = System.Drawing.Color.Lime;
            this.btn_scan_system.Location = new System.Drawing.Point(66, 104);
            this.btn_scan_system.Name = "btn_scan_system";
            this.btn_scan_system.Size = new System.Drawing.Size(161, 59);
            this.btn_scan_system.TabIndex = 0;
            this.btn_scan_system.Text = "SYSTEM INFO";
            this.btn_scan_system.UseVisualStyleBackColor = false;
            this.btn_scan_system.Click += new System.EventHandler(this.btn_scan_system_Click);
            // 
            // tp_security
            // 
            this.tp_security.BackColor = System.Drawing.Color.Black;
            this.tp_security.BackgroundImage = global::ProjetoFinal.Properties.Resources.login_background;
            this.tp_security.Controls.Add(this.panel3);
            this.tp_security.Location = new System.Drawing.Point(4, 31);
            this.tp_security.Name = "tp_security";
            this.tp_security.Padding = new System.Windows.Forms.Padding(3);
            this.tp_security.Size = new System.Drawing.Size(796, 804);
            this.tp_security.TabIndex = 2;
            this.tp_security.Text = "Security";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.txt_port_scan_target);
            this.panel3.Controls.Add(this.txt_port_number);
            this.panel3.Controls.Add(this.btn_logs);
            this.panel3.Controls.Add(this.hc_security);
            this.panel3.Controls.Add(this.txt_output_security);
            this.panel3.Controls.Add(this.btn_port_scan);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.btn_firewall);
            this.panel3.Location = new System.Drawing.Point(27, 28);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(740, 744);
            this.panel3.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(41, 283);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(175, 14);
            this.label10.TabIndex = 20;
            this.label10.Text = "Ex: www.google.com | 443";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(40, 136);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(126, 19);
            this.label9.TabIndex = 19;
            this.label9.Text = "Port Number: ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(40, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(117, 19);
            this.label8.TabIndex = 18;
            this.label8.Text = "Target Host:";
            // 
            // txt_port_scan_target
            // 
            this.txt_port_scan_target.BackColor = System.Drawing.Color.Black;
            this.txt_port_scan_target.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_port_scan_target.ForeColor = System.Drawing.Color.White;
            this.txt_port_scan_target.Location = new System.Drawing.Point(44, 88);
            this.txt_port_scan_target.Name = "txt_port_scan_target";
            this.txt_port_scan_target.Size = new System.Drawing.Size(161, 26);
            this.txt_port_scan_target.TabIndex = 0;
            // 
            // txt_port_number
            // 
            this.txt_port_number.BackColor = System.Drawing.Color.Black;
            this.txt_port_number.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_port_number.ForeColor = System.Drawing.Color.White;
            this.txt_port_number.Location = new System.Drawing.Point(44, 158);
            this.txt_port_number.Name = "txt_port_number";
            this.txt_port_number.Size = new System.Drawing.Size(161, 26);
            this.txt_port_number.TabIndex = 1;
            this.txt_port_number.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_port_number_KeyDown);
            // 
            // btn_logs
            // 
            this.btn_logs.BackColor = System.Drawing.Color.Transparent;
            this.btn_logs.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.btn_logs.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btn_logs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_logs.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_logs.ForeColor = System.Drawing.Color.Lime;
            this.btn_logs.Location = new System.Drawing.Point(410, 210);
            this.btn_logs.Name = "btn_logs";
            this.btn_logs.Size = new System.Drawing.Size(161, 59);
            this.btn_logs.TabIndex = 4;
            this.btn_logs.Text = "ACTIVE LOGS";
            this.btn_logs.UseVisualStyleBackColor = false;
            this.btn_logs.Click += new System.EventHandler(this.btn_logs_Click);
            // 
            // hc_security
            // 
            this.hc_security.BackColor = System.Drawing.Color.Black;
            this.hc_security.Location = new System.Drawing.Point(455, 4);
            this.hc_security.Margin = new System.Windows.Forms.Padding(4);
            this.hc_security.Name = "hc_security";
            this.hc_security.Size = new System.Drawing.Size(281, 58);
            this.hc_security.TabIndex = 14;
            this.hc_security.UsernameText = "";
            // 
            // txt_output_security
            // 
            this.txt_output_security.BackColor = System.Drawing.Color.Black;
            this.txt_output_security.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_output_security.ForeColor = System.Drawing.Color.Lime;
            this.txt_output_security.Location = new System.Drawing.Point(20, 363);
            this.txt_output_security.Multiline = true;
            this.txt_output_security.Name = "txt_output_security";
            this.txt_output_security.ReadOnly = true;
            this.txt_output_security.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_output_security.Size = new System.Drawing.Size(701, 355);
            this.txt_output_security.TabIndex = 5;
            // 
            // btn_port_scan
            // 
            this.btn_port_scan.BackColor = System.Drawing.Color.Transparent;
            this.btn_port_scan.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.btn_port_scan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btn_port_scan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_port_scan.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_port_scan.ForeColor = System.Drawing.Color.Lime;
            this.btn_port_scan.Location = new System.Drawing.Point(44, 210);
            this.btn_port_scan.Name = "btn_port_scan";
            this.btn_port_scan.Size = new System.Drawing.Size(161, 59);
            this.btn_port_scan.TabIndex = 2;
            this.btn_port_scan.Text = "PORT SCAN";
            this.btn_port_scan.UseVisualStyleBackColor = false;
            this.btn_port_scan.Click += new System.EventHandler(this.btn_port_scan_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Lime;
            this.label5.Location = new System.Drawing.Point(16, 327);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 22);
            this.label5.TabIndex = 7;
            this.label5.Text = "OUTPUT:";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Lime;
            this.label7.Location = new System.Drawing.Point(16, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(555, 24);
            this.label7.TabIndex = 7;
            this.label7.Text = "SECURITY ANALYSIS";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btn_firewall
            // 
            this.btn_firewall.BackColor = System.Drawing.Color.Transparent;
            this.btn_firewall.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.btn_firewall.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btn_firewall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_firewall.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_firewall.ForeColor = System.Drawing.Color.Lime;
            this.btn_firewall.Location = new System.Drawing.Point(410, 116);
            this.btn_firewall.Name = "btn_firewall";
            this.btn_firewall.Size = new System.Drawing.Size(161, 59);
            this.btn_firewall.TabIndex = 3;
            this.btn_firewall.Text = "FIREWALL STATUS";
            this.btn_firewall.UseVisualStyleBackColor = false;
            this.btn_firewall.Click += new System.EventHandler(this.btn_firewall_Click);
            // 
            // tp_maintenance
            // 
            this.tp_maintenance.BackgroundImage = global::ProjetoFinal.Properties.Resources.login_background;
            this.tp_maintenance.Controls.Add(this.panel4);
            this.tp_maintenance.Location = new System.Drawing.Point(4, 31);
            this.tp_maintenance.Name = "tp_maintenance";
            this.tp_maintenance.Padding = new System.Windows.Forms.Padding(3);
            this.tp_maintenance.Size = new System.Drawing.Size(796, 804);
            this.tp_maintenance.TabIndex = 3;
            this.tp_maintenance.Text = "Maintenance";
            this.tp_maintenance.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Black;
            this.panel4.Controls.Add(this.label12);
            this.panel4.Controls.Add(this.btn_restart_system);
            this.panel4.Controls.Add(this.txt_output_maintenance);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Controls.Add(this.btn_system_shutdown);
            this.panel4.Controls.Add(this.hc_maintenance);
            this.panel4.Controls.Add(this.label15);
            this.panel4.Location = new System.Drawing.Point(27, 28);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(740, 744);
            this.panel4.TabIndex = 12;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(36, 261);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(659, 19);
            this.label12.TabIndex = 19;
            this.label12.Text = "SYSTEM ALERT: THESE BUTTONS WORK, USE WITH CAUTION";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_restart_system
            // 
            this.btn_restart_system.BackColor = System.Drawing.Color.Transparent;
            this.btn_restart_system.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.btn_restart_system.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btn_restart_system.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_restart_system.Font = new System.Drawing.Font("Consolas", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_restart_system.ForeColor = System.Drawing.Color.Lime;
            this.btn_restart_system.Location = new System.Drawing.Point(387, 114);
            this.btn_restart_system.Name = "btn_restart_system";
            this.btn_restart_system.Size = new System.Drawing.Size(308, 129);
            this.btn_restart_system.TabIndex = 18;
            this.btn_restart_system.Text = "RESTART SYSTEM";
            this.btn_restart_system.UseVisualStyleBackColor = false;
            this.btn_restart_system.Click += new System.EventHandler(this.btn_restart_system_Click);
            // 
            // txt_output_maintenance
            // 
            this.txt_output_maintenance.BackColor = System.Drawing.Color.Black;
            this.txt_output_maintenance.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_output_maintenance.ForeColor = System.Drawing.Color.Lime;
            this.txt_output_maintenance.Location = new System.Drawing.Point(20, 368);
            this.txt_output_maintenance.Multiline = true;
            this.txt_output_maintenance.Name = "txt_output_maintenance";
            this.txt_output_maintenance.ReadOnly = true;
            this.txt_output_maintenance.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_output_maintenance.Size = new System.Drawing.Size(701, 355);
            this.txt_output_maintenance.TabIndex = 16;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Lime;
            this.label11.Location = new System.Drawing.Point(16, 332);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 22);
            this.label11.TabIndex = 17;
            this.label11.Text = "OUTPUT:";
            // 
            // btn_system_shutdown
            // 
            this.btn_system_shutdown.BackColor = System.Drawing.Color.Transparent;
            this.btn_system_shutdown.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.btn_system_shutdown.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btn_system_shutdown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_system_shutdown.Font = new System.Drawing.Font("Consolas", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_system_shutdown.ForeColor = System.Drawing.Color.Lime;
            this.btn_system_shutdown.Location = new System.Drawing.Point(40, 114);
            this.btn_system_shutdown.Name = "btn_system_shutdown";
            this.btn_system_shutdown.Size = new System.Drawing.Size(308, 129);
            this.btn_system_shutdown.TabIndex = 15;
            this.btn_system_shutdown.Text = "SHUTDOWN SYSTEM";
            this.btn_system_shutdown.UseVisualStyleBackColor = false;
            this.btn_system_shutdown.Click += new System.EventHandler(this.btn_system_shutdown_Click);
            // 
            // hc_maintenance
            // 
            this.hc_maintenance.BackColor = System.Drawing.Color.Black;
            this.hc_maintenance.Location = new System.Drawing.Point(457, 4);
            this.hc_maintenance.Margin = new System.Windows.Forms.Padding(4);
            this.hc_maintenance.Name = "hc_maintenance";
            this.hc_maintenance.Size = new System.Drawing.Size(279, 58);
            this.hc_maintenance.TabIndex = 14;
            this.hc_maintenance.UsernameText = "";
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Lime;
            this.label15.Location = new System.Drawing.Point(16, 19);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(514, 24);
            this.label15.TabIndex = 7;
            this.label15.Text = "SYSTEM MAINTENANCE";
            this.label15.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Frm_MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::ProjetoFinal.Properties.Resources.login_background;
            this.ClientSize = new System.Drawing.Size(804, 839);
            this.ControlBox = false;
            this.Controls.Add(this.tc_controller);
            this.ForeColor = System.Drawing.Color.Lime;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Frm_MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Frm_MainMenu_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Frm_MainMenu_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Frm_MainMenu_MouseUp);
            this.tc_controller.ResumeLayout(false);
            this.tp_network.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tp_system.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tp_security.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tp_maintenance.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tc_controller;
        private System.Windows.Forms.TabPage tp_network;
        private System.Windows.Forms.TabPage tp_system;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_ipconfiguration;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_output_network;
        private System.Windows.Forms.Button btn_ping;
        private System.Windows.Forms.TextBox txt_targetHost;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_active_ports;
        private HeaderControl hc_network;
        private System.Windows.Forms.Panel panel2;
        private HeaderControl hc_system;
        private System.Windows.Forms.TextBox txt_output_system;
        private System.Windows.Forms.Button btn_check_health;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_scan_system;
        private System.Windows.Forms.Button btn_view_processes;
        private System.Windows.Forms.TabPage tp_security;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_logs;
        private HeaderControl hc_security;
        private System.Windows.Forms.TextBox txt_output_security;
        private System.Windows.Forms.Button btn_port_scan;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_firewall;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_port_scan_target;
        private System.Windows.Forms.TextBox txt_port_number;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TabPage tp_maintenance;
        private System.Windows.Forms.Panel panel4;
        private HeaderControl hc_maintenance;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btn_system_shutdown;
        private System.Windows.Forms.TextBox txt_output_maintenance;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btn_restart_system;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}