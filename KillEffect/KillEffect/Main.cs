using Rocket.Core.Plugins;
using Rocket.Unturned.Player;
using SDG.NetTransport;
using SDG.Unturned;
using Steamworks;

namespace KillEffect
{
	
	public class Main : RocketPlugin<Config>
	{
	
	
		internal static Config Config
		{
			get
			{
				return Main.Instance.Configuration.Instance;
			}
		}

	
		protected override void Load()
		{
			Main.Instance = this;
			PlayerLife.onPlayerDied += this.OnPlayerDied;
		}


		private void OnPlayerDied(PlayerLife sender, EDeathCause cause, ELimb limb, CSteamID murderer)
		{
			UnturnedPlayer player = UnturnedPlayer.FromPlayer(sender.player);
			if (murderer != CSteamID.Nil && murderer != Provider.server && murderer != player.CSteamID)
			{
                ITransportConnection transportConnection = Provider.findTransportConnection(murderer);
                EffectManager.sendUIEffect(Main.Config.KillerEffectId, 8548, transportConnection, true);
			}
		}
		public static Main Instance;
	}
}
