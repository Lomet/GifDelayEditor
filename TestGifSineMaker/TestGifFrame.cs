using System.Drawing;

namespace GifsineMaker.Tests;

public class GifFrameTests
{
    //[Fact]
    //public void Constructor_ShouldCreateGifFrameWithCorrectProperties()
    //{
    //    // Arrange
    //    Image frame = new Bitmap(100, 100);
    //    int delay = 100;

    //    // Act
    //    GifFrame gifFrame = new GifFrame(frame, delay);

    //    // Assert
    //    Assert.Equal(frame, gifFrame.Frame);
    //    Assert.Equal(delay, gifFrame.Delay);
    //}

    [Fact]
    public void Constructor_ShouldThrowException_WhenFrameIsNull()
    {
        // Arrange
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
        Image frame = null;
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
        int delay = 100;

        // Act & Assert
#pragma warning disable CS8604 // Possible null reference argument.
        _ = Assert.Throws<NullReferenceException>(() => new GifFrame(frame, delay));
#pragma warning restore CS8604 // Possible null reference argument.
    }
}
