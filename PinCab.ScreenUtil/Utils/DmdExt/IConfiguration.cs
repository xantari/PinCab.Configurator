using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinCab.ScreenUtil.Utils.DmdExt
{
	public interface IVirtualDmdConfig
	{
		bool Enabled { get; }
		bool StayOnTop { get; }
		bool IgnoreAr { get; }
		bool UseRegistryPosition { get; }
		double Left { get; }
		double Top { get; }
		double Width { get; }
		double Height { get; }
		double DotSize { get; }
		bool HasGameOverride(string key);

		void SetPosition(VirtualDisplayPosition position, bool onlyForGame);

		void SetIgnoreAspectRatio(bool ignoreAspectRatio);
	}
}
