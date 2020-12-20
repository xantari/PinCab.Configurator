using IniParser;
using IniParser.Model;
using Newtonsoft.Json;
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

        public PinballXManager(string pinballXIni)
        {
            _pinballXIni = pinballXIni;
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
            // only notify after this block

            var data = ParseIni(_pinballXIni);
            if (data != null)
            {
                if (data["VisualPinball"] != null)
                {
                    systems.Add(new PinballXSystem(_pinballXIni, "Visual Pinball", data["VisualPinball"]));
                }
                if (data["FuturePinball"] != null)
                {
                    systems.Add(new PinballXSystem(_pinballXIni, "Future Pinball", data["FuturePinball"]));
                }

                for (var i = 0; i < 20; i++)
                {
                    var systemName = "System_" + i;
                    if (data[systemName] != null && data[systemName].Count > 0)
                    {
                        systems.Add(new PinballXSystem(_pinballXIni, null, data[systemName]));
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

        public void SaveDatabase(PinballXSystem system, string databaseFile)
        {
            if (system.DatabaseFiles.Contains(databaseFile))
            {
                var menu = new PinballXMenu();
                menu.Games = system.Games[databaseFile];
                MarshallXml(menu, databaseFile);
            }
            else 
            {
                Log.Information("Cannot find database file {0} to save in the database files collection for system: {1}.", databaseFile, system.Name);
            }
        }
    }
}
