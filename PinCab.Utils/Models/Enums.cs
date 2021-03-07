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

    public enum DatabaseEntryType
    {
        [Description("Unknown")]
        Unknown,
        [Description("Wheel")]
        Wheel,
        [Description("Flyer")]
        Flyer,
        [Description("Instruction Card")]
        InstructionCard,
        [Description("Backglass")]
        Backglass,
        [Description("Other Front End Media")]
        OtherFrontEndMedia,
        [Description("Table")]
        Table,
        [Description("Topper")]
        Topper,
        [Description("ROM")]
        ROM,
        [Description("Pinsound / Alt Sound")]
        Pinsound,
        [Description("POV File")]
        POV,
        [Description("Pup Pack")]
        PupPack
    }

    public enum DatabaseType
    {
        [Description("VPS Spreadsheet")]
        VPSSpreadsheet,
        [Description("VP Forums")]
        VPForums,
        [Description("VP Universe")]
        VPUniverse,
        [Description("VPinball")]
        VPinball,
        [Description("IPDB")]
        IPDB
    }
}
