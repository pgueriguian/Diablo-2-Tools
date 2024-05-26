using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Diablo2Tools.OCR
{
    public class ScreenCapture
    {
        public Bitmap CaptureScreen()
        {
            Rectangle bounds = Screen.PrimaryScreen.Bounds;
            Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
            }
            return bitmap;
        }
    }
}
