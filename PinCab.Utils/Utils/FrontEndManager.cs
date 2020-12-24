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

        public List<string> GetFrontEndWarnings(FrontEnd frontEnd)
        {
            var warnings = new List<string>();
            if (frontEnd.System == FrontEndSystem.PinballX)
            {
                //Ensure that fuzzy file matching is turned off, if not tell the user to fix it.
                var iniData = _pinballXManager.ParseIni(_settings.PinballXIniPath);
                if (iniData["FileSystem"]["EnableFileMatching"].ToLower() == "true")
                    warnings.Add("File matching is turned on. Launch PinballX Settings and turn off file matching or you may get unpredictable media showing in the front end. This program relies on this setting being turned off for it's media auditing function to work properly.");
            }
            return warnings;
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

        public List<MediaAuditResult> GetMediaAuditResults(FrontEnd frontEnd)
        {
            var auditResults = new List<MediaAuditResult>();
            if (frontEnd != null)
            {
                if (frontEnd.System == FrontEndSystem.PinballX)
                {
                    var games = new List<FrontEndGameViewModel>();
                    foreach (var system in _pinballXSystems) 
                    {
                        foreach(var database in system.DatabaseFiles)
                            games.AddRange(GetPinballXFrontEndGames(frontEnd, database));
                    }
                    //Now that we have all the games loaded and we have the statuses on all the media we can check into stranded media
                    //by parsing all the media folders and getting every file inside of it, and matching it up with the games.MediaItems files
                    //and if we have files that don't exist in the games.MediaItems list it is considered a stranded media item
                    List<string> allGameMedia = new List<string>();
                    foreach(var game in games)
                        allGameMedia.AddRange(game.MediaItems.Select(c => c.MediaFullPath));

                    var allMediaFiles = GetAllMediaItems(frontEnd);

                    foreach(var media in allMediaFiles)
                    {
                        if (!allGameMedia.Contains(media.MediaFullPath))
                            auditResults.Add(new MediaAuditResult() { FrontEnd = frontEnd, FullPathToFile = media.MediaFullPath, Status = MediaAuditStatus.UnusedMedia, MediaType = media.MediaType });
                    }
                }
            }
            return auditResults;
        }

        public List<MediaItem> GetAllMediaItems(FrontEnd frontEnd)
        {
            var mediaItems = new List<MediaItem>();

            if (frontEnd.System == FrontEndSystem.PinballX)
            {
                foreach (var system in _pinballXSystems)
                {
                    Log.Information("GetAllMediaItems: Processing PinballX System: {name}. Media Path: {path}", system.Name, system.MediaPath);
                    var rootMediaPath = system.MediaPath.Replace(system.Name, string.Empty);
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

                    mediaItems.AddRange(GetMediaItemsInDirectory(MediaCategory.Wheel, wheelPath));
                    mediaItems.AddRange(GetMediaItemsInDirectory(MediaCategory.Flyer, flyerPath));
                    mediaItems.AddRange(GetMediaItemsInDirectory(MediaCategory.InstructionCard, instructionCardpath));
                    mediaItems.AddRange(GetMediaItemsInDirectory(MediaCategory.Backglass, backglassImagePath));
                    mediaItems.AddRange(GetMediaItemsInDirectory(MediaCategory.Backglass, backglassVideoPath));
                    mediaItems.AddRange(GetMediaItemsInDirectory(MediaCategory.DMD, dmdImagePath));
                    mediaItems.AddRange(GetMediaItemsInDirectory(MediaCategory.DMD, dmdVideoPath));
                    mediaItems.AddRange(GetMediaItemsInDirectory(MediaCategory.Launch, launchAudioPath));
                    mediaItems.AddRange(GetMediaItemsInDirectory(MediaCategory.RealDmdColor, realDmdColorImagePath));
                    mediaItems.AddRange(GetMediaItemsInDirectory(MediaCategory.RealDmdColor, realDmdColorVideoPath));
                    mediaItems.AddRange(GetMediaItemsInDirectory(MediaCategory.RealDmd, realDmdImagePath));
                    mediaItems.AddRange(GetMediaItemsInDirectory(MediaCategory.RealDmd, realDmdVideoPath));
                    mediaItems.AddRange(GetMediaItemsInDirectory(MediaCategory.Table, tableAudioPath));
                    mediaItems.AddRange(GetMediaItemsInDirectory(MediaCategory.Table, tableImagePath));
                    mediaItems.AddRange(GetMediaItemsInDirectory(MediaCategory.Table, tableVideoPath));
                    mediaItems.AddRange(GetMediaItemsInDirectory(MediaCategory.TableDesktop, tableImageDesktopPath));
                    mediaItems.AddRange(GetMediaItemsInDirectory(MediaCategory.TableDesktop, tableVideoDesktopPath));
                    mediaItems.AddRange(GetMediaItemsInDirectory(MediaCategory.Topper, topperImagePath));
                    mediaItems.AddRange(GetMediaItemsInDirectory(MediaCategory.Topper, topperVideoPath));
                }
            }

            return mediaItems;
        }

        private List<MediaItem> GetMediaItemsInDirectory(MediaCategory category, string directory)
        {
            var mediaItems = new List<MediaItem>();
            
            if (Directory.Exists(directory))
            {
                var filesInDirectory = Directory.GetFiles(directory, "*.*", SearchOption.AllDirectories);
                foreach(var filePath in filesInDirectory)
                {
                    var mediaItem = new MediaItem() { Category = category, MediaFullPath = filePath };
                    var mimeType = MimeTypes.MimeTypeMap.GetMimeType(filePath);
                    if (mimeType.Contains("audio"))
                        mediaItem.MediaType = MediaType.Audio;
                    else if (mimeType.Contains("video"))
                        mediaItem.MediaType = MediaType.Video;
                    else if (mimeType.Contains("image"))
                        mediaItem.MediaType = MediaType.Image;
                    mediaItems.Add(mediaItem);
                }
            }

            return mediaItems;
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
            {
                model.HasWheelImage = true;
                model.MediaItems.AddRange(wheelImages.Select(c => new MediaItem() { Category = MediaCategory.Wheel, MediaFullPath = c, MediaType = MediaType.Image }));
            }
            if (flyers.Count() > 0)
            {
                model.HasFlyer = true;
                model.MediaItems.AddRange(flyers.Select(c => new MediaItem() { Category = MediaCategory.Flyer, MediaFullPath = c, MediaType = MediaType.Image }));
            }
            if (instructionCards.Count() > 0)
            {
                model.HasInstructionCard = true;
                model.MediaItems.AddRange(instructionCards.Select(c => new MediaItem() { Category = MediaCategory.InstructionCard, MediaFullPath = c, MediaType = MediaType.Image }));
            }
            if (backglassImages.Count() > 0)
            {
                model.BackglassStatus = MediaStatus.Image;
                model.MediaItems.AddRange(backglassImages.Select(c => new MediaItem() { Category = MediaCategory.Backglass, MediaFullPath = c, MediaType = MediaType.Image }));
            }
            if (backglassVideos.Count() > 0)
            {
                model.BackglassStatus = model.BackglassStatus == MediaStatus.Image ? MediaStatus.ImageAndVideo : MediaStatus.Video;
                model.MediaItems.AddRange(backglassVideos.Select(c => new MediaItem() { Category = MediaCategory.Backglass, MediaFullPath = c, MediaType = MediaType.Video }));
            }
            if (dmdImages.Count() > 0)
            {
                model.DMDStatus = MediaStatus.Image;
                model.MediaItems.AddRange(dmdImages.Select(c => new MediaItem() { Category = MediaCategory.DMD, MediaFullPath = c, MediaType = MediaType.Image }));
            }
            if (dmdVideos.Count() > 0)
            {
                model.DMDStatus = model.DMDStatus == MediaStatus.Image ? MediaStatus.ImageAndVideo : MediaStatus.Video;
                model.MediaItems.AddRange(dmdVideos.Select(c => new MediaItem() { Category = MediaCategory.DMD, MediaFullPath = c, MediaType = MediaType.Video }));
            }
            if (launchAudios.Count() > 0)
            {
                model.HasLaunchAudio = true;
                model.MediaItems.AddRange(launchAudios.Select(c => new MediaItem() { Category = MediaCategory.Launch, MediaFullPath = c, MediaType = MediaType.Audio }));
            }
            if (realDmdColorImages.Count() > 0)
            {
                model.RealDMDColorStatus = MediaStatus.Image;
                model.MediaItems.AddRange(realDmdColorImages.Select(c => new MediaItem() { Category = MediaCategory.RealDmdColor, MediaFullPath = c, MediaType = MediaType.Image }));
            }
            if (realDmdColorVideos.Count() > 0)
            {
                model.RealDMDColorStatus = model.RealDMDColorStatus == MediaStatus.Image ? MediaStatus.ImageAndVideo : MediaStatus.Video;
                model.MediaItems.AddRange(realDmdColorVideos.Select(c => new MediaItem() { Category = MediaCategory.RealDmdColor, MediaFullPath = c, MediaType = MediaType.Video }));
            }
            if (realDmdImages.Count() > 0)
            {
                model.ReadDMDStatus = MediaStatus.Image;
                model.MediaItems.AddRange(realDmdImages.Select(c => new MediaItem() { Category = MediaCategory.RealDmd, MediaFullPath = c, MediaType = MediaType.Image }));
            }
            if (realDmdVideos.Count() > 0)
            {
                model.ReadDMDStatus = model.ReadDMDStatus == MediaStatus.Image ? MediaStatus.ImageAndVideo : MediaStatus.Video;
                model.MediaItems.AddRange(realDmdVideos.Select(c => new MediaItem() { Category = MediaCategory.RealDmd, MediaFullPath = c, MediaType = MediaType.Video }));
            }
            if (launchAudios.Count() > 0)
            {
                model.HasTableAudio = true;
                model.MediaItems.AddRange(launchAudios.Select(c => new MediaItem() { Category = MediaCategory.Launch, MediaFullPath = c, MediaType = MediaType.Audio }));
            }
            if (tableImages.Count() > 0)
            {
                model.TableStatus = MediaStatus.Image;
                model.MediaItems.AddRange(tableImages.Select(c => new MediaItem() { Category = MediaCategory.Table, MediaFullPath = c, MediaType = MediaType.Image }));
            }
            if (tableVideos.Count() > 0)
            {
                model.TableStatus = model.TableStatus == MediaStatus.Image ? MediaStatus.ImageAndVideo : MediaStatus.Video;
                model.MediaItems.AddRange(tableVideos.Select(c => new MediaItem() { Category = MediaCategory.Table, MediaFullPath = c, MediaType = MediaType.Video }));
            }
            if (tableDesktopImages.Count() > 0)
            {
                model.TableDesktopStatus = MediaStatus.Image;
                model.MediaItems.AddRange(tableDesktopImages.Select(c => new MediaItem() { Category = MediaCategory.TableDesktop, MediaFullPath = c, MediaType = MediaType.Image }));
            }
            if (tableDesktopVideos.Count() > 0)
            {
                model.TableDesktopStatus = model.TableDesktopStatus == MediaStatus.Image ? MediaStatus.ImageAndVideo : MediaStatus.Video;
                model.MediaItems.AddRange(tableDesktopVideos.Select(c => new MediaItem() { Category = MediaCategory.TableDesktop, MediaFullPath = c, MediaType = MediaType.Video }));
            }
            if (topperImages.Count() > 0)
            {
                model.TopperStatus = MediaStatus.Image;
                model.MediaItems.AddRange(topperImages.Select(c => new MediaItem() { Category = MediaCategory.Topper, MediaFullPath = c, MediaType = MediaType.Image }));
            }
            if (topperVideos.Count() > 0)
            {
                model.TopperStatus = model.TopperStatus == MediaStatus.Image ? MediaStatus.ImageAndVideo : MediaStatus.Video;
                model.MediaItems.AddRange(topperVideos.Select(c => new MediaItem() { Category = MediaCategory.Topper, MediaFullPath = c, MediaType = MediaType.Video }));
            }
        }

        private List<string> GetMedia(string searchPath, string fileNameSearchText, bool searchSubDirectorys = false)
        {
            List<string> mediaFilesFound = new List<string>();
            if (Directory.Exists(searchPath))
            {
                string[] files = null;
                if (searchSubDirectorys)
                    files = Directory.GetFiles(searchPath, fileNameSearchText + "*", SearchOption.AllDirectories);
                else
                    files = Directory.GetFiles(searchPath, fileNameSearchText + "*", SearchOption.TopDirectoryOnly);
                mediaFilesFound.AddRange(files.Where(p => Path.GetFileNameWithoutExtension(p) == fileNameSearchText));
            }
            return mediaFilesFound;
        }
    }
}
