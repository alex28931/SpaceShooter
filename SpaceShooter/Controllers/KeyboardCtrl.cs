using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast2D;
using OpenTK;

namespace SpaceShooter
{
    class KeyboardCtrl : Controller
    {
        public KeyboardCtrl(int ctrlIndex) : base(ctrlIndex)
        {

        }

        public override float GetHorizontal()
        {
            float direction = 0.0f;
            if (Game.Window.GetKey(KeyCode.A) || Game.Window.GetKey(KeyCode.Left))
            {
                direction = -1.0f;
            }
            else if(Game.Window.GetKey(KeyCode.D) || Game.Window.GetKey(KeyCode.Right))
            {
                direction = 1.0f;
            }
            return direction;
        }

        public override float GetVertical()
        {
            float direction = 0.0f;
            if (Game.Window.GetKey(KeyCode.W) || Game.Window.GetKey(KeyCode.Up))
            {
                direction = -1.0f;
            }
            else if (Game.Window.GetKey(KeyCode.S) || Game.Window.GetKey(KeyCode.Down))
            {
                direction = 1.0f;
            }
            return direction;
        }

        public override bool IsFirePressed()
        {
            return (Game.Window.GetKey(KeyCode.Space));
        }
        public override Vector2 GetForward()
        {
            return new Vector2(1, 0);
        }
    }
}
