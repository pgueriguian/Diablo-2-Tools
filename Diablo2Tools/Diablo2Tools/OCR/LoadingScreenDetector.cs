using AForge.Imaging.Filters;
using AForge.Imaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;

namespace Diablo2Tools.OCR
{
    public class LoadingScreenDetector
    {
        private Bitmap loadingScreenTemplate;

        public LoadingScreenDetector()
        {
            string templatePath = @"C:\Users\super\source\repos\Diablo2Tools\Diablo2Tools\LoadingScreenTemplate.png";
            loadingScreenTemplate = new Bitmap(templatePath);
        }

        public bool IsLoadingScreen(Bitmap screenshot)
        {
            // Convert images to grayscale
            Grayscale grayscaleFilter = new Grayscale(0.2125, 0.7154, 0.0721);
            Bitmap grayScreenshot = grayscaleFilter.Apply(screenshot);
            Bitmap grayTemplate = grayscaleFilter.Apply(loadingScreenTemplate);

            // Template matching
            ExhaustiveTemplateMatching templateMatching = new ExhaustiveTemplateMatching(0.98f);
            TemplateMatch[] matches = templateMatching.ProcessImage(grayScreenshot, grayTemplate);

            return matches.Length > 0;
        }

    }
}
