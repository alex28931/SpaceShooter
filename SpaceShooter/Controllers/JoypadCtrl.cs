using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter
{
    class JoypadCtrl : Controller
    {
        public JoypadCtrl(int ctrlIndex) : base(ctrlIndex)
        {
        }

        public override float GetHorizontal()
        {
            float direction = 0.0f;
            if (Game.Window.JoystickLeft(ctrlIndex))
            {
                direction = -1.0f;
            }
            else if (Game.Window.JoystickRight(ctrlIndex))
            {
                direction = 1.0f;
            }
            else
            {
                direction = Game.Window.JoystickAxisLeft(ctrlIndex).X;
            }
            return direction;
        }

        public override float GetVertical()
        {
            float direction = 0.0f;
            if (Game.Window.JoystickUp(ctrlIndex))
            {
                direction = -1.0f;
            }
            else if (Game.Window.JoystickDown(ctrlIndex))
            {
                direction = 1.0f;
            }
            else
            {
                direction = Game.Window.JoystickAxisLeft(ctrlIndex).Y;
            }
            return direction;
        }

        public override bool IsFirePressed()
        {
            if (Game.Window.JoystickTriggerRight(ctrlIndex) != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override Vector2 GetForward()
        {
            return Game.Window.JoystickAxisRight(ctrlIndex);
        }
    }
}
