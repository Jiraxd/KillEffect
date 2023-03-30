using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Rocket.API;

namespace KillEffect
{
	
	public class Config : IRocketPluginConfiguration, IDefaultable
	{
		
		public void LoadDefaults()
		{
			this.KillerEffectId = 123;
		}
		public ushort KillerEffectId;

	}
}
