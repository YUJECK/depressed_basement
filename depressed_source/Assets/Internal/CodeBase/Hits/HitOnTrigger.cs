using CodeBase.Items;
using UnityEngine;

namespace CodeBase.Hits
{
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(WeaponObject))]
    public sealed class HitOnTrigger : MonoBehaviour
    {
        public bool Enabled;
        public bool DisableOnHit;
        
        private WeaponObject _weaponObject;
        
        private void Start()
        {
            _weaponObject = GetComponent<WeaponObject>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (Enabled && other.TryGetComponent(out Health health))
            {
                HitHandler.Hit(_weaponObject.GetHitData(), health);

                if (DisableOnHit)
                {
                    Enabled = false;
                }
            }
                
        }
    }
}