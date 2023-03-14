using System.Drawing.Imaging;
using System.Drawing;

namespace GifsinMaker
{
    public class GifLoader
    {
        public List<Image> Frames { get; set; } = new();
        public GifLoader(string inputFile)
        {
            // Load the GIF file into a list of Image objects
            using (Image gifImage = Image.FromFile(inputFile))
            {
                FrameDimension dimension = new FrameDimension(gifImage.FrameDimensionsList[0]);
                int frameCount = gifImage.GetFrameCount(dimension);
                for (int i = 0; i < frameCount; i++)
                {
                    gifImage.SelectActiveFrame(dimension, i);
                    Image frame = new Bitmap(gifImage.Width, gifImage.Height);
                    Graphics.FromImage(frame).DrawImage(gifImage, Point.Empty);
                    Frames.Add(frame);
                }
            }
        }
    }
}
