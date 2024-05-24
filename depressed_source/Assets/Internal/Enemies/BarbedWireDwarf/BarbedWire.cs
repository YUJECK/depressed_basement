using CodeBase.Hits;
using CodeBase.Items;

namespace Enemies
{
    public class BarbedWire : WeaponObject
    {
        public override HitData GetHitData()
        {
            return new TouchHitData();
        }
    }
}