using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using Microsoft.Win32;

namespace WarZ_Cleaner
{
    public partial class MainFormSelect : KryptonForm
    {
        private const int WM_NCHITTEST = 0x84;
        private const int HT_CAPTION = 0x2;
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        public MainFormSelect()
        {
            InitializeComponent();
            SendPing();
            // Buttons
            btnDeleteLogs.Visible = false;
        }

        private async void SendPing()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var content = new StringContent("");
                    await client.PostAsync(@"https://api.drooptje.com/v1/pings/cacheCleaner/index.php?ping=1", content); // send empty post to track app activity
                }
            }
            catch { }
        }

        // Scan Logfiles and Folders
        private void btnScan_Click(object sender, EventArgs e)
        {
            checkedListBoxAppdata.Items.Clear(); // Lösche alle vorhandenen Einträge in der CheckBoxList

            string dayzLogDir = GetDayzLogDirectory();

            if (!Directory.Exists(dayzLogDir))
            {
                MessageBox.Show("No Dayz Directorys have been found.");
                return;
            }

            try
            {
                string gameInstallPath = GameDirRegistryPath(); // Aufruf der Methode GameDirRegistryPath, nicht als Eigenschaft

                if (string.IsNullOrEmpty(gameInstallPath))
                {
                    MessageBox.Show($"Installationspfad von DayZ konnte nicht gefunden werden.");
                    checkBoxGamePath.Checked = false;
                }
                else
                {
                    checkBoxGamePath.Checked = true; // Setze das Kontrollkästchen auf true
                    MessageBox.Show($"Spielepfad: {gameInstallPath}", "Spielepfad");
                }

                // Durchsuche alle Unterverzeichnisse des DayZ-Verzeichnisses
                string[] subDirectories = Directory.GetDirectories(dayzLogDir);
                foreach (string subDir in subDirectories)
                {
                    // Extrahiere den Ordnernamen aus dem vollständigen Pfad
                    string folderName = Path.GetFileName(subDir);

                    // Überprüfe, ob der Ordnername in der Liste der auszuschließenden Ordner enthalten ist
                    if (!IsExcludedFolder(folderName))
                    {
                        // Füge den Ordner der CheckBoxList hinzu, wenn er nicht ausgeschlossen ist
                        checkedListBoxAppdata.Items.Add(folderName);
                    }
                }

                // Wähle alle Elemente in der CheckBoxList aus
                for (int i = 0; i < checkedListBoxAppdata.Items.Count; i++)
                {
                    checkedListBoxAppdata.SetItemChecked(i, true);
                }

                // Ausblenden des btnScan und Anzeigen des btnDeleteLogs
                btnScan.Visible = false;
                btnDeleteLogs.Visible = true;

                // Aktualisieren der Liste checkedListBoxProfiles
                UpdateCheckedListBoxProfiles();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error {ex.Message}");
            }
        }

        private void UpdateCheckedListBoxProfiles()
        {
            checkedListBoxProfiles.Items.Clear(); // Lösche alle vorhandenen Einträge in der CheckBoxList

            // GameDirRegistryPath sollte den gewünschten Pfad enthalten
            string gameInstallPath = GameDirRegistryPath();

            if (string.IsNullOrEmpty(gameInstallPath))
            {
                MessageBox.Show($"Der Pfad konnte nicht gefunden werden.");
                return;
            }

            string profilesPath = Path.Combine(gameInstallPath, "Profiles");

            try
            {
                // Überprüfe, ob das Profiles-Verzeichnis existiert
                if (Directory.Exists(profilesPath))
                {
                    // Durchsuche alle Unterordner des Profiles-Verzeichnisses
                    string[] subDirectories = Directory.GetDirectories(profilesPath);
                    foreach (string subDir in subDirectories)
                    {
                        // Überprüfe, ob der Ordner Logdateien enthält
                        if (Directory.GetFiles(subDir, "*.log").Length > 0 ||
                            Directory.GetFiles(subDir, "*.RPT").Length > 0 ||
                            Directory.GetFiles(subDir, "*.mdmp").Length > 0 ||
                            Directory.GetFiles(subDir, "log_*").Length > 0 ||
                            Directory.GetFiles(subDir, "_log*").Length > 0)
                        {
                            // Füge den Namen des Unterordners der CheckBoxList hinzu
                            string folderName = Path.GetFileName(subDir);
                            checkedListBoxProfiles.Items.Add(folderName);
                        }
                    }

                    if (checkedListBoxProfiles.Items.Count == 0)
                    {
                        MessageBox.Show($"Keine Unterordner mit den angegebenen Dateien wurden im angegebenen Verzeichnis gefunden.");
                    }
                }
                else
                {
                    MessageBox.Show($"Das Profiles-Verzeichnis wurde nicht gefunden.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Suchen nach Unterordnern: {ex.Message}");
            }
        }


        // Überprüfe, ob der Ordnername in der Liste der auszuschließenden Ordner enthalten ist
        private bool IsExcludedFolder(string folderName)
        {
            string[] excludedFolders = { "BattlEye", "DataCache" };
            return excludedFolders.Contains(folderName);
        }

        private async void btnDeleteLogs_Click(object sender, EventArgs e)
        {
            string dayzLogDir = GetDayzLogDirectory();

            if (!Directory.Exists(dayzLogDir))
            {
                MessageBox.Show("No Dayz Directorys have been found.");
                return;
            }
            try
            {
                await CleanLogsAsync(dayzLogDir);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error {ex.Message}");
            }
        }

        private string GetDayzLogDirectory()
        {
            string localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData); // Get LocalAppData path
            string dayZPath = Path.Combine(localAppData, "DayZ"); // get DayZ path

            return dayZPath;
        }

        private async Task CleanLogsAsync(string directory)
        {
            Cursor = Cursors.WaitCursor;
            int count = await Task.Run(() => DeleteFiles(directory));
            Cursor = Cursors.Default;

            if (count == 0)
            {
                MessageBox.Show("No files have been found!");
            }
            else
            {
                MessageBox.Show($"{count} Files have been found and deleted!");
            }
        }

        private int DeleteFiles(string directory)
        {
            int count = 0;

            try
            {
                foreach (string filePath in Directory.EnumerateFiles(directory))
                {
                    if (!IsExcludedFolder(Path.GetDirectoryName(filePath))) // Überprüfe, ob das Verzeichnis ausgeschlossen ist
                    {
                        if (IsLogFileType(Path.GetFileName(filePath)))
                        {
                            File.Delete(filePath);
                            count++;
                        }
                    }
                }

                foreach (string subDir in Directory.EnumerateDirectories(directory))
                {
                    if (!IsExcludedFolder(Path.GetFileName(subDir))) // Überprüfe, ob das Verzeichnis ausgeschlossen ist
                    {
                        count += DeleteFiles(subDir);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing directory {directory}: {ex.Message}");
            }

            return count;
        }

        private bool IsLogFileType(string filePath)
        {
            filePath = filePath.ToLowerInvariant(); // convert to lowercase
            string extension = Path.GetExtension(filePath); // get file extension

            return extension.Equals(".RPT", StringComparison.OrdinalIgnoreCase) ||
                   extension.Equals(".mdmp", StringComparison.OrdinalIgnoreCase) ||
                   extension.Equals(".log", StringComparison.OrdinalIgnoreCase) ||
                   filePath.StartsWith("log_") && extension.Equals(".txt") ||
                   int.TryParse(extension.TrimStart('.'), out _); // check if extension is a number e.g. ".log.1"
        }

        private void lblPatreon_LinkClicked(object sender, EventArgs e)
        {
            Process.Start("https://www.patreon.com/WarZDayZ");
        }

        private void lblDiscord_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.discord.gg/WarZDayZ");
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checkedListBoxAppData_SelectedIndexChanged(object sender, EventArgs e)
        {
            StringBuilder selectedDirectories = new StringBuilder();

            // Durchlaufe alle ausgewählten Elemente in der checkedListBoxForMods
            foreach (var selectedItem in checkedListBoxAppdata.CheckedItems)
            {
                // Füge den Pfad des ausgewählten Elements zur selectedDirectories-StringBuilder hinzu
                selectedDirectories.AppendLine(selectedItem.ToString());
            }
        }

        private void checkedListBoxProfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkedListBoxProfiles.Items.Clear(); // Lösche alle vorhandenen Einträge in der CheckBoxList

            string gameDirPath = GameDirRegistryPath();

            if (string.IsNullOrEmpty(gameDirPath))
            {
                MessageBox.Show($"Der Pfad konnte nicht gefunden werden.");
                return;
            }

            try
            {
                string[] subDirectories = Directory.GetDirectories(gameDirPath);
                foreach (string subDir in subDirectories)
                {
                    // Füge den Ordner der CheckBoxList hinzu
                    checkedListBoxProfiles.Items.Add(subDir);
                }

                if (checkedListBoxProfiles.Items.Count == 0)
                {
                    MessageBox.Show($"Keine Ordner wurden im angegebenen Verzeichnis gefunden.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Suchen nach Ordnern: {ex.Message}");
            }
        }
        internal static string SearchForDayZRegistryPath()
        {
            string registryKeyPath = @"Local Settings\Software\Microsoft\Windows\Shell\MuiCache";
            using (RegistryKey key = Registry.ClassesRoot.OpenSubKey(registryKeyPath))
            {
                if (key != null)
                {
                    foreach (string valueName in key.GetValueNames())
                    {
                        if (valueName.Contains(@"\DayZ\DayZ_x64.exe"))
                        {
                            return RemoveFriendlyAppName(valueName);
                        }
                    }
                }
            }
            return null;
        }
        // Methode zum Entfernen des ".FriendlyAppName"-Teils vom Pfad
        private static string RemoveFriendlyAppName(string path)
        {
            const string friendlyAppName = ".FriendlyAppName";
            int index = path.IndexOf(friendlyAppName);
            if (index >= 0)
            {
                return path.Substring(0, index);
            }
            return path;
        }
        internal static string GameDirRegistryPath()
        {
            string registryKeyPath = @"Local Settings\Software\Microsoft\Windows\Shell\MuiCache";
            using (RegistryKey key = Registry.ClassesRoot.OpenSubKey(registryKeyPath))
            {
                if (key != null)
                {
                    foreach (string valueName in key.GetValueNames())
                    {
                        if (valueName.Contains(@"\DayZ\DayZ_x64.exe"))
                        {
                            return RemoveFriendlyAppNameComplete(valueName);
                        }
                    }
                }
            }
            return null;
        }
        private static string RemoveFriendlyAppNameComplete(string path)
        {
            const string friendlyAppName = "\\DayZ_x64.exe.FriendlyAppName";
            int index = path.IndexOf(friendlyAppName);
            if (index >= 0)
            {
                return path.Substring(0, index);
            }
            return path;
        }
        private void checkBoxGamePath_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void btnClose_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
