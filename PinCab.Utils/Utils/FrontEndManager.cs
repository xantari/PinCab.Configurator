using PinCab.Utils.Extensions;
using PinCab.Utils.Models;
using PinCab.Utils.Models.PinballX;
using PinCab.Utils.Utils.PinballX;
using PinCab.Utils.ViewModels;
using Serilog;
using Serilog.Core;
using System;
using System.Collections.Generic;
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
                    frontEndGames = GetPinballXFrontEndGames(frontEnd,databaseFile);
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
                        frontEndGames.Add(frontEndGame);
                    }
                }
            }
            return frontEndGames;
        }
    }
}
