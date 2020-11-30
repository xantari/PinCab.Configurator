# PinCab Configurator [![Build status](https://ci.appveyor.com/api/projects/status/rdqo2s3b82l0gpe7?svg=true)](https://ci.appveyor.com/project/xantari/PinCabScreenConfigurator)
This tool allows you to layout your screens and validate your screen configuration in all virtual pinball related programs.

The motivation behind this program was to solve these issues with Virtual Pinball cabinet setups:

1. It's difficult to set all the various program settings related to Virtual Pinball as there are so many addon programs involved that each need their own screen setup.
2. Changing Video Cards or Displays causes you to have to re-setup the new coordinates in many different areas. Instead the idea is to define it in one place and have those settings
replicate to all the other areas automatically.
3. Provide a FFMPEG command line examples on how to record screens and specific regions of screens
4. Add other useful pincab tools into one program
5. Ever wonder if your DMD sizes and positions are 100% consistent across all DMD programs? This will tell you.

# Requirements

.NET Framework 4.7.2 or higher

# Features

1. Reads Monitors EDID information to display manufacturer details such as Model / Serial number of connected displays
2. Gives visual representation of where your monitors are located with border and offset displays of visible screen areas
3. Allows labeling screens
4. Validates screen configuration is compatible   
	a. No screens with negative coordinates  
	b. Playfield is screen 1 and set as primary  
	c. DMD Size calculations are 4:1 ratio (just a warning, some DMD's are not 4:1 like the sega DMD's, and the other unique ones like the TMNT / Dataeast ones)  
	d. Ensure all monitors set to 100% Scaling (no DPI scaling)  
5. Generates FFMPeg commands to capture the screens and output them to a .MP4 file
6. Predefined labels for Playfield, DMD, Backglass, Topper, and Apron displays
7. Dumps entire screen display details / EDID information to JSON
8. Settings page to point to the following:  
   	a. FFMPEG  
	b. Front End settings file (Pinball X / Pinball Y / Pinup Popper)  
	c. B2S Screenres.txt, P-ROC, DMDDevice.ini, Future DMD INI, Pinup Player  
9. Add ability to define multiple visible window boxes on a single screen (for those who display both their topper and DMD on same screen such as TerryRed's PinCab configuration)
10. Exception handling / Logging
11. Realtime updating of region Size and Offset changes
12. PinCab Screen configuration data (Read/Write). Can save your configuration data for easy movement to new monitor/videocard configuration during upgrades.
13. High level debug information that shows monitors connected, their orientation with full virtual desktop space calculations (takes into account the X/Y offsets)
14. Pinball X .ini read/write/validation
15. Autobackup registry keys and settings files whenever we write to them. Save to programs Backup folder.
16. Future DMD (Future Pinball) read/write/validation
17. B2S ScreenRes.txt read/write/validation
18. All features of the existing ScreenRes editor exist in program (Utilites >> Screen res editor)
19. UltraDMD Registry Key read/write/validation
20. DMDDevice.ini (DMDExt / FlexDMD) read/write/validation
21. VPinMame registry location settings (for those not using DMDExt).  
	a. Option to set Default  
	b. Option to update all previously run ROM's DMD positions  
22. All functions of SetDMD + more options (Utilities>>PinMAME ROM Browser)
	a. You can preview the ROM settings in either DMDExt or VPinMame's native renderer

# Instructions

If you want to backup the display settings the key file is DisplaySettings.json in the application folder. This file is automatically created when you first setup your display configuration.

Logging information is in the Log.txt file in the application root folder.

# Screenshots

#### 2 Screen Setup  

![2 Screen Setup](https://github.com/xantari/PinCabScreenConfigurator/raw/master/Screenshots/Screenshot_2Screens.png "2 Screen Setup")

#### 3 Screen Setup (DMD Monitor only shows DMD) - Example of my PinCab with a 1080P 15.6" DMD Screen with only a DMD cutout.
![3 Screen Setup](https://github.com/xantari/PinCabScreenConfigurator/raw/master/Screenshots/Screenshot_3Screens.png "3 Screen Setup")

#### 3 Screen Setup (TerryRed Setup (DMD and Topper on same screen))
![3 Screen Setup](https://github.com/xantari/PinCabScreenConfigurator/raw/master/Screenshots/Screenshot_3ScreensV2.png "3 Screen Setup")

#### B2S Screenres Editor
![B2S Screenres.txt Editor](https://github.com/xantari/PinCabScreenConfigurator/raw/master/Screenshots/B2sScreenresEditor.png "B2S Screenres Editor")

#### PinMAME ROM Browser (All functions of SetDMD and more)
![PinMAME ROM Browser](https://github.com/xantari/PinCabScreenConfigurator/raw/master/Screenshots/PinMameROMBrowserScreenshot.png "PinMAME ROM Browser")

#### PinMAME ROM Setting Editor
![PinMAME ROM Setting Editor](https://github.com/xantari/PinCabScreenConfigurator/raw/master/Screenshots/PinMameRomEditorScreenshot.png "PinMAME ROM Setting Editor")

# TODO
1. Add command line switch to actually run the FFMPeg commands to capture video and move the resulting videos to the correct location (depending on front end)
2. PinUp Popper / Player location settings read/write/validation
3. Create help HTML pages and hookup to the program
4. Add a feature that will compare your table list in PinballY / PinballX / Pinup Popper and show you missing and extra media (such as old outdated recordings from renamed tables, etc that don't match the tablename exactly)
for things like Wheels / Backglass / Playfield / Launch Audio / Toppers / etc.
5. P-Roc settings read/write/validation
6. Manual validation output info for Pinball FX2/FX3
7.  Pinball Y settings read/write/validation



# Thank you!
Thanks go to [Soroush Falahati](https://github.com/falahati) for his excellent [WindowsDisplayApi](https://github.com/falahati/WindowsDisplayAPI) and [EDIDParser](https://github.com/falahati/EDIDParser) libraries!

# Help Needed

1. Unable to figure out how to read/write/validate Pinball FX2 / FX3 screen settings for Cabinet mode (need to ensure cabinet mode enabled first (must get code from Zen Studios)).
Settings data appears to be encrypted. Unsure how to read/write to it.

# Notes
1. Compilation is done using Any CPU, with the Prefer 32-bit flag as it links itself to the 32-bit version of VPinMame for DMD preview