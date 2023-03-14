# GifDelayEditor

This is a tool for editing GIFs by modifying the delay time between frames, using a sine wave function to create a smooth transition between delays.

## Directory structure

- `GifsineMaker/`: Contains the core logic for editing GIFs.
  - `GifFrame.cs`: Defines the `GifFrame` class, which represents a single frame of a GIF.
  - `GifLoader.cs`: Defines the `GifLoader` class, which loads a GIF file into a list of `GifFrame` objects.
  - `GifMaker.cs`: Defines the `GifMaker` class, which modifies the delays of a list of `GifFrame` objects and saves them to a new GIF file.
  - `Program.cs`: Defines the entry point of the program, which reads command line arguments and uses the `GifMaker` class to edit a GIF file.
  - `SinWave.cs`: Defines the `SinWave` class, which generates a sine wave function used to modify the delays of a GIF.

## Usage

To use this tool, run the `GifsineMaker` project with the following command line arguments:

program.exe inputfile outputfile maxdelayratio speedupratio

- `inputfile`: The path to the input GIF file.
- `outputfile`: The path to the output GIF file.
- `maxdelayratio`: A floating-point number that controls the amplitude of the sine wave function used to modify the delays of the GIF. Higher values result in more dramatic changes in delay time.
- `speedupratio`: A floating-point number that controls the period of the sine wave function used to modify the delays of the GIF. Higher values result in faster changes in delay time.

## Contributing

If you'd like to contribute to this project, here are some tips to get started:

1. Fork the repository and clone it to your local machine.
2. Create a new branch for your changes.
3. Make your changes and commit them with descriptive commit messages.
4. Push your branch to your forked repository.
5. Open a pull request to merge your changes into the main branch of the original repository.

Thank you for your contributions!
