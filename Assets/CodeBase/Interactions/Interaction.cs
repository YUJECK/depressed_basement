using UnityEngine;

namespace CodeBase.Interactions
{
    public abstract class Interaction : DepressedBehaviour
    {
        public virtual void Pointed() {}
        public virtual void PointedReleased() {}
        
        public abstract void Interact();
    }
}