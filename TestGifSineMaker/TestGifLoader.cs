namespace GifsineMaker.Tests
{
    public class GifLoaderTests
    {
        private static byte[] TestData => new byte[] { 71, 73, 70, 56, 57, 97, 2, 0, 2, 0, 128, 0, 0, 255, 255, 255, 0, 0, 0, 33, 249, 4, 9, 5, 0, 2, 0, 44, 0, 0, 0, 0, 2, 0, 2, 0, 0, 2, 7, 140, 69, 0, 59 };

        //[Fact]
        //public void Constructor_LoadsGifIntoFramesList()
        //{
        //    // Arrange
        //    string inputFile = "test.gif";
        //    File.WriteAllBytes(inputFile, TestData);

        //    // Act
        //    GifLoader gifLoader = new(inputFile);

        //    // Assert
        //    Assert.NotNull(gifLoader);
        //    Assert.Single(gifLoader.Frames);
        //}

        //[Fact]
        //public void Constructor_AddReverse()
        //{
        //    // Arrange
        //    string inputFile = "test.gif";
        //    File.WriteAllBytes(inputFile, TestData);

        //    // Act
        //    GifLoader gifLoader = new(inputFile);
        //    gifLoader.AddReverse(false);

        //    // Assert
        //    Assert.NotNull(gifLoader);
        //    Assert.Equal(2, gifLoader.Frames.Count);
        //}

        [Fact]
        public void Constructor_ThrowsFileNotFoundException_WhenInputFileDoesNotExist()
        {
            // Arrange
            string inputFile = "nonexistent.gif";

            // Act and assert
            Assert.Throws<FileNotFoundException>(() => new GifLoader(inputFile));
        }

        //[Fact]
        //public void TestGifMaker()
        //{
        //    // Create a test GIF file with 3 frames, each with a delay of 100 ms
        //    string inputFile = "test_input.gif";
        //    using (Image gifImage = new Bitmap(100, 100))
        //    using (GifCreator creator = AnimatedGif.Create(inputFile, 100))
        //    {
        //        creator.AddFrame(gifImage, 100);
        //        creator.AddFrame(gifImage, 100);
        //        creator.AddFrame(gifImage, 100);
        //    }

        //    // Create a GifMaker object with the test input file
        //    GifMaker maker = new(inputFile,false);

        //    // Modify the delays using a sine wave with maxDelayRatio = 1 and speedUpRatio = 1
        //    maker.NewDelays(1, 1);

        //    // Save the modified GIF to an output file
        //    string outputFile = "test_output.gif";
        //    maker.SaveGif(outputFile);

        //    // Load the output file using the GifLoader class
        //    GifLoader loader = new(outputFile);

        //    // Verify that the output file has the expected properties
        //    Assert.Equal(6, loader.Count); // 3 original frames + 3 reversed frames
        //    Assert.Equal(100, loader.Frames[0].Delay); // first frame should have the same delay as before
        //    Assert.True(loader.Frames.Skip(1).Select(f => f.Delay).All(d => d >= 0)); // all other delays should be non-negative
        //}
    }
}
