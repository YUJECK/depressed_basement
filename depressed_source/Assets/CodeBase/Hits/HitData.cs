using UnityEngine;

namespace CodeBase.Hits
{
    public abstract class HitData
    {
        [field: SerializeField] public int Damage { get; protected set; } = 1;
    }
}