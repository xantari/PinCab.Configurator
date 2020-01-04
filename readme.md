# PinCab Screen Configurator
This tool allows you to layout your screens and validate your screen configuration in all pinball related programs.

# Features

1. Reads Monitors EDID information to display manufacturer details such as Model / Serial number of connected displays
2. Gives visual representation of where your monitors are located with border and offset displays of visible screen areas
3. Allows labeling screens
4. Validates screen configuration is compatible (no screens with negative coordinates)
5. Generates FFMPeg commands to capture the screens and output them to a .MP4 file
6. Predefined labels for Playfield, DMD, Backglass, Topper, and Apron displays
7. Dumps entire screen display details to JSON

# Screenshots


# TODO
1. Pinball X Ini Reading/Writing
2. Future DMD (Future Pinball) Reading/Writing
3. B2S ScreenRes.txt reading/writing
4. DMDDevice.ini (DMDExt / VPinMame) reading/writing
5. PinCab Screen configuration data (Read/Write)

# Thank you!
Thanks go to [Soroush Falahati](https://github.com/falahati) for his excellent [WindowsDisplayApi](https://github.com/falahati/WindowsDisplayAPI) and [EDIDParser](https://github.com/falahati/EDIDParser) libraries!