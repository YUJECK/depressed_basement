using CodeBase.Hits;
using UnityEngine;

namespace PlayerStuff
{
    public class PlayerHealth : Health
    {
        public override void TakeHitFromBlade(BladeHitData hitData)
        {
            Debug.Log("Blade");
        }

        public override void TakeHitFromBullet(BulletHitData hitData)
        {
            Debug.Log("Bullet");
        }
    }
}