namespace SineWaveGIF.Tests;

public class ProgramTests
{
    private const string TestInputFile = "test_input.gif";
    private const string TestOutputFile = "test_output.gif";

    [Fact]
    public void Main_ValidArguments_ShouldCreateSineWaveGIF()
    {
        // Arrange
        string[] args = new[] { TestInputFile, TestOutputFile, "1", "1" };

        // Act
        Program.Main(args);

        // Assert
        Assert.True(File.Exists(TestOutputFile));
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
        string[] args = new[] { TestInputFile, TestOutputFile, "invalid", "0.5" };

        // Act and Assert
        Assert.Throws<ArgumentException>(() => Program.Main(args));
    }

    [Fact]
    public void Main_InputFileNotFound_ShouldThrowArgumentException()
    {
        // Arrange
        string[] args = new[] { "invalid_file_path", TestOutputFile, "1", "1" };

        // Act and Assert
        Assert.Throws<ArgumentException>(() => Program.Main(args));
    }
}
