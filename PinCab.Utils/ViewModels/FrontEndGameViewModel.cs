using PinCab.Utils.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinCab.Utils.ViewModels
{
    public class FrontEndGameViewModel
    {
        public FrontEndGameViewModel()
        {
            BackglassStatus = MediaStatus.NotFound;
            DMDStatus = MediaStatus.NotFound;
            RealDMDColorStatus = MediaStatus.NotFound;
            ReadDMDStatus = MediaStatus.NotFound;
            TableStatus = MediaStatus.NotFound;
            TableDesktopStatus = MediaStatus.NotFound;
            TopperStatus = MediaStatus.NotFound;
            ManufacturerMediaStatus = MediaStatus.NotFound;
        }

        public FrontEnd FrontEnd { get; set; }

        public string FileName { get; set; }
        public string Description { get; set; }
        public string Manufacturer { get; set; }
        public string Year { get; set; }
        public string Type { get; set; }
        public bool HideDmd { get; set; }
        public bool HideTopper { get; set; }
        public bool HideBackglass { get; set; }
        public bool Enabled { get; set; }
        public double Rating { get; set; }
        public string AlternateExe { get; set; }
        public string Players { get; set; }
        public string Comment { get; set; }
        public string Theme { get; set; }
        public string Author { get; set; }
        public string Version { get; set; }
        public string IPDBNumber { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateModified { get; set; }

        //PinballX / PinballY use XML database files, will be null for Pinup Popper
        public string DatabaseFile { get; set; }
        //Pinup Popper specific Game Id, Null if not a pinup popper front end
        public int? PopperGameId { get; set; }
        public bool HasUpdatesAvailable { get; set; }
        public string Rom { get; set; }

        /// <summary>
        /// Linked VPin Game Database Id, for eventual game database for easy updates to tables
        /// </summary>
        public int VPinGameDatabaseId { get; set; }

        //Media Statuses of found media
        public MediaStatus BackglassStatus { get; set; }
        public MediaStatus DMDStatus { get; set; }
        public MediaStatus RealDMDColorStatus { get; set; }
        public MediaStatus ReadDMDStatus { get; set; }
        public MediaStatus TableStatus { get; set; }
        public MediaStatus TableDesktopStatus { get; set; }
        public MediaStatus TopperStatus { get; set; }
        public MediaStatus ManufacturerMediaStatus { get; set; }
        public bool HasLaunchAudio { get; set; }
        public bool HasFlyer { get; set; }
        public bool HasInstructionCard { get; set; }
        public bool HasWheelImage { get; set; }
        public bool HasTableAudio { get; set; }
    }
}
