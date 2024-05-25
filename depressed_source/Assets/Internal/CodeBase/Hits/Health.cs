using System;
using UnityEngine;

namespace CodeBase.Hits
{
    public abstract class Health : MonoBehaviour
    {
        public int Hits { get; protected set; }
        
        public event Action OnHit;

        public virtual void GeneralHitProcessor(HitData data)
        {
            OnHit?.Invoke();
        }
        
        public abstract void TakeHitFromBlade(BladeHitData hitData);
        public abstract void TakeHitFromBullet(BulletHitData hitData);
        public abstract void TakeHitFromTouch(TouchHitData hitData);
    }
}