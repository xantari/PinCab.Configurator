using Dapper;
using PinCab.ScreenUtil.Models.PinupPopper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinCab.ScreenUtil.Utils.PinupPopper
{
    public class PinupPopperRepository : PinupPopperBaseRepository
    {
        public PinupPopperRepository(string dbFile) : base(dbFile)
        {
        }

        public Screen GetScreen(int screenId)
        {
            if (!ValidateConnection()) return null;

            using (var cnn = PinupPopperConnection())
            {
                cnn.Open();
                Screen result = cnn.Query<Screen>(
                    @"SELECT ScreenID, ScreenName, ScreenDisplay, POSx, POSy, ScreenWidth, ScreenHeight, WindowState, FullScreen, Visible, VerifyPOS, 
                    Rotation, MonitorNum, ScreenType, RotateThumbs, ThumbWidth, ThumbHeight, AlphaBlend
                    FROM Screens
                    WHERE ScreenID = @id", new { screenId }).FirstOrDefault();
                return result;
            }
        }

        public List<Screen> GetAllScreens()
        {
            if (!ValidateConnection()) return null;

            using (var cnn = PinupPopperConnection())
            {
                cnn.Open();
                var result = cnn.Query<Screen>(
                    @"SELECT ScreenID, ScreenName, ScreenDisplay, POSx, POSy, ScreenWidth, ScreenHeight, WindowState, FullScreen, Visible, VerifyPOS, 
                    Rotation, MonitorNum, ScreenType, RotateThumbs, ThumbWidth, ThumbHeight, AlphaBlend
                    FROM Screens").ToList();
                return result;
            }
        }

        public GlobalSettings GetSettings()
        {
            if (!ValidateConnection()) return null;

            using (var cnn = PinupPopperConnection())
            {
                cnn.Open();
                GlobalSettings result = cnn.Query<GlobalSettings>(
                    @"SELECT Name, GlobalMediaDir, SQLVersion, ID, ToolbarColor, ToolbarHoriz, ThumbSizeX, ThumbSizeY, ThumbMiniX, ThumbMiniY, CustomThumbSize, attractTimeOut, AttractModeMode, AttractModeinterval, AttractmodeVolume, ThumbRotate, ThumbPosY, AllowJoy, ThumbDistX, ThumbDistY, ThumbCount, ToolBarTransparent, KeepONTop, display0, display1, display2, display3, display4, display5, display6, display7, display8, display9, display10, display11, display12, StartupBatch, CloseBatch, SYSVOLUME, WheelPaddingX, WheelPaddingY, GlobalOptions, WheelFadeTime, WheelUseBG, WheelFade, SysFuncPasscode, GlobalMediaDirShare, MediaTruncate, StartUpType, LastPlayListID, LastGameID, NextPageByChar, useMediaSearch, useRecording, StartLockdown, useMostPlayed, useFavourites, useRecentPlay, useOtherPlay, FavsonHome, WheelDirection, useSystemfuncs, DateLastBackup
                    FROM GlobalSettings").FirstOrDefault();
                return result;
            }
        }

        public List<Game> GetGames()
        {
            if (!ValidateConnection()) return null;

            using (var cnn = PinupPopperConnection())
            {
                cnn.Open();
                var result = cnn.Query<Game>(
                    @"SELECT GameID, EMUID, GameName, GameFileName, GameDisplay, UseEmuDefaults, Visible, Notes, DateAdded, GameYear, ROM, Manufact, NumPlayers, ResolutionX, ResolutionY, OutputScreen, ThemeColor, GameType, TAGS, Category, Author, LaunchCustomVar, GKeepDisplays, GameTheme, GameRating, Special, sysVolume, DOFStuff, MediaSearch, AudioChannels, CUSTOM2, CUSTOM3, GAMEVER, ALTEXE, IPDBNum, DateUpdated, DateFileUpdated, AutoRecFlag, AltRunMode, WebLinkURL, DesignedBy
                        FROM Games;").ToList();
                return result;
            }
        }

        public Game GetGameById(int gameId)
        {
            if (!ValidateConnection()) return null;

            using (var cnn = PinupPopperConnection())
            {
                cnn.Open();
                var result = cnn.Query<Game>(
                    @"SELECT GameID, EMUID, GameName, GameFileName, GameDisplay, UseEmuDefaults, Visible, Notes, DateAdded, GameYear, ROM, Manufact, NumPlayers, ResolutionX, ResolutionY, OutputScreen, ThemeColor, GameType, TAGS, Category, Author, LaunchCustomVar, GKeepDisplays, GameTheme, GameRating, Special, sysVolume, DOFStuff, MediaSearch, AudioChannels, CUSTOM2, CUSTOM3, GAMEVER, ALTEXE, IPDBNum, DateUpdated, DateFileUpdated, AutoRecFlag, AltRunMode, WebLinkURL, DesignedBy
                        FROM Games
                        WHERE GameID = @gameId", new { gameId }).FirstOrDefault();
                return result;
            }
        }
    }
}
