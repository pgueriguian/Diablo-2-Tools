using System;
using System.Drawing;

public class ImageSaver
{
    public void SaveBitmapToRoot(Bitmap bitmap, string fileName, System.Drawing.Imaging.ImageFormat format)
    {
        // Get the current directory of the application
        string rootDirectory = AppDomain.CurrentDomain.BaseDirectory;

        // Combine the root directory with the file name
        string filePath = System.IO.Path.Combine(rootDirectory, fileName);

        // Save the bitmap to disk
        bitmap.Save(filePath, format);
    }
}
