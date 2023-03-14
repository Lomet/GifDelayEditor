using System.Drawing;
using System.Drawing.Imaging;

namespace GifsineMaker
{
    public class GifLoader
    {
        public List<GifFrame> Frames { get; set; } = new();
        public int Count => Frames.Count;
        public double Average => Frames.Select(T => T.Delay).Average();

        /// <summary>
        /// Loads the GIF file into a list of GifFrame objects
        /// </summary>
        /// <param name="inputFile">The path of the input GIF file</param>
        public GifLoader(string inputFile)
        {
            if (!File.Exists(inputFile))
            {
                throw new FileNotFoundException("Input file not found.", inputFile);
            }

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

        /// <summary>
        /// Adds a reversed copy of the frames in the GIF file to the current frames list.
        /// </summary>
        /// <param name="needSkip">Whether or not to skip the first frame after reversing (default: true)</param>
        public void AddReverse(bool needSkip = true)
        {
            var temp = new List<GifFrame>(Frames);
            temp.Reverse();
            Frames.AddRange(temp.Skip(needSkip ? 1 : 0));
        }
    }
}
