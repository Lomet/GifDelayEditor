namespace TestGifSineMaker;

public class TestSineWave
{
    [Fact]
    public void GifSineWave_CreatesSineWaveWithCorrectParameters()
    {
        // Arrange
        int frameCount = 10;
        double maxDelay = 100;
        double min = 20;
        int value = 50;
        double startAngle = 0;

        // Act
        GifSineWave sineWave = new GifSineWave(frameCount, maxDelay, min, value, startAngle);

        // Assert
        Assert.Equal(frameCount, sineWave.Count);
        foreach (int delay in sineWave)
        {
            Assert.True(delay >= min);
        }
    }

}
