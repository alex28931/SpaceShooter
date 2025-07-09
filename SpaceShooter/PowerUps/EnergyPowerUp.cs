using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter
{
    class EnergyPowerUp : PowerUp
    {
        public EnergyPowerUp() : base("energy")
        {
        }
        public override void OnAttach(Player p)
        {
            base.OnAttach(p);
            attachedPlayer.ResetEnergy();
            OnDetach();
        }
    }
}
