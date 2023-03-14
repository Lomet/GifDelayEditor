using GifMotion;

namespace SineWaveGIF.Tests
{
    public class ProgramTests : IDisposable
    {
        private readonly string _testInputFile;
        private readonly string _testOutputFile;

        public ProgramTests()
        {
            _testInputFile = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}.gif");
            _testOutputFile = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}.gif");

            using (var gifImage = new System.Drawing.Bitmap(100, 100))
            {
                using (var gifCreator = AnimatedGif.Create(_testInputFile, 100, -1))
                {
                    gifCreator.AddFrame(gifImage, delay: 100);
                    gifCreator.AddFrame(gifImage, delay: 100);
                    gifCreator.AddFrame(gifImage, delay: 100);
                }
            }
        }

        [Fact]
        public void Main_ValidArguments_ShouldCreateSineWaveGIF()
        {
            // Arrange
            string[] args = new[] { _testInputFile, _testOutputFile, "1", "1" };

            // Act
            Program.Main(args);

            // Assert
            Assert.True(File.Exists(_testOutputFile));
        }

        [Fact]
        public void Main_InvalidArguments_ShouldThrowArgumentException()
        {
            // Arrange
            string[] args = new[] { "arg1", "arg2", "arg3" };

            // Act and Assert
            Assert.Throws<ArgumentException>(() => Program.Main(args));
        }

        [Fact]
        public void Main_InvalidMaxDelayRatio_ShouldThrowArgumentException()
        {
            // Arrange
            string[] args = new[] { _testInputFile, _testOutputFile, "invalid", "0.5" };

            // Act and Assert
            Assert.Throws<ArgumentException>(() => Program.Main(args));
        }

        [Fact]
        public void Main_InputFileNotFound_ShouldThrowArgumentException()
        {
            // Arrange
            string[] args = new[] { "invalid_file_path", _testOutputFile, "1", "1" };

            // Act and Assert
            Assert.Throws<ArgumentException>(() => Program.Main(args));
        }

        public void Dispose()
        {
            File.Delete(_testInputFile);
            File.Delete(_testOutputFile);
        }
    }
}
