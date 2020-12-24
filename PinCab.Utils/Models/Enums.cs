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
        Backglass
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
        DMD,
        Launch, //Launch image/video
        RealDmdColor,
        RealDmd,
        Table,
        TableDesktop,
        Topper
    }

    public enum MediaAuditStatus
    {
        [Description("Missing Media")]
        MissingMedia,
        [Description("Unused Media")]
        UnusedMedia
    }
}
