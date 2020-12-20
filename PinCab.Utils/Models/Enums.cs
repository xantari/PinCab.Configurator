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
}
