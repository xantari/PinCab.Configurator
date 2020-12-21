using PinCab.Utils.Extensions;
using PinCab.Utils.Models;
using PinCab.Utils.Models.PinballX;
using PinCab.Utils.Utils.PinballX;
using PinCab.Utils.ViewModels;
using Serilog;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinCab.Utils.Utils
{
    public class FrontEndManager
    {
        private readonly ProgramSettings _settings = new ProgramSettings();
        private readonly ProgramSettingsManager _settingManager = new ProgramSettingsManager();
        private readonly PinballXManager _pinballXManager = null;
        private readonly List<PinballXSystem> _pinballXSystems = null;

        public FrontEndManager()
        {
            _settings = _settingManager.LoadSettings();

            if (_settings.PinballXExists())
            {
                _pinballXManager = new PinballXManager(_settings.PinballXIniPath);
                _pinballXSystems = _pinballXManager.ParseSystems();
            }
        }

        public List<FrontEnd> GetListOfActiveFrontEnds()
        {
            var list = new List<FrontEnd>();
            if (_settings.PinupPopperExists())
                list.Add(new FrontEnd() { Name = FrontEndSystem.PinupPopper.GetDescriptionAttr(), SettingFilePath = _settings.PinupPopperSqlLiteDbPath, System = FrontEndSystem.PinupPopper });
            if (_settings.PinballXExists())
                list.Add(new FrontEnd() { Name = FrontEndSystem.PinballX.GetDescriptionAttr(), SettingFilePath = _settings.PinballXIniPath, System = FrontEndSystem.PinballX });
            if (_settings.PinballYExists())
                list.Add(new FrontEnd() { Name = FrontEndSystem.PinballY.GetDescriptionAttr(), SettingFilePath = _settings.PinballYSettingsPath, System = FrontEndSystem.PinballY });
            return list;
        }

        public List<PinballXSystem> PinballXSystems { get { return _pinballXSystems; } }
        public ProgramSettings Settings { get { return _settings; } }

        public void SaveSettings(ProgramSettings settings)
        {
            _settingManager.SaveSettings(settings);
        }

        public List<FrontEndGameViewModel> GetGamesForFrontEndAndDatabase(FrontEnd frontEnd, string databaseFile)
        {
            var frontEndGames = new List<FrontEndGameViewModel>();
            if (frontEnd != null && !string.IsNullOrEmpty(databaseFile))
            {
                if (frontEnd.System == FrontEndSystem.PinballX)
                    frontEndGames = GetPinballXFrontEndGames(frontEnd, databaseFile);
            }
            return frontEndGames;
        }

        private List<FrontEndGameViewModel> GetPinballXFrontEndGames(FrontEnd frontEnd, string databaseFile)
        {
            var frontEndGames = new List<FrontEndGameViewModel>();
            foreach (var system in PinballXSystems)
            {
                var fullDatabaseFile = system.DatabaseFiles.FirstOrDefault(p => p.Contains(databaseFile));
                if (!string.IsNullOrEmpty(fullDatabaseFile))
                {
                    var games = system.Games[fullDatabaseFile];
                    foreach (var game in games)
                    {
                        var frontEndGame = new FrontEndGameViewModel()
                        {
                            AlternateExe = game.AlternateExe,
                            Author = game.Author,
                            Comment = game.Comment,
                            DatabaseFile = game.DatabaseFile,
                            DateAdded = Convert.ToDateTime(game.DateAdded),
                            DateModified = Convert.ToDateTime(game.DateModified),
                            Description = game.Description,
                            Enabled = Convert.ToBoolean(game.Enabled),
                            FileName = game.FileName,
                            FrontEnd = frontEnd,
                            HasUpdatesAvailable = false,
                            HideBackglass = Convert.ToBoolean(game.HideBackglass),
                            HideDmd = Convert.ToBoolean(game.HideDmd),
                            HideTopper = Convert.ToBoolean(game.HideTopper),
                            IPDBNumber = game.IPDBNumber,
                            Manufacturer = game.Manufacturer,
                            Players = game.Players,
                            Rating = game.Rating,
                            Rom = game.Rom,
                            Theme = game.Theme,
                            Type = game.Type,
                            Year = game.Year,
                            Version = game.Version,
                            PopperGameId = null
                        };

                        //Load the Media Statuses for this game
                        LoadPinballXMediaStatus(system, frontEndGame, new SearchMode[] { SearchMode.ByFileNameExactMatch });

                        //TODO: cross reference DateAdded with last updated date from game database and flip the HasUpdatesAvailable flag

                        frontEndGames.Add(frontEndGame);
                    }
                }
            }
            return frontEndGames;
        }

        private void LoadPinballXMediaStatus(PinballXSystem system, FrontEndGameViewModel model, SearchMode[] searchModes)
        {
            var rootMediaPath = system.MediaPath.Replace(system.Name, string.Empty);

            List<string> wheelImages = new List<string>();
            List<string> flyers = new List<string>();
            List<string> instructionCards = new List<string>();
            List<string> backglassImages = new List<string>();
            List<string> backglassVideos = new List<string>();
            List<string> dmdImages = new List<string>();
            List<string> dmdVideos = new List<string>();
            List<string> launchAudios = new List<string>();
            List<string> realDmdColorImages = new List<string>();
            List<string> realDmdColorVideos = new List<string>();
            List<string> realDmdImages = new List<string>();
            List<string> realDmdVideos = new List<string>();
            List<string> tableAudios = new List<string>();
            List<string> tableImages = new List<string>();
            List<string> tableVideos = new List<string>();
            List<string> tableDesktopImages = new List<string>();
            List<string> tableDesktopVideos = new List<string>();
            List<string> topperImages = new List<string>();
            List<string> topperVideos = new List<string>();

            string wheelPath = system.MediaPath + "\\Wheel Images";
            string flyerPath = rootMediaPath + "Flyer Images";
            string instructionCardpath = rootMediaPath + "Instruction Cards";
            string backglassImagePath = system.MediaPath + "\\Backglass Images";
            string backglassVideoPath = system.MediaPath + "\\Backglass Videos";
            string dmdImagePath = system.MediaPath + "\\DMD Images";
            string dmdVideoPath = system.MediaPath + "\\DMD Videos";
            string launchAudioPath = system.MediaPath + "\\Launch Audio";
            string realDmdColorImagePath = system.MediaPath + "\\Real DMD Color Images";
            string realDmdColorVideoPath = system.MediaPath + "\\Real DMD Color Videos";
            string realDmdImagePath = system.MediaPath + "\\Real DMD Images";
            string realDmdVideoPath = system.MediaPath + "\\Real DMD Videos";
            string tableAudioPath = system.MediaPath + "\\Table Audio";
            string tableImagePath = system.MediaPath + "\\Table Images";
            string tableVideoPath = system.MediaPath + "\\Table Videos";
            string tableImageDesktopPath = system.MediaPath + "\\Table Images Desktop";
            string tableVideoDesktopPath = system.MediaPath + "\\Table Videos Desktop";
            string topperImagePath = system.MediaPath + "\\Topper Images";
            string topperVideoPath = system.MediaPath + "\\Topper Videos";

            if (searchModes.Contains(SearchMode.ByFileNameExactMatch))
            {
                wheelImages.AddRange(GetMedia(wheelPath, model.FileName));
                flyers.AddRange(GetMedia(flyerPath, model.FileName, true));
                instructionCards.AddRange(GetMedia(instructionCardpath, model.FileName, true));
                backglassImages.AddRange(GetMedia(backglassImagePath, model.FileName));
                backglassVideos.AddRange(GetMedia(backglassVideoPath, model.FileName));
                dmdImages.AddRange(GetMedia(dmdImagePath, model.FileName));
                dmdVideos.AddRange(GetMedia(dmdVideoPath, model.FileName));
                launchAudios.AddRange(GetMedia(launchAudioPath, model.FileName));
                realDmdColorImages.AddRange(GetMedia(realDmdColorImagePath, model.FileName));
                realDmdColorVideos.AddRange(GetMedia(realDmdColorVideoPath, model.FileName));
                realDmdImages.AddRange(GetMedia(realDmdImagePath, model.FileName));
                realDmdVideos.AddRange(GetMedia(realDmdVideoPath, model.FileName));
                tableAudios.AddRange(GetMedia(tableAudioPath, model.FileName));
                tableImages.AddRange(GetMedia(tableImagePath, model.FileName));
                tableVideos.AddRange(GetMedia(tableVideoPath, model.FileName));
                tableDesktopImages.AddRange(GetMedia(tableImageDesktopPath, model.FileName));
                tableDesktopVideos.AddRange(GetMedia(tableVideoDesktopPath, model.FileName));
                topperImages.AddRange(GetMedia(topperImagePath, model.FileName));
                topperVideos.AddRange(GetMedia(topperVideoPath, model.FileName));
            }
            if (searchModes.Contains(SearchMode.ByDescriptionExactMatch))
            {
                wheelImages.AddRange(GetMedia(wheelPath, model.Description));
                flyers.AddRange(GetMedia(flyerPath, model.Description, true));
                instructionCards.AddRange(GetMedia(instructionCardpath, model.Description, true));
                backglassImages.AddRange(GetMedia(backglassImagePath, model.Description));
                backglassVideos.AddRange(GetMedia(backglassVideoPath, model.Description));
                dmdImages.AddRange(GetMedia(dmdImagePath, model.Description));
                dmdVideos.AddRange(GetMedia(dmdVideoPath, model.Description));
                launchAudios.AddRange(GetMedia(launchAudioPath, model.Description));
                realDmdColorImages.AddRange(GetMedia(realDmdColorImagePath, model.Description));
                realDmdColorVideos.AddRange(GetMedia(realDmdColorVideoPath, model.Description));
                realDmdImages.AddRange(GetMedia(realDmdImagePath, model.Description));
                realDmdVideos.AddRange(GetMedia(realDmdVideoPath, model.Description));
                tableAudios.AddRange(GetMedia(tableAudioPath, model.Description));
                tableImages.AddRange(GetMedia(tableImagePath, model.Description));
                tableVideos.AddRange(GetMedia(tableVideoPath, model.Description));
                tableDesktopImages.AddRange(GetMedia(tableImageDesktopPath, model.Description));
                tableDesktopVideos.AddRange(GetMedia(tableVideoDesktopPath, model.Description));
                topperImages.AddRange(GetMedia(topperImagePath, model.Description));
                topperVideos.AddRange(GetMedia(topperVideoPath, model.Description));
            }

            if (wheelImages.Count() > 0)
                model.HasWheelImage = true;
            if (flyers.Count() > 0)
                model.HasFlyer = true;
            if (instructionCards.Count() > 0)
                model.HasInstructionCard = true;
            if (backglassImages.Count() > 0)
                model.BackglassStatus = MediaStatus.Image;
            if (backglassVideos.Count() > 0)
                model.BackglassStatus = model.BackglassStatus == MediaStatus.Image ? MediaStatus.ImageAndVideo : MediaStatus.Video;
            if (dmdImages.Count() > 0)
                model.DMDStatus = MediaStatus.Image;
            if (dmdVideos.Count() > 0)
                model.DMDStatus = model.DMDStatus == MediaStatus.Image ? MediaStatus.ImageAndVideo : MediaStatus.Video;
            if (launchAudios.Count() > 0)
                model.HasLaunchAudio = true;
            if (realDmdColorImages.Count() > 0)
                model.RealDMDColorStatus = MediaStatus.Image;
            if (realDmdColorVideos.Count() > 0)
                model.RealDMDColorStatus = model.RealDMDColorStatus == MediaStatus.Image ? MediaStatus.ImageAndVideo : MediaStatus.Video;
            if (realDmdImages.Count() > 0)
                model.ReadDMDStatus = MediaStatus.Image;
            if (realDmdVideos.Count() > 0)
                model.ReadDMDStatus = model.ReadDMDStatus == MediaStatus.Image ? MediaStatus.ImageAndVideo : MediaStatus.Video;
            if (launchAudios.Count() > 0)
                model.HasTableAudio = true;
            if (tableImages.Count() > 0)
                model.TableStatus = MediaStatus.Image;
            if (tableVideos.Count() > 0)
                model.TableStatus = model.TableStatus == MediaStatus.Image ? MediaStatus.ImageAndVideo : MediaStatus.Video;
            if (tableDesktopImages.Count() > 0)
                model.TableDesktopStatus = MediaStatus.Image;
            if (tableDesktopVideos.Count() > 0)
                model.TableDesktopStatus = model.TableDesktopStatus == MediaStatus.Image ? MediaStatus.ImageAndVideo : MediaStatus.Video;
            if (topperImages.Count() > 0)
                model.TopperStatus = MediaStatus.Image;
            if (topperVideos.Count() > 0)
                model.TopperStatus = model.TopperStatus == MediaStatus.Image ? MediaStatus.ImageAndVideo : MediaStatus.Video;
        }

        private List<string> GetMedia(string searchPath, string fileNameSearchText, bool searchSubDirectorys = false)
        {
            List<string> mediaFilesFound = new List<string>();
            string[] files = null;
            if (searchSubDirectorys)
                files = Directory.GetFiles(searchPath, fileNameSearchText + "*", SearchOption.AllDirectories);
            else
                files = Directory.GetFiles(searchPath, fileNameSearchText + "*", SearchOption.TopDirectoryOnly);
            mediaFilesFound.AddRange(files.Where(p => Path.GetFileNameWithoutExtension(p) == fileNameSearchText));
            return mediaFilesFound;
        }
    }
}
