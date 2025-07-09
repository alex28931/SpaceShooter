using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter
{
    class TripleShoot : TimedPowerUp
    {
        public TripleShoot() : base("tripleShoot")
        {
        }
        public override void OnAttach(Player p)
        {
            base.OnAttach(p);
            p.ChangeWeaponType(WeaponType.Tripleshoot);
        }
        public override void OnDetach()
        {
            attachedPlayer.ChangeWeaponType(WeaponType.Default);
            base.OnDetach();
        }
    }
}
