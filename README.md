[![CodeFactor](https://www.codefactor.io/repository/github/lomet/gifdelayeditor/badge)](https://www.codefactor.io/repository/github/lomet/gifdelayeditor)
[![Build and Test](https://github.com/Lomet/GifDelayEditor/actions/workflows/dotnet.yml/badge.svg)](https://github.com/Lomet/GifDelayEditor/actions/workflows/dotnet.yml)
[![codecov](https://codecov.io/gh/Lomet/GifDelayEditor/branch/main/graph/badge.svg?token=3K8NVVRTHW)](https://codecov.io/gh/Lomet/GifDelayEditor)

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

Where:
```
<input-file> is the path to the input GIF file
<output-file> is the path to the output GIF file
<max-delay-ratio> is a double value that controls the maximum delay factor of the sine wave animation.
<speed-up-ratio> is a double value that controls the speed-up factor of the sine wave animation.
```

## Example
To create a sine wave animation from input.gif with a maximum delay ratio of 2 and a speed-up ratio of 1.5, and save the result to output.gif, run the following command:

```
input.gif
```
![input](https://user-images.githubusercontent.com/48094744/224869873-0a12756a-6af4-407e-a030-95735fcd60a4.gif)

```
SineWaveGIF.exe input.gif output.gif 2 1.5
```

```
output.gif
```

![output](https://user-images.githubusercontent.com/48094744/224869863-fccd001d-639c-4297-8b82-d3ab439759f6.gif)
  
## License
SineWaveGIF is licensed under the MIT License. See the LICENSE file for more information.
