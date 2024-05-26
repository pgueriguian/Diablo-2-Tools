using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using AForge.Imaging;
using AForge.Imaging.Filters;
using Diablo2Tools.OCR;
using Timer = System.Windows.Forms.Timer;

namespace Diablo2Tools
{
    public partial class Form1 : Form
    {
        private NotifyIcon notifyIcon;
        private ContextMenuStrip contextMenu;
        private ToolStripMenuItem exitMenuItem;

        public Form1()
        {
            InitializeComponent();

            // Set the form to be topmost and transparent
            TopMost = true;
            FormBorderStyle = FormBorderStyle.None;
            BackColor = Color.Teal; // Set the transparent color
            TransparencyKey = BackColor;

            resetBtn.BackColor = Color.Teal;
            resetBtn.ForeColor = Color.Yellow;

            // Set the size and position of the form
            Width = 200;
            Height = 200;
            // Set the position of the form to the top-left corner of the screen
            StartPosition = FormStartPosition.Manual;
            Location = new Point(0, 0);
            // Set up a timer to update the counter
            //Timer timer = new Timer();
            //timer.Interval = 1000; // 1 second interval
            //timer.Tick += Timer_Tick;
            //timer.Start();
            Icon whiteSquareIcon = CreateWhiteSquareIcon(16, 16);
            notifyIcon = new NotifyIcon();
            contextMenu = new ContextMenuStrip();
            exitMenuItem = new ToolStripMenuItem("Exit");
            notifyIcon.Icon = whiteSquareIcon;
            notifyIcon.Text = "D2 run counter";
            notifyIcon.Visible = true;  // Make the icon visible in the system tray
            // Add context menu items
            contextMenu.Items.Add(exitMenuItem);
            notifyIcon.ContextMenuStrip = contextMenu;

            // Handle events
            notifyIcon.MouseClick += NotifyIcon_MouseClick;
            exitMenuItem.Click += ExitMenuItem_Click;

        }
        private Icon CreateWhiteSquareIcon(int width, int height)
        {
            // Create a Bitmap and fill it with white color
            Bitmap bitmap = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.Yellow);
            }

            // Convert the Bitmap to an Icon
            IntPtr hIcon = bitmap.GetHicon();
            Icon icon = Icon.FromHandle(hIcon);

            return icon;
        }

        public async Task DetectLoadingScreen()
        {
            ScreenCapture screenCapture = new ScreenCapture();
            //LoadingScreenDetector loadingScreenDetector = new LoadingScreenDetector();
            ScreenLoadingBlobDetector loadingScreenDetector = new ScreenLoadingBlobDetector();

            while (true)
            {
                Bitmap screenshot = screenCapture.CaptureScreen();
                if (loadingScreenDetector.IsLoadingScreen(screenshot))
                {
                    // Safely update the UI
                    UpdateRunCountLabel();
                    await Task.Delay(6000); // Adjust sleep time based on loading screen duration
                }
                await Task.Delay(100); // Adjust as needed for your detection frequency
            }
        }

        public async Task ViewBlobs()
        {
            ScreenCapture screenCapture = new ScreenCapture();
            //LoadingScreenDetector loadingScreenDetector = new LoadingScreenDetector();
            ScreenLoadingBlobDetector loadingScreenDetector = new ScreenLoadingBlobDetector();
            ImageSaver imageSaver = new ImageSaver();
            while (true)
            {
                await Task.Delay(5000); // Adjust as needed for your detection frequency
                Bitmap screenshot = screenCapture.CaptureScreen();
                var result = loadingScreenDetector.VisualizeBlobs(screenshot);
                string fileName = $"image_{DateTime.Now:yyyyMMddHHmmss}.png";
                System.Drawing.Imaging.ImageFormat format = System.Drawing.Imaging.ImageFormat.Png;
                imageSaver.SaveBitmapToRoot(result, fileName, format);
                break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Task.Run(() => DetectLoadingScreen());
            //Task.Run(() => ViewBlobs());
        }

        private void UpdateRunCountLabel()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => UpdateRunCountLabel()));
            }
            else
            {
                //SystemSounds.Asterisk.Play();
                runCounter.Value++;
                labelCounter.Text = runCounter.Value.ToString();
            }
        }



        private void Timer_Tick(object sender, EventArgs e)
        {
            // Update the counter text
            labelCounter.Text = $"Counter: {DateTime.Now.Second}";
        }

        private void resetBtn_Click_1(object sender, EventArgs e)
        {
            runCounter.Value = 0;
            labelCounter.Text = runCounter.Value.ToString();
        }
        private void NotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MessageBox.Show("Notify icon clicked!");
            }
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            notifyIcon.Visible = false; // Hide the icon when the form closes
        }
    }
}
