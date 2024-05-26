using AForge.Imaging.Filters;
using AForge.Imaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diablo2Tools.OCR
{
    internal class ScreenLoadingBlobDetector
    {
        private BlobCounter blobCounter;
        private int intensity = 255;

        public ScreenLoadingBlobDetector()
        {
            blobCounter = new BlobCounter();
        }

        public bool IsLoadingScreen(Bitmap screenshot)
        {
            ExtractChannel extractChannelFilter = new ExtractChannel(RGB.B);
            Bitmap redChannel = extractChannelFilter.Apply(screenshot);

            Threshold thresholdFilter = new Threshold(intensity); // Adjust threshold value as needed
            Bitmap binaryRedChannel = thresholdFilter.Apply(redChannel);

            // Initialize blob counter
            blobCounter.ProcessImage(binaryRedChannel);
            Blob[] blobs = blobCounter.GetObjectsInformation();

            // Filter blobs based on size or other criteria
            if (blobs.Count() != 4) return false;
            foreach (Blob blob in blobs)
            {
                if (blob.Rectangle.X < 850 || blob.Rectangle.X > 1070 || blob.Rectangle.Y < 575 || blob.Rectangle.Y > 585)
                {
                    return false; 
                }
            }


            return true; 
        }

        public Bitmap VisualizeBlobs(Bitmap inputImage)
        {
            ExtractChannel extractChannelFilter = new ExtractChannel(RGB.B);
            Bitmap redChannel = extractChannelFilter.Apply(inputImage);

            Threshold thresholdFilter = new Threshold(intensity); // Adjust threshold value as needed
            Bitmap binaryRedChannel = thresholdFilter.Apply(redChannel);

            // Initialize blob counter
            blobCounter.ProcessImage(binaryRedChannel);
            Blob[] blobs = blobCounter.GetObjectsInformation();

            // Create a new bitmap to draw blobs
            Bitmap resultImage = new Bitmap(inputImage);

            // Draw outlines or bounding boxes around blobs
            Graphics g = Graphics.FromImage(resultImage);
            Pen pen = new Pen(Color.Red, 1); // Customize the color and width of outlines

            foreach (Blob blob in blobs)
            {
                Rectangle rect = blob.Rectangle; // Get the bounding box of the blob
                g.DrawRectangle(pen, rect); // Draw the bounding box
            }

            pen.Dispose();
            g.Dispose();

            return resultImage;
        }
    }
}
