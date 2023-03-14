using GifMotion;
using System.Drawing;

namespace GifsineMaker.Tests;

public class GifLoaderTests : IDisposable
{
    private readonly string _testInputFile;
    private readonly string _testOutputFile;

    public GifLoaderTests()
    {
        _testInputFile = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}.gif");
        _testOutputFile = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}.gif");
        using (var gifImage = new Bitmap(100, 100))
        {
            using var creator = AnimatedGif.Create(_testInputFile, 100);
            creator.AddFrame(gifImage, 100);
            creator.AddFrame(gifImage, 100);
            creator.AddFrame(gifImage, 100);
        }
    }

    [Fact]
    public void Constructor_LoadsGifIntoFramesList()
    {
        // Act
        GifLoader gifLoader = new(_testInputFile);

        // Assert
        Assert.NotNull(gifLoader);
        Assert.Equal(3, gifLoader.Count);
    }

    [Fact]
    public void Constructor_AddReverse()
    {
        // Act
        GifLoader gifLoader = new(_testInputFile);
        gifLoader.AddReverse(false);

        // Assert
        Assert.NotNull(gifLoader);
        Assert.Equal(6, gifLoader.Frames.Count);
    }

    [Fact]
    public void Constructor_ThrowsFileNotFoundException_WhenInputFileDoesNotExist()
    {
        // Arrange
        string inputFile = "nonexistent.gif";

        // Act and assert
        Assert.Throws<FileNotFoundException>(() => new GifLoader(inputFile));
    }

    [Fact]
    public void TestGifMaker()
    {
        // Create a GifMaker object with the test input file
        GifMaker maker = new(_testInputFile, false);

        // Modify the delays using a sine wave with maxDelayRatio = 1 and speedUpRatio = 1
        maker.NewDelays(1, 1);

        // Save the modified GIF to an output file
        maker.SaveGif(_testOutputFile);

        // Load the output file using the GifLoader class
        GifLoader loader = new(_testOutputFile);

        // Verify that the output file has the expected properties
        Assert.Equal(6, loader.Count); // 3 original frames + 3 reversed frames
        Assert.Equal(100, loader.Frames[0].Delay); // first frame should have the same delay as before
        Assert.True(loader.Frames.Skip(1).Select(f => f.Delay).All(d => d >= 0)); // all other delays should be non-negative
    }

    public void Dispose()
    {
        File.Delete(_testInputFile);
        File.Delete(_testOutputFile);
    }
}
