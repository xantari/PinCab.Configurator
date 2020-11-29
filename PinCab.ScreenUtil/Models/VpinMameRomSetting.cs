using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinCab.ScreenUtil.Models
{
    /// <summary>
    /// VPinMame ROM Registry Data Model
    /// </summary>
    public class VpinMameRomSetting
    {
        /// <summary>
        /// antialias
        /// Enable/Disable anti Aliasing
        /// </summary>
        public bool? EnableAntiAlias { get; set; }
        /// <summary>
        /// cheat
        /// Skip Pinball Startup Test: Will try to skip the startup/boot sequence on some machines. Should be usually safe to enable (for example not for Dr. Dude though)
        /// </summary>
        public bool? SkipStartup { get; set; }
        /// <summary>
        /// dmd_antialias
        /// Display Antialias: Simple anti-aliasing filter of the output window (0..100%)
        /// </summary>
        public int? AntiAliasPercentage { get; set; }
        /// <summary>
        /// dmd_opacity
        /// Display Opacity: Steers the transparency of the output window (0..100%) (useful if you wanna place the window over the playfield itself)
        /// </summary>
        public int? Opacity { get; set; }
        /// <summary>
        /// dmd_border
        /// </summary>
        public bool? Border { get; set; }
        /// <summary>
        /// dmd_title
        /// </summary>
        public bool? Title { get; set; }
        /// <summary>
        /// scanlines
        /// Scanlines - puts CRT style scanlines on the DMD. Probalby also best off. DMD's were plasma and had no scanlines.
        /// </summary>
        public bool? Scanlines { get; set; }
        public bool? DirectDraw { get; set; }
        /// <summary>
        /// showwindmd
        /// Show DMD/Display Window from VPinMame. En/Disable the standard output window
        /// </summary>
        public bool? ShowVPinMameDmd { get; set; }
        /// <summary>
        /// direct3d
        /// </summary>
        public bool? Direct3D { get; set; }
        /// <summary>
        /// at91jit
        /// JIT Compiler enabled/disabled.
        /// </summary>
        public bool? At91jit { get; set; }
        /// <summary>
        /// showpindmd
        /// Use external DMD (dll) / DMDExt / PinMame
        /// Use external DMD(dll) : If properly setup(e.g.a dmddevice.dll supporting PinDMD or similar, is placed inside the PinMAME folder), will use an external dll to drive an output window OR even an external hardware DMD
        /// </summary>
        public bool? ExternalDmdDevice { get; set; }
        /// <summary>
        /// dmd_height
        /// Height in pixels of the DMD
        /// </summary>
        public int? Height { get; set; }
        /// <summary>
        /// dmd_width
        /// Width in pixels of the DMD
        /// </summary>
        public int? Width { get; set; }
        /// <summary>
        /// dmd_pos_x
        /// Virtual position of the X coordinate on the display in relation to all the other displays in the system of the upper left corner of rectangle
        /// </summary>
        public int? OffsetX { get; set; }
        /// <summary>
        /// dmd_pos_y
        /// Virtual position of the Y coordinate on the display in relation to all the other displays in the system of the upper left corner of rectangle
        /// </summary>
        public int? OffsetY { get; set; }
        /// <summary>
        /// dmd_perc0
        /// Intensity percentage at off (0%)
        /// Default: 20
        /// </summary>
        public int? IntensityPerc0 { get; set; }
        /// <summary>
        /// dmd_perc33
        /// Intensity percentage at 33%
        /// Default: 33
        /// </summary>
        public int? IntensityPerc33 { get; set; }
        /// <summary>
        /// dmd_perc66
        /// Intensity Percentage at 66%
        /// Default: 67
        /// </summary>
        public int? IntensityPerc66 { get; set; }
        /// <summary>
        /// dmd_colorize
        /// Enables colorization of ROM using .pal color files and/or modified roms
        /// </summary>
        public bool? Colorize { get; set; }
        /// <summary>
        /// cabinet_mode
        /// Cabinet Mode: The output window can be placed more freely(e.g.a second/third monitor) and skips the disclaimer screens
        /// </summary>
        public bool? CabinetMode { get; set; }
        /// <summary>
        /// ignore_rom_crc
        /// Ignore ROM CRC errors: Will ignore wrong/broken or modified ROMs and start the emulation anyway.Useful if using MODs that are not yet in the PinMAME list
        /// </summary>
        public bool? IgnoreRomCrc { get; set; }
        /// <summary>
        /// rol
        /// </summary>
        public bool? RotateLeft { get; set; }
        /// <summary>
        /// ror
        /// </summary>
        public bool? RotateRight { get; set; }
        /// <summary>
        /// flipx
        /// </summary>
        public bool? FlipX { get; set; }
        /// <summary>
        /// flipy
        /// </summary>
        public bool? FlipY { get; set; }
        /// <summary>
        /// synclevel
        /// VP<->VPM synclevel: Was used to balance the processing power between VP and VPM, nowadays best leave at 0 (but if you still insist, this is the number of times that VPM will try to get control over the CPU, per second, see http://www.vpforums....?showtopic=1951)
        /// </summary>
        public int? SyncLevel { get; set; }
        /// <summary>
        /// resampling_quality
        /// Resampling quality: Audiophiles can pick 1 instead of 0, but will pay with lower performance
        /// </summary>
        public bool? ResamplingQuality { get; set; }
        /// <summary>
        /// dmd_doublesize
        /// Double Display Size: Double every outputted pixel in x and y direction, e.g.a very simplistic output scale
        /// </summary>
        public bool? DoubleDisplaySize { get; set; }
        /// <summary>
        /// fastframes
        /// Emulation Fast Frames: Will emulate the first X frames as fast as possible, leading to a quicker startup, without any sideeffects (usually this value is in the 100s to 1000s range)
        /// </summary>
        public int? FastFrames { get; set; }
        /// <summary>
        /// samplerate
        /// Sound samplerate: Samplerate that is used for outputting sound.This was previously also influencing the internal emulation quality, but not anymore since 2.8
        /// </summary>
        public int? SampleRate { get; set; }
        /// <summary>
        /// dmd_compact
        /// Compact Display: Smallest window output, with no empty space inbetween dots/pixels. No dots mode.
        /// </summary>
        public bool? CompactMode { get; set; }
        /// <summary>
        /// sound_mode
        /// Sound mode: This can enable the use of alternative, external sound package recordings(like the ones on PinSound, https://www.pinsound.org/), see: http://www.vpforums....=27063&p=334753
        /// https://www.vpforums.org/index.php?showtopic=27063&page=14#entry334753
        ///   0 = standard builtin PinMAME emulation
        ///   1 = builtin alternate sound file support
        ///    (store the alternate sound files in a PinSound-like directory structure (incl.textfiles for ducking and gain),
        ///     within a new PinMAME directory subfolder 'altsound' and there within the machines shortname subfolder,
        ///     e.g. for ij_l7: 'C:\PinMAME\altsound\ij_l7\'
        ///     or for an example alternate sound file for tz_94h: 'C:\PinMAME\altsound\tz_94h\jingle\000064-load_gumball_pt_1\load_gum__LEGACY.ogg')
        ///   2 = external pinsound, 3 = external pinsound + psrec sound recording
        ///    (must have PinSound Studio 0.7 or newer running at the same time:
        ///     make sure that the windows permissions match between PinSound Studio and Visual PinMAME/Pinball, e.g.
        ///     if one is using admin permissions when running, then both need to be started with that(or the other way round))
        /// </summary>
        public int? SoundMode { get; set; }
        /// <summary>
        /// samples
        /// Use Samples: En/Disable pre-recorded samples for some machines
        /// </summary>
        public bool? UseSamples { get; set; }
        /// <summary>
        /// sound
        /// Use Sound: En/Disable all sound output
        /// </summary>
        public bool? EnableSound { get; set; }
        /// <summary>
        /// dmd_red
        /// 1-255 RGB Color
        /// Default: 255
        /// </summary>
        public int? Red { get; set; }
        /// <summary>
        /// dmd_green
        /// 1-255 RGB Color
        /// Default: 88
        /// </summary>
        public int? Green { get; set; }
        /// <summary>
        /// dmd_blue
        /// 1-255 RGB Color
        /// Default: 32
        /// </summary>
        public int? Blue { get; set; }
    }
}
