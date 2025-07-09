using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter
{
    abstract class Scene
    {
        public Scene NextScene;
        public bool IsPlaying { get; protected set; }
        public Scene()
        {

        }
        public virtual void Start()
        {
            IsPlaying = true;
        }
        public virtual Scene OnExit()
        {
            IsPlaying = false;
            return NextScene;
        }
        public abstract void LoadClips();
        public abstract void LoadAssets();
        public abstract void input();
        public abstract void Update();
        public abstract void Draw();
    }
}
