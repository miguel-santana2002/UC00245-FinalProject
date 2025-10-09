# Cyber Access Terminal

A multi-functional desktop application built with C# Windows Forms, styled as a retro, green-on-black 'Cyber Terminal'. This project simulates a diagnostic and control tool for system administrators and security enthusiasts.

## Features

The terminal is organized into four distinct tabs:

### 🌐 Network Diagnostics (Network)
* **PING HOST:** Robust utility for checking host reachability via Hostname or IP, including real-time output and full packet statistics (Min/Max/Avg time and loss percentage).
* **IP Configuration:** Command to display local network configuration details.
* **Active Ports:** (Placeholder for future port listing utility).

### 🖥️ System Health (System)
* **SYSTEM INFO:** Displays static hardware and OS information (OS Version, Processor Count, Total RAM, etc.).
* **CHECK HEALTH:** Real-time metrics on current CPU Load and RAM usage.
* **VIEW PROCESSES:** Lists all active processes (PID, CPU Time, and Memory Usage).

### 🔒 Security Analysis (Security)
* **PORT SCAN:** Tool to check the status (Open/Closed) of specific TCP ports on a given target IP or Hostname.
* **FIREWALL STATUS:** Executes a `netsh` command to retrieve and display the status of the Windows Firewall profiles.
* **ACTIVE LOGS:** Scans and reports recent critical errors and warnings from the Windows Event Viewer.

### 🛠️ System Maintenance (Maintenance)
* **SHUTDOWN / RESTART:** Critical commands to immediately power off or reboot the local system (with mandatory user confirmation).

## Export Functionality (New Feature!)
All generated reports and diagnostic outputs can be exported for archival and sharing:
* PDF Export: Directly export the terminal output to a PDF file format.
* Structured Reporting: Utilizes the iText 7 library for professional, structured PDF generation, ensuring reports are easily readable and ready for printing or digital archival.

## Styling & UX
* **Theme:** Retro-futuristic, green-on-black terminal aesthetic.
* **Custom UI:** Borderless window design with custom drag-and-drop movement functionality.
* **Header Control:** Reusable user control implemented for consistent user/logout status across all tabs.
