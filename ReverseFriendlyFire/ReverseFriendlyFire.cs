using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.API.Interfaces;
using Exiled.API.Features;
using Exiled.API.Enums;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.EventArgs.Server;
using MEC;

using PlayerHandeler = Exiled.Events.Handlers.Player;
using ServerHandeler = Exiled.Events.Handlers.Server;

using PlayerRoles;
namespace ReverseFriendlyFire
{
    public class ReverseFriendlyFire : Plugin<Config>
    {
        public override string Name => "Reverse Friendly Fire";
        public override string Author => "Morgana";
        public override Version RequiredExiledVersion { get; } = new Version(6, 0, 0);
        public override Version Version => new Version(1, 0, 0);
        public override PluginPriority Priority { get; } = PluginPriority.Medium;

        public static ReverseFriendlyFire Instance { get; } = new ReverseFriendlyFire();
        private ReverseFriendlyFire() { }

        public override void OnEnabled()
        {
            Log.Info("Reverse Friendly fire has been enabled");
            base.OnEnabled();
            RegisterEvents();
        }

        public override void OnDisabled()
        {
            Log.Info("Reverse Friendly fire has been disabled");
            base.OnDisabled();
            UnregisterEvents();
        }

        public void OnShot(ShotEventArgs ev)
        {
            if (!ReverseFriendlyFire.Instance.Config.IsEnabled)
            {
                return;
            }
            if (!(ev.Player.Role.Side == Side.Mtf && ReverseFriendlyFire.Instance.Config.RFF_MTF) || (ev.Player.Role.Side == Side.ChaosInsurgency && ReverseFriendlyFire.Instance.Config.RFF_CHAOS))
            {
                return;
            }

            if (ev.Target.Role.Side != ev.Player.Role.Side)
            {
                return;
            }

            ev.CanHurt = ReverseFriendlyFire.Instance.Config.RFF_VictimDamage;
            ev.Player.Hurt((ev.Damage * ReverseFriendlyFire.Instance.Config.RFF_Multiplier));
            ev.Damage = (ev.Damage * ReverseFriendlyFire.Instance.Config.RFF_VictimMultiplier);
        }
        public override void OnReloaded() { }
        public void RegisterEvents()
        {
            PlayerHandeler.Shot += OnShot;
        }

        private void UnregisterEvents()
        {
            PlayerHandeler.Shot -= OnShot;
        }
    }
}
