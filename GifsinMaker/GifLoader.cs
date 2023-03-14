using System.Drawing;
using System.Drawing.Imaging;

namespace GifsinMaker
{
    public class GifLoader
    {
        public List<GifFrame> Frames { get; set; } = new();
        public int Count => Frames.Count;
        public double Average => Frames.Select(T => T.Delay).Average();
        public GifLoader(string inputFile)
        {
            // Load the GIF file into a list of GifFrame objects
            using (Image gifImage = Image.FromFile(inputFile))
            {
                FrameDimension dimension = new FrameDimension(gifImage.FrameDimensionsList[0]);
                int frameCount = gifImage.GetFrameCount(dimension);
                for (int i = 0; i < frameCount; i++)
                {
                    gifImage.SelectActiveFrame(dimension, i);
                    Image frame = new Bitmap(gifImage.Width, gifImage.Height);
                    Graphics.FromImage(frame).DrawImage(gifImage, Point.Empty);
                    int delay = gifImage.GetPropertyItem(0x5100).Value[0] * 10; // get delay in milliseconds
                    Frames.Add(new GifFrame(frame, delay));
                }
            }
        }
        public void AddReverse()
        {
            var temp = new List<GifFrame>(Frames);
            temp.Reverse();
            Frames.AddRange(temp.Skip(1));
        }
    }
}
