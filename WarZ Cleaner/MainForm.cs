using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace WarZ_Cleaner
{
    public partial class MainForm : KryptonForm
    {

        /*
        |      Made with <3 by Dutchcoder for WarZ DayZ
        |
        |      made this in a hurry so dont say its messy 
        |   respect my work and dont rename it for ur server
        |
        */

        private const int WM_NCHITTEST = 0x84;
        private const int HT_CAPTION = 0x2;
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        public MainForm()
        {
            InitializeComponent();
            SendPing();
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
        // allows u to move the app arrount when u click and hold on the header
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
        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCHITTEST, (IntPtr)HT_CAPTION, IntPtr.Zero);
            }
        }
        private async void btnClean_Click(object sender, EventArgs e)
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
                MessageBox.Show("No fils have been found!");
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
                    if (IsLogFileType(Path.GetFileName(filePath)))
                    {
                        File.Delete(filePath);
                        count++;
                    }
                }

                foreach (string subDir in Directory.EnumerateDirectories(directory))
                {
                    count += DeleteFiles(subDir);
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
            string extention = Path.GetExtension(filePath); // get file extention

            return extention.Equals(".RPT", StringComparison.OrdinalIgnoreCase) ||
                   extention.Equals(".mdmp", StringComparison.OrdinalIgnoreCase) ||
                   extention.Equals(".log", StringComparison.OrdinalIgnoreCase) ||
                   filePath.StartsWith("log_") && extention.Equals(".txt") ||
                   int.TryParse(extention.TrimStart('.'), out _); // check if extentiosn is a number eg".log.1"
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
    }
}
