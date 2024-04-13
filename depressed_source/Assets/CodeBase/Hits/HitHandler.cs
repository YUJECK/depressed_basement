using System;

namespace CodeBase.Hits
{
    public static class HitHandler
    {
        public static event Action<Health, HitData> OnHit;
        
        public static void Hit(HitData from, Health who)
        {
            if(from == null || who == null)
                return;
            
            switch (from)
            {
                case BladeHitData blade:
                    who.TakeHitFromBlade(blade);
                    break;
                case BulletHitData bullet:
                    who.TakeHitFromBullet(bullet);
                    break;
            }
            
            OnHit?.Invoke(who, from);
        }
    }
}