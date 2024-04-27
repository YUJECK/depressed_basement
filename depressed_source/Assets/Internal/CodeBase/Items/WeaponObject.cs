using CodeBase.Hits;
using UnityEngine;

namespace CodeBase.Items
{
    public abstract class WeaponObject : MonoBehaviour
    {
        public abstract HitData GetHitData();
    }
}