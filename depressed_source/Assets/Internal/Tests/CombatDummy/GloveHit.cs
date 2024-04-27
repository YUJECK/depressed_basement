using CodeBase.Hits;
using CodeBase.Items;

namespace DefaultNamespace.Tests
{
    public class GloveHit : WeaponObject
    {
        public override HitData GetHitData()
        {
            return new BulletHitData();
        }
    }
}