# PinCab Screen Configurator
This tool allows you to layout your screens and validate your screen configuration in all virtual pinball related programs.

The motivation behind this program was to solve these issues with Virtual Pinball cabinet setups:

1. It's difficult to set all the various program settings related to Virtual Pinball as there are so many addon programs involved that each need their own screen coordinates.
2. Provide a FFMPEG command line to help Pinball X creator QC their video capture code
3. Changing Video Cards or Displays causes you to have to re-setup the new coordinates in many different areas. Instead the idea is to define it in one place and have those settings
replicate to all the other areas automatically.

# Features

1. Reads Monitors EDID information to display manufacturer details such as Model / Serial number of connected displays
2. Gives visual representation of where your monitors are located with border and offset displays of visible screen areas
3. Allows labeling screens
4. Validates screen configuration is compatible (no screens with negative coordinates)
5. Generates FFMPeg commands to capture the screens and output them to a .MP4 file
6. Predefined labels for Playfield, DMD, Backglass, Topper, and Apron displays
7. Dumps entire screen display details / EDID information to JSON

# Instructions

# Screenshots

#### 2 Screen Setup  

![2 Screen Setup](https://github.com/xantari/PinCabScreenConfigurator/raw/master/Screenshots/Screenshot_2Screens.png "2 Screen Setup")

#### 3 Screen Setup  
![3 Screen Setup](https://github.com/xantari/PinCabScreenConfigurator/raw/master/Screenshots/Screenshot_3Screens.png "3 Screen Setup")

# TODO
1. Pinball X Ini read/write/validation
2. Future DMD (Future Pinball) read/write/validation
3. B2S ScreenRes.txt read/write/validation
4. DMDDevice.ini (DMDExt / VPinMame) read/write/validation
5. PinCab Screen configuration data (Read/Write)
6. UltraDMD Registry Key read/write/validation
7. Add ability to define multiple visible window boxes on a single screen (for those who display both their topper and DMD on same screen or both their backglass and DMD on same screen (2 screen setup))
8. Put overlay window on a seperate thread
9. Put in some exception logging
10. Add command line switch to actually run the FFMPeg commands to capture video and move the resulting videos to the correct location (depending on front end)
11. Add settings page to point to the following:  
   	a. FFMPEG  
	b. Front End settings file (Pinball X / Pinball Y / Pinup Popper)
12. P-PROC location settings
13. VPinMame registry location settings (for those not using DMDExt).  
	a. Option to set Default  
	b. Option to update all previously run ROM's   
14. PinUp location settings read/write/validation
15. Set Pinball FX2 / FX3 screen settings for Cabinet mode (need to ensure cabinet mode enabled first (must get code from Zen Studios))
16. Additiona Validation:   
	a. Ensure Primary Monitor is Monitor 1, and is labeled the Playfield screen


# Thank you!
Thanks go to [Soroush Falahati](https://github.com/falahati) for his excellent [WindowsDisplayApi](https://github.com/falahati/WindowsDisplayAPI) and [EDIDParser](https://github.com/falahati/EDIDParser) libraries!

# Revision History