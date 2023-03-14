using GifMotion;
using System.Drawing;

namespace GifsinMaker
{
    public class GifMaker
    {
        private List<GifData> Gifs { get; set; } = new();
        public GifMaker(List<Image> images, List<int> deleys)
        {
            if (deleys.Count != images.Count) throw new ArgumentOutOfRangeException(nameof(images));
            for (int i = 0; i < deleys.Count; i++)
            {
                Gifs.Add(new(images[i], deleys[i]));
            }
        }
        public void SaveGif(string outputFile)
        {
            if (!Gifs.Any()) throw new MissingMemberException(nameof(Gifs));
            // Create a new GifCreator object with the adjusted delays
            using (GifCreator creator = AnimatedGif.Create(outputFile, 0))
            {
                int i = 0; 
                // Add the frames to the GifCreator object with the adjusted delays
                foreach (var item in Gifs)
                {
                    creator.AddFrame(item.Frame, item.Delay*10); // the *10 to make it into ms
                }
            }
        }
    }
}
