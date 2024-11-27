using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text.Json;
using ComponentFactory.Krypton.Toolkit;
using Microsoft.Win32;
using Windows.Media.Protection.PlayReady;

namespace WarZ_Cleaner
{
    public partial class MainForm : KryptonForm
    {

        /*
        |       Made with <3 by DutchCoder for WarZ DayZ
        |
        |       made this in an hour so it's a little messy 
        |       please respect my work by not renaming it for ur server
        |
        */

        // Dragging functionality
        private const int WM_NCHITTEST = 0x84;
        private const int HT_CAPTION = 0x2;
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        private bool noGui;

        public MainForm(bool noGui)
        {
            this.noGui = noGui;
            InitializeComponent();
            
            if (noGui) 
            {
                btnClean_Click(null, null);
            }
        }
        // Check for updates
        private async void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("User-Agent", "WarZ-Cleaner");

                    // Get github repository data to check for new release
                    HttpResponseMessage response = await client.GetAsync(@"https://api.github.com/repos/DutchCoder420/WarZ-Cleaner/releases/latest");
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonContent = await response.Content.ReadAsStringAsync();

                        // Compare the version receaved by github with current version
                        var jsonDoc = JsonDocument.Parse(jsonContent);
                        if (jsonDoc.RootElement.TryGetProperty("tag_name", out var tagProperty) && tagProperty.GetString() != "1.0.0")
                        {
                            // If there is a new version show the update label
                            lblUpdate.Visible = true;
                        }
                    }
                }
            }
            catch { }
        }
        // Method to get the directory path of the DayZ game from the registry
        internal static string GameDirRegistryPath()
        {
            // Define the registry key path where DayZ executable information is stored
            string registryKeyPath = @"Local Settings\Software\Microsoft\Windows\Shell\MuiCache";

            // Open the registry key for reading
            using (RegistryKey key = Registry.ClassesRoot.OpenSubKey(registryKeyPath))
            {
                // Check if the key exists
                if (key != null)
                {
                    // Iterate through all the value names under the registry key
                    foreach (string valueName in key.GetValueNames())
                    {
                        // Check if the value name contains the path to DayZ executable
                        if (valueName.Contains(@"\DayZ\DayZ_x64.exe.FriendlyAppName", StringComparison.OrdinalIgnoreCase))
                        {
                            // Return the directory path of DayZ executable
                            return Path.GetDirectoryName(RemoveFriendlyAppNameComplete(valueName));
                        }
                    }
                }
            }
            return null; // Return null if the DayZ executable path is not found in the registry
        }
        // Helper method to remove the friendly app name from the registry value
        private static string RemoveFriendlyAppNameComplete(string path)
        {
            const string friendlyAppName = "\\DayZ_x64.exe.FriendlyAppName";
            const string targetFolder = "\\DayZ";

            // Find the index of the friendly app name suffix in the path
            int suffixIndex = path.LastIndexOf(friendlyAppName);
            if (suffixIndex >= 0)
            {
                // Find the index of the last occurrence of the target folder in the path
                int folderIndex = path.LastIndexOf(targetFolder);
                if (folderIndex >= 0)
                {
                    return path.Substring(0, folderIndex + targetFolder.Length);
                }
            }
            return path;
        }

        // Method to get the directory path of the DayZ logs
        private string GetDayzLogDirectory()
        {
            // Get the path to the LocalApplicationData folder
            string localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            // Combine the LocalApplicationData path with the "DayZ" folder name
            return Path.Combine(localAppData, "DayZ");
        }
        // Method to clean log files asynchronously
        private async Task CleanLogsAsync(string directory)
        {
            Cursor = Cursors.WaitCursor; // Set the cursor to a wait cursor
            int count = await Task.Run(() => DeleteFiles(directory)); // Asynchronously delete files in the specified directory
            Cursor = Cursors.Default; // Set the cursor back to the default cursor

            if (!noGui)
            {
                // Display a message box indicating the number of files deleted
                if (count == 0)
                {
                    MessageBox.Show("No files have been found!");
                }
                else
                {
                    MessageBox.Show($"{count} Files have been found and deleted!");
                }
            }
            else
            {
                Application.Exit();
            }
        }
        // Method to recursively delete log files in a directory
        private int DeleteFiles(string directory)
        {
            int count = 0;

            try
            {
                // Iterate through all files in the specified directory
                foreach (string filePath in Directory.EnumerateFiles(directory))
                {
                    // Check if the file is a log file and delete it
                    if (IsLogFileType(Path.GetFileName(filePath)))
                    {
                        File.Delete(filePath);
                        count++;
                    }
                }

                // Recursively iterate through all subdirectories and delete log files
                foreach (string subDir in Directory.EnumerateDirectories(directory))
                {
                    count += DeleteFiles(subDir);
                }
            }
            catch (Exception ex)
            {
                // Show an error message if an exception occurs while processing a directory
                MessageBox.Show($"Error processing directory {directory}: {ex.Message}");
            }

            return count; // Return the total count of files deleted
        }
        // Method to determine if a file is a log file based on its name and extension
        private bool IsLogFileType(string filePath)
        {
            // Convert the file path to lowercase to ensure case-insensitive comparison
            filePath = filePath.ToLowerInvariant();

            // Get the file extension
            string extention = Path.GetExtension(filePath);

            // Check if the file extension matches common log file extensions, ignoring case sensitivity
            return extention.Equals(".RPT", StringComparison.OrdinalIgnoreCase) ||          // .RPT extension
                   extention.Equals(".mdmp", StringComparison.OrdinalIgnoreCase) ||         // .mdmp extension
                   extention.Equals(".log", StringComparison.OrdinalIgnoreCase) ||          // .log extension
                   extention.Equals(".ch", StringComparison.OrdinalIgnoreCase) ||           // .ch extension
                   filePath.StartsWith("log_") && extention.Equals(".txt") ||               // File name starts with "log_" and has .txt extension
                   filePath.EndsWith("_log") && extention.Equals(".txt") ||                 // File name ends with "_log" and has .txt extension
                   int.TryParse(extention.TrimStart('.'), out _);                           // Check if extension can be parsed as an integer (e.g., ".log.1")
        }
        // Text Labels
        private void lblPatreon_LinkClicked(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://www.patreon.com/WarZDayZ") { UseShellExecute = true });
        }
        private void lblDiscord_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://www.discord.gg/WarZDayZ") { UseShellExecute = true });
        }
        private void lblUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://github.com/DutchCoder420/WarZ-Cleaner/releases/latest") { UseShellExecute = true });
        }
        // Buttons
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private async void btnClean_Click(object sender, EventArgs e)
        {
            string dayzLogDir = GetDayzLogDirectory();

            if (!Directory.Exists(dayzLogDir))
            {
                MessageBox.Show("No Dayz Directories have been found.");
                return;
            }
            try
            {
                // Get the game installation directory path from the registry
                string gameInstallPath = GameDirRegistryPath();

                if (!string.IsNullOrEmpty(gameInstallPath))
                {
                    if (Directory.Exists(Path.Combine(gameInstallPath, "profiles")))
                    {
                        // Append the "profiles" folder to the game installation directory path
                        dayzLogDir = Path.Combine(gameInstallPath, "profiles");
                    }
                }

                // Clean the log files asynchronously
                await CleanLogsAsync(dayzLogDir);
            }
            catch (Exception ex)
            {
                // Display an error message if an exception occurs
                MessageBox.Show($"Error {ex.Message}");
            }
        }
        // Method to enable dragging of the form by clicking on the header
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
            {
                if (MouseButtons == MouseButtons.None)
                {
                    Point cursor = PointToClient(Cursor.Position);
                    if (cursor.Y <= 30)
                    {
                        m.Result = (IntPtr)HT_CAPTION;
                    }
                }
            }
        }
    }
}
