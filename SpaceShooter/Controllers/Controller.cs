using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast2D;
using OpenTK;

namespace SpaceShooter
{
    abstract class Controller
    {
        protected int ctrlIndex;
        public Controller(int ctrlIndex)
        {
            this.ctrlIndex = ctrlIndex;
        }
        public abstract float GetHorizontal();
        public abstract float GetVertical();
        public abstract bool IsFirePressed();
        public abstract Vector2 GetForward();
    }
}
