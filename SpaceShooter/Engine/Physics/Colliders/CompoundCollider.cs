using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace SpaceShooter
{
    class CompoundCollider : Collider
    {
        protected List<Collider> innercolliders;
        protected Collider boundingCollider;
        public CompoundCollider(RigidBody owner, Collider boundingCollider) : base(owner)
        {
            this.boundingCollider = boundingCollider;
            OffSet = Vector2.Zero;
            innercolliders = new List<Collider>();

        }
        public virtual void AddInnerCollider(Collider c)
        {
            innercolliders.Add(c);
        }

        public override bool Collides(Collider other)
        {
            return other.Collides(this);
        }

        public override bool Collides(CircleCollider other)
        {
            if (other.Collides(boundingCollider))
            {
                for (int i = 0; i < innercolliders.Count; i++)
                {
                    if (other.Collides(innercolliders[i]))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public override bool Collides(BoxCollider other)
        {
            if (other.Collides(boundingCollider))
            {
                for (int i = 0; i < innercolliders.Count; i++)
                {
                    if (other.Collides(innercolliders[i]))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public override bool Collides(CompoundCollider other)
        {
            if (boundingCollider.Collides(other.boundingCollider))
            {
                for (int i = 0; i < innercolliders.Count; i++)
                {
                    for (int j = 0; j < other.innercolliders.Count; j++)
                    {
                        if (innercolliders[i].Collides(other.innercolliders[j]))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public override bool Contain(Vector2 point)
        {
            throw new NotImplementedException();
        }
    }
}
