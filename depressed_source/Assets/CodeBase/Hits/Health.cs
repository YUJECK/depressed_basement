using UnityEngine;

namespace CodeBase.Hits
{
    public abstract class Health : MonoBehaviour
    {
        public int Hits { get; protected set; }
        
        public abstract void TakeHitFromBlade(BladeHitData hitData);
        public abstract void TakeHitFromBullet(BulletHitData hitData);
    }
}