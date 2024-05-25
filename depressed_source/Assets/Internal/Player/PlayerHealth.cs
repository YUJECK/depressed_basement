using System.Collections;
using CodeBase.Hits;
using UnityEngine;

namespace PlayerStuff
{
    public class PlayerHealth : Health
    {
        [SerializeField] private float invincibilityCadres;
        
        public bool CanBeHit { get; private set; }
        
        public override void TakeHitFromBlade(BladeHitData hitData)
        {
            GeneralHitProcessor(hitData);
        }
        
        public override void TakeHitFromBullet(BulletHitData hitData)
        {
            GeneralHitProcessor(hitData);
        }

        public override void TakeHitFromTouch(TouchHitData hitData)
        {
            GeneralHitProcessor(hitData);
        }

        public override void GeneralHitProcessor(HitData data)
        {
            base.GeneralHitProcessor(data);
            
            if (CanBeHit)
            {
                StartCoroutine(Invincibility());
            }
        }

        private IEnumerator Invincibility()
        {
            CanBeHit = false;

            yield return new WaitForSeconds(invincibilityCadres);

            CanBeHit = true;
        }
    }
}