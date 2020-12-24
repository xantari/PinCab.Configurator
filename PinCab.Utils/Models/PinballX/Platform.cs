using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinCab.Utils.Models.PinballX
{
	/// <summary>
	/// Different types of systems.
	/// </summary>
	public enum Platform
	{
		Undefined,
		/// <summary>
		/// Visual Pinball
		/// </summary>
		VP,

		/// <summary>
		/// Future Pinball
		/// </summary>
		FP,
		PinballFX2,
		PinballFX3,
		PinballArcade,

		/// <summary>
		/// Anything else
		/// </summary>
		Custom
	}
}
