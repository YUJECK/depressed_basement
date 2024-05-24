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
            Debug.Log("Blade");
        }
        
        public override void TakeHitFromBullet(BulletHitData hitData)
        {
            Debug.Log("Bullet");
        }

        public override void TakeHitFromTouch(TouchHitData hitData)
        {
            Debug.Log("To" +
                      "" +
                      "uch");
            GeneralHitProcessor();
        }

        public override void GeneralHitProcessor()
        {
            base.GeneralHitProcessor();
            
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