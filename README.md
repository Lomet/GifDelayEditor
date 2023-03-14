[![CodeFactor](https://www.codefactor.io/repository/github/lomet/gifdelayeditor/badge)](https://www.codefactor.io/repository/github/lomet/gifdelayeditor)

# SineWaveGIF

SineWaveGIF is a command-line tool that creates a sine wave animation from an input GIF file.

## Installation
SineWaveGIF is a .NET Core console application and requires .NET Core 3.1 or later to run. You can download the latest version of .NET Core from the official website: https://dotnet.microsoft.com/download

To build SineWaveGIF from source code, you need to have Visual Studio 2019 or later installed.

## Usage
The SineWaveGIF command-line tool has the following syntax:

```
SineWaveGIF.exe <input-file> <output-file> <max-delay-ratio> <speed-up-ratio>
```

## Where:

<input-file> is the path to the input GIF file
<output-file> is the path to the output GIF file
<max-delay-ratio> is a double value that controls the maximum delay of the sine wave animation. The default value is 2.
<speed-up-ratio> is a double value that controls the speed-up factor of the sine wave animation. The default value is 1.5.
## Example
To create a sine wave animation from input.gif with a maximum delay ratio of 2 and a speed-up ratio of 1.5, and save the result to output.gif, run the following command:

```
SineWaveGIF.exe input.gif output.gif 2 1.5
```
  
## License
SineWaveGIF is licensed under the MIT License. See the LICENSE file for more information.
