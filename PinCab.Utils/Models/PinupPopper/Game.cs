using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinCab.Utils.Models.PinupPopper
{
    public class Game
    {
        public Game()
        {
        }

        public int GameID { get; set; }
        public int EMUID { get; set; }
        public string GameName { get; set; }
        public string GameFileName { get; set; }
        public string GameDisplay { get; set; }
        public int UseEmuDefaults { get; set; }
        public int Visible { get; set; }
        public string Notes { get; set; }
        public DateTime DateAdded { get; set; }
        public int GameYear { get; set; }
        public string ROM { get; set; }
        public string Manufact { get; set; }
        public int NumPlayers { get; set; }
        public int ResolutionX { get; set; }
        public int ResolutionY { get; set; }
        public int OutputScreen { get; set; }
        public int ThemeColor { get; set; }
        public string GameType { get; set; }
        public string TAGS { get; set; }
        public string Category { get; set; }
        public string Author { get; set; }
        public string LaunchCustomVar { get; set; }
        public string GKeepDisplays { get; set; }
        public string GameTheme { get; set; }
        public int GameRating { get; set; }
        public string Special { get; set; }
        public int sysVolume { get; set; }
        public string DOFStuff { get; set; }
        public string MediaSearch { get; set; }
        public string AudioChannels { get; set; }
        public string CUSTOM2 { get; set; }
        public string CUSTOM3 { get; set; }
        public string GAMEVER { get; set; }
        public string ALTEXE { get; set; }
        public string IPDBNum { get; set; }
        public DateTime DateUpdated { get; set; }
        public DateTime DateFileUpdated { get; set; }
        public int AutoRecFlag { get; set; }
        public string AltRunMode { get; set; }
        public string WebLinkURL { get; set; }
        public string DesignedBy { get; set; }
    }
}
