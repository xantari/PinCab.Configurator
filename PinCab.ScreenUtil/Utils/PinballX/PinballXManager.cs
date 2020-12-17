using IniParser;
using IniParser.Model;
using Newtonsoft.Json;
using PinCab.ScreenUtil.Models.PinballX;
using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PinCab.ScreenUtil.Utils.PinballX
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
				var serializer = new XmlSerializer(typeof(PinballXMenu));
				using (TextWriter writer = new StreamWriter(databaseXmlFilePath))
				{
					serializer.Serialize(writer, menu);
					Log.Logger.Information("Saved {0}.", databaseXmlFilePath);
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
            Log.Logger.Information("Parsed {0} systems from {1}.", systems.Count, _pinballXIni);

            return systems;
        }


        //private List<PinballXGame> ParseGames(string databaseXmlFilePath)
        //{
        //    var xmlPath = Path.Combine(DatabasePath, databaseXmlFilePath);
        //    var games = new List<PinballXGame>();
        //    if (Directory.Exists(DatabasePath))
        //    {
        //        var menu = UnmarshallXml(xmlPath);
        //        var remainingExecutables = Executables.ToList();
        //        menu.Games.ForEach(game =>
        //        {

        //            // update links
        //            game.System = this;
        //            game.DatabaseFile = databaseXmlFilePath;

        //            // update executables
        //            var executable = game.AlternateExe != null && game.AlternateExe.Trim() != "" ? game.AlternateExe : DefaultExecutableLabel;
        //            if (!Executables.Contains(executable))
        //            {
        //                _logger.Debug("Adding new alternate executable \"{0}\" to system \"{1}\"", executable, Name);
        //                Executables.Add(executable);
        //            }
        //            else
        //            {
        //                if (remainingExecutables.Contains(executable))
        //                {
        //                    remainingExecutables.Remove(executable);
        //                }
        //            }
        //        });
        //        _logger.Debug("Removing alternate executables [ \"{0}\" ] from system \"{1}\"", string.Join("\", \"", remainingExecutables), Name);
        //        //Executables.RemoveAll(remainingExecutables));
        //        Executables.Sort(string.Compare);

        //        games.AddRange(menu.Games);
        //    }
        //    _logger.Debug("Parsed {0} games from {1}.", games.Count, xmlPath);
        //    return games;
        //}
    }
}
