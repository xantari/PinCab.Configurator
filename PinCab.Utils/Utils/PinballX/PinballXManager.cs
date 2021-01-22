using IniParser;
using IniParser.Model;
using Newtonsoft.Json;
using PinCab.Utils.Models;
using PinCab.Utils.Models.PinballX;
using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace PinCab.Utils.Utils.PinballX
{
    public class PinballXManager
    {
        // dependencies
        private string _pinballXIni;
        private string _pinballXStatisticsIni;
        private IniData _statisticsData = null;

        public PinballXManager(string pinballXIni)
        {
            _pinballXIni = pinballXIni;
            FileInfo info = new FileInfo(pinballXIni);
            _pinballXStatisticsIni = info.DirectoryName.Replace("\\Config","") + "\\Databases\\statistics.ini";
        }

        public IniData ParseIni(string path)
        {
            if (File.Exists(path))
            {
                var parser = new FileIniDataParser();
                return parser.ReadFile(path);
            }
            Log.Logger.Error("Ini file at {0} does not exist.", path);
            return null;
        }

        public PinballXMenu UnmarshallXml(string databaseXmlFilePath)
        {
            var menu = new PinballXMenu();

            if (!File.Exists(databaseXmlFilePath))
            {
                return menu;
            }
            Stream reader = null;
            try
            {
                var serializer = new XmlSerializer(typeof(PinballXMenu));
                reader = new FileStream(databaseXmlFilePath, FileMode.Open);
                menu = serializer.Deserialize(reader) as PinballXMenu;
            }
            catch (FileNotFoundException)
            {
                // ignore: http://stackoverflow.com/questions/1127431/xmlserializer-giving-filenotfoundexception-at-constructor
            }
            catch (Exception e)
            {
                Log.Logger.Error(e, "Error parsing {0}: {1}", databaseXmlFilePath, e.Message);
            }
            finally
            {
                reader?.Close();
            }
            return menu;
        }

        public void MarshallXml(PinballXMenu menu, string databaseXmlFilePath)
        {
            try
            {
                var settings = new XmlWriterSettings
                {
                    Encoding = Encoding.GetEncoding(1252),
                    OmitXmlDeclaration = false,
                    IndentChars = "    ", //Match Pinball X formatting
                    Indent = true
                };
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", "");
                var serializer = new XmlSerializer(typeof(PinballXMenu));
                var fi = new FileInfo(databaseXmlFilePath);
                if (!Directory.Exists(fi.DirectoryName))
                {
                    Log.Logger.Information("Directory didn't exist. Created it. Dir: {0}.", fi.DirectoryName);
                    Directory.CreateDirectory(fi.DirectoryName);
                }
                using (var fs = new FileStream(databaseXmlFilePath, FileMode.Create))
                {
                    using (var writer = XmlWriter.Create(fs, settings))
                    {
                        serializer.Serialize(writer, menu, ns);
                        Log.Logger.Information("Saved {0}.", databaseXmlFilePath);
                    }
                }
            }
            catch (Exception e)
            {
                Log.Logger.Error(e, "Error writing XML to {0}: {1}", databaseXmlFilePath, e.Message);
            }
        }

        /// <summary>
        /// Parses PinballX.ini and reads all systems from it.
        /// </summary>
        /// <returns>Parsed systems</returns>
        public List<PinballXSystem> ParseSystems()
        {
            var systems = new List<PinballXSystem>();

            var data = ParseIni(_pinballXIni);
            if (data != null)
            {
                if (data["VisualPinball"] != null)
                {
                    systems.Add(new PinballXSystem(_pinballXIni, "Visual Pinball", data["VisualPinball"], Platform.VP));
                }
                if (data["FuturePinball"] != null)
                {
                    systems.Add(new PinballXSystem(_pinballXIni, "Future Pinball", data["FuturePinball"], Platform.FP));
                }
                if (data["PinballFX3"] != null)
                {
                    systems.Add(new PinballXSystem(_pinballXIni, "Pinball FX3", data["PinballFX3"], Platform.PinballFX3));
                }
                if (data["PinballFX2"] != null)
                {
                    systems.Add(new PinballXSystem(_pinballXIni, "Pinball FX2", data["PinballFX2"], Platform.PinballFX2));
                }
                if (data["PinballArcade"] != null)
                {
                    systems.Add(new PinballXSystem(_pinballXIni, "Pinball Arcade", data["PinballArcade"], Platform.PinballArcade));
                }

                for (var i = 0; i < 20; i++)
                {
                    var systemName = "System_" + i;
                    if (data[systemName] != null && data[systemName].Count > 0)
                    {
                        var system = new PinballXSystem(_pinballXIni, null, data[systemName], null);
                        if (system.IsValid())
                            systems.Add(system);
                    }
                }
            }
            Log.Information("Parsed {0} systems from {1}.", systems.Count, _pinballXIni);

            foreach (var system in systems)
                ParseGames(system);

            return systems;
        }

        public PinballXSystem ParseGames(PinballXSystem system)
        {
            foreach (var databaseFile in system.DatabaseFiles)
            {
                var xmlPath = Path.Combine(system.DatabasePath, databaseFile);
                var games = new List<PinballXGame>();
                if (Directory.Exists(system.DatabasePath))
                {
                    var menu = UnmarshallXml(xmlPath);
                    menu.Games.ForEach(game =>
                    {
                        // update links
                        game.System = system;
                        game.DatabaseFile = databaseFile;

                        // update executables
                        string executable = !string.IsNullOrWhiteSpace(game.AlternateExe) ? game.AlternateExe : system.DefaultExecutableLabel;
                        if (!system.Executables.Contains(executable))
                        {
                            Log.Debug("Adding new alternate executable \"{0}\" to system \"{1}\"", executable, system.Name);
                            system.Executables.Add(executable);
                        }
                    });
                    system.Executables.Sort(string.Compare);

                    games.AddRange(menu.Games);
                }
                Log.Debug("Parsed {0} games from {1}.", games.Count, xmlPath);
                system.Games.Add(databaseFile, games);
            }
            return system;
        }

        public void BackupDatabase(PinballXSystem system, string databaseFile)
        {
            var applicationBackupFolder = ApplicationHelpers.GetApplicationFolder() + "\\Backup\\PinballX";
            FileInfo fileInfo = new FileInfo(databaseFile);
            string backupDatabaseFileName = $"{applicationBackupFolder}\\{fileInfo.Directory.Name}\\{fileInfo.Name}_{DateTime.Now.ToString("yyyy-MM-dd_HHmmss")}";
            if (system.DatabaseFiles.Contains(databaseFile))
            {
                var menu = new PinballXMenu();
                menu.Games = system.Games[databaseFile];
                MarshallXml(menu, backupDatabaseFileName);
            }
            else
            {
                Log.Information("Cannot find database file {0} to save in the database files collection for system: {1}.", databaseFile, system.Name);
            }
        }

        public void AddOrUpdateGame(PinballXSystem system, string databaseFile, PinballXGame game)
        {
            game.System = system;
            game.DatabaseFile = databaseFile;
            var existingGame = system.Games[databaseFile].FirstOrDefault(p => p.FileName == game.FileName);
            if (existingGame != null)
                existingGame = game;
            else
                system.Games[databaseFile].Add(game);
        }

        public void DeleteGame(PinballXSystem system, string databaseFile, PinballXGame game)
        {
            system.Games[databaseFile].Remove(game);
        }

        public void SaveDatabase(PinballXSystem system, string databaseFile, bool backupDatabase)
        {
            if (system.DatabaseFiles.Contains(databaseFile))
            {
                if (backupDatabase)
                    BackupDatabase(system, databaseFile);

                var menu = new PinballXMenu();
                menu.Games = system.Games[databaseFile];
                MarshallXml(menu, databaseFile);
            }
            else
            {
                Log.Information("Cannot find database file {0} to save in the database files collection for system: {1}.", databaseFile, system.Name);
            }
        }

        public StatisticsData GetStatisticsData(string systemName, string tableName)
        {
            var stats = new StatisticsData();

            if (_statisticsData == null) //Load only one time
                _statisticsData = ParseIni(_pinballXStatisticsIni);

            string sSection = (systemName + "_" + tableName.Replace(" ", "_")).Replace("(", "").Replace(")", "").Replace("!", "").Replace(".", "").Replace("-", "").Replace("'", "");
            if (_statisticsData != null)
            {
                if (_statisticsData.Sections.Any(p => p.SectionName == sSection))
                {
                    var section = _statisticsData.Sections[sSection];
                    if (section.ContainsKey("timesplayed") && section["timesplayed"] != string.Empty)
                    {
                        stats.TimesPlayed = Convert.ToInt32(section["timesplayed"]);
                    }
                    if (section.ContainsKey("secondsplayed") && section["secondsplayed"] != string.Empty)
                    {
                        stats.SecondsPlayed = Convert.ToInt32(section["secondsplayed"]);
                    }
                    if (section.ContainsKey("favorite") && section["favorite"] != string.Empty)
                    {
                        stats.Favorite = Convert.ToBoolean(section["favorite"]);
                    }
                    if (section.ContainsKey("dateadded") && section["dateadded"] != string.Empty)
                    {
                        stats.DateAdded = Convert.ToDateTime(section["dateadded"]); //yyyy-MM-dd HH:mm:ss
                    }
                    return stats;
                }
                return null;
            }
            else
            {
                return null;
            }
        }
    }
}
