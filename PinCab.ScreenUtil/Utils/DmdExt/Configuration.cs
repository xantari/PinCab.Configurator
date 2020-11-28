using IniParser;
using IniParser.Model;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinCab.ScreenUtil.Utils.DmdExt
{
    public class Configuration
    {
        private readonly string _iniPath;
        private readonly FileIniDataParser _parser;
        private readonly IniData _data;
		private string _gameName;
		public GameConfig GameConfig { get; private set; }
		public bool HasGameName => _gameName != null;
		public IVirtualDmdConfig VirtualDmd { get; }

		public string GameName
		{
			get => _gameName;
			set
			{
				_gameName = value;
				var gameSection = _data.Sections.FirstOrDefault(s => s.SectionName == _gameName);
				GameConfig = gameSection != null ? new GameConfig(_gameName, _data, this) : null;
			}
		}

		public Configuration(string iniPath = null)
		{
			if (!string.IsNullOrEmpty(iniPath))
			{
				if (!File.Exists(iniPath))
				{
					throw new IniNotFoundException(iniPath);
				}
				_iniPath = iniPath;
			}
			else
				throw new IniNotFoundException(iniPath);

			_parser = new FileIniDataParser();
			_data = _parser.ReadFile(_iniPath);


			VirtualDmd = new VirtualDmdConfig(_data, this);
		}

		public void Save()
		{
			_parser.WriteFile(_iniPath, _data); //Writes as UTF8 with BOM
		}
	}

	public class VirtualDmdConfig : AbstractConfiguration, IVirtualDmdConfig
	{
		public override string Name { get; } = "virtualdmd";

		public bool Enabled => GetBoolean("enabled", true);
		public bool StayOnTop => GetBoolean("stayontop", false);
		public bool IgnoreAr => GetBoolean("ignorear", false);
		public bool UseRegistryPosition => GetBoolean("useregistry", false);
		public double Left => GetDouble("left", 0);
		public double Top => GetDouble("top", 0);

		public double Width => GetDouble("width", 1024);
		public double Height => GetDouble("height", 256);
		public double DotSize => GetDouble("dotsize", 1.0);

		public VirtualDmdConfig(IniData data, Configuration parent) : base(data, parent)
		{
		}

		public void SetPosition(VirtualDisplayPosition position, bool onlyForGame)
		{
			DoWrite = false;
			Set("left", position.Left, onlyForGame);
			Set("top", position.Top, onlyForGame);
			Set("width", position.Width, onlyForGame);
			Set("height", position.Height, onlyForGame);
			Save();
		}

		public void SetIgnoreAspectRatio(bool ignoreAspectRatio)
		{
			DoWrite = false;
			Set("ignorear", ignoreAspectRatio, false);
			Save();
		}
	}

	public class GameConfig : AbstractConfiguration
	{
		public override string Name { get; }
		public GameConfig(string name, IniData data, Configuration parent) : base(data, parent)
		{
			Name = name;
		}
	}

	public abstract class AbstractConfiguration
	{
		public abstract string Name { get; }
		private readonly IniData _data;
		private readonly Configuration _parent;
		private string GameOverridePrefix => Name == "global" ? "" : $"{Name} ";

		protected bool DoWrite = true;

		public bool HasGameOverride(string key)
		{
			return Name != _parent.GameName && _parent.GameConfig != null && _data[_parent.GameName].ContainsKey(GameOverridePrefix + key);
		}

		protected AbstractConfiguration(IniData data, Configuration parent)
		{
			_parent = parent;
			_data = data;
		}

		protected void Save()
		{
			DoWrite = true;
			_parent.Save();
		}

		protected bool GetBoolean(string key, bool fallback)
		{
			if (HasGameSpecificValue(key))
			{
				return _parent.GameConfig.GetBoolean(GameOverridePrefix + key, fallback);
			}

			if (_data[Name] == null || !_data[Name].ContainsKey(key))
			{
				return fallback;
			}

			try
			{
				return bool.Parse(_data[Name][key]);
			}
			catch (FormatException e)
			{
				Log.Error("Value \"" + _data[Name][key] + "\" for \"" + key + "\" under [" + Name + "] must be either \"true\" or \"false\".", e);
				return fallback;
			}
		}

		protected int GetInt(string key, int fallback)
		{
			if (HasGameSpecificValue(key))
			{
				return _parent.GameConfig.GetInt(GameOverridePrefix + key, fallback);
			}

			if (_data[Name] == null || !_data[Name].ContainsKey(key))
			{
				return fallback;
			}

			try
			{
				return int.Parse(_data[Name][key]);
			}
			catch (FormatException e)
			{
				Log.Error("Value \"" + _data[Name][key] + "\" for \"" + key + "\" under [" + Name + "] must be an integer.", e);
				return fallback;
			}
		}

		protected double GetDouble(string key, double fallback)
		{
			if (HasGameSpecificValue(key))
			{
				return _parent.GameConfig.GetDouble(GameOverridePrefix + key, fallback);
			}

			if (_data[Name] == null || !_data[Name].ContainsKey(key))
			{
				return fallback;
			}

			try
			{
				return double.Parse(_data[Name][key]);
			}
			catch (FormatException)
			{
				Log.Error("Value \"" + _data[Name][key] + "\" for \"" + key + "\" under [" + Name + "] must be a floating number.");
				return fallback;
			}
		}

		protected string GetString(string key, string fallback)
		{
			if (HasGameSpecificValue(key))
			{
				return _parent.GameConfig.GetString(GameOverridePrefix + key, fallback);
			}

			if (_data[Name] == null || !_data[Name].ContainsKey(key))
			{
				return fallback;
			}
			return _data[Name][key];
		}

		protected T GetEnum<T>(string key, T fallback)
		{
			if (HasGameSpecificValue(key))
			{
				return _parent.GameConfig.GetEnum(GameOverridePrefix + key, fallback);
			}

			if (_data[Name] == null || !_data[Name].ContainsKey(key))
			{
				return fallback;
			}
			try
			{
				var e = (T)Enum.Parse(typeof(T), _data[Name][key].Substring(0, 1).ToUpper() + _data[Name][key].Substring(1));
				if (!Enum.IsDefined(typeof(T), e))
				{
					throw new ArgumentException();
				}
				return e;
			}
			catch (ArgumentException)
			{
				Log.Error("Value \"" + _data[Name][key] + "\" for \"" + key + "\" under [" + Name + "] must be one of: [ " + string.Join(", ", Enum.GetNames(typeof(T))) + "].");
				return fallback;
			}
		}

		protected void Set(string key, bool value)
		{
			if (_data[Name] == null)
			{
				_data.Sections.Add(new SectionData(Name));
			}
			_data[Name][key] = value ? "true" : "false";
			if (DoWrite)
			{
				_parent.Save();
			}
		}

		protected void Set(string key, int value)
		{
			if (_data[Name] == null)
			{
				_data.Sections.Add(new SectionData(Name));
			}
			_data[Name][key] = value.ToString();
			if (DoWrite)
			{
				_parent.Save();
			}
		}

		protected void Set(string key, double value, bool onlyForGame = false)
		{
			if (onlyForGame && CreateGameConfig())
			{
				_parent.GameConfig.Set(GameOverridePrefix + key, value);
			}
			else
			{
				if (_data[Name] == null)
				{
					_data.Sections.Add(new SectionData(Name));
				}
				_data[Name][key] = value.ToString();
				if (DoWrite)
				{
					_parent.Save();
				}
			}
		}

		protected void Set(string key, bool value, bool onlyForGame = false)
		{
			Set(key, value ? "true" : "false", onlyForGame);
		}

		protected void Set(string key, string value, bool onlyForGame = false)
		{
			if (onlyForGame && CreateGameConfig())
			{
				_parent.GameConfig.Set(GameOverridePrefix + key, value);
			}
			else
			{
				if (_data[Name] == null)
				{
					_data.Sections.Add(new SectionData(Name));
				}
				_data[Name][key] = value;
				if (DoWrite)
				{
					_parent.Save();
				}
			}
		}

		protected void Set<T>(string key, T value)
		{
			if (_data[Name] == null)
			{
				_data.Sections.Add(new SectionData(Name));
			}
			_data[Name][key] = value.ToString();
			if (DoWrite)
			{
				_parent.Save();
			}
		}

		protected void Remove(string key)
		{
			if (_data[Name] == null)
			{
				return;
			}
			if (!_data[Name].ContainsKey(key))
			{
				return;
			}
			_data[Name].RemoveKey(key);
			if (DoWrite)
			{
				_parent.Save();
			}
		}

		private bool HasGameSpecificValue(string key)
		{
			return Name != _parent.GameName
				   && _parent.GameConfig != null
				   && _data[_parent.GameName].ContainsKey(GameOverridePrefix + key);
		}

		protected bool HasValue(string key)
		{
			if (HasGameSpecificValue(key))
			{
				return true;
			}
			return _data[Name] != null && _data[Name].ContainsKey(key);
		}

		private bool CreateGameConfig()
		{
			if (string.IsNullOrEmpty(_parent.GameName))
			{
				return false;
			}

			if (_parent.GameConfig != null)
			{
				return true;
			}

			_data.Sections.Add(new SectionData(_parent.GameName));
			_parent.GameName = _parent.GameName; // trigger GameConfig instantiation
			return true;
		}
	}

	public class IniNotFoundException : Exception
	{
		public IniNotFoundException(string path) : base("Could not find DmdDevice.ini at " + path)
		{
		}
	}
}
