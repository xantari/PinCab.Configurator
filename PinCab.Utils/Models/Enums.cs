using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinCab.Utils.Models
{
    public enum MessageLevel
    {
        Information,
        Warning,
        Error
    }

    public enum DisplayTypes
    {
        Playfield,
        DMD,
        Topper,
        Apron,
        Backglass,
        FullDmd
    }

    public enum MediaStatus
    {
        [Description("Not Found")]
        NotFound,
        [Description("Audio")]
        Audio,
        [Description("Image")]
        Image,
        [Description("Video")]
        Video,
        [Description("Image and Video")]
        ImageAndVideo
    }

    public enum SearchMode
    {
        ByFileNameExactMatch,
        ByDescriptionExactMatch
    }

    public enum MediaType
    {
        Unknown,
        Image,
        Audio,
        Video
    }

    public enum MediaCategory
    {
        Unknown,
        Wheel,
        Flyer,
        InstructionCard,
        Backglass,
        Apron,
        DMD,
        Launch, //Launch image/video
        RealDmdColor,
        RealDmd,
        Table,
        TableDesktop,
        Topper,
        Manufacturer, //Manufacturer media
        Other
    }

    public enum MediaAuditStatus
    {
        [Description("Missing Media")]
        MissingMedia,
        [Description("Unused Media")]
        UnusedMedia
    }

    public enum DatabaseType
    {
        [Description("Pinball Database")]
        PinballDatabase,
        [Description("IPDB")]
        IPDB
    }

    public enum FrontEndSystem
    {
        [Description("Pinball X")]
        PinballX,
        [Description("Pinball Y")]
        PinballY,
        [Description("Pinup Popper")]
        PinupPopper
    }

    public enum LaunchType
    {
        LaunchGame,
        LaunchGameInConfigMode,
        LaunchGameUsingFrontEnd
    }

    /// <summary>
    /// Different types of systems.
    /// </summary>
    public enum Platform
    {
        Undefined,
        /// <summary>
        /// Visual Pinball
        /// </summary>
        VP,

        /// <summary>
        /// Future Pinball
        /// </summary>
        FP,
        PinballFX2,
        PinballFX3,
        PinballArcade,

        /// <summary>
        /// Anything else
        /// </summary>
        Custom
    }
}
