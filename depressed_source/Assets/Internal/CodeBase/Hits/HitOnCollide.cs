using System;
using CodeBase.Items;
using UnityEngine;

namespace CodeBase.Hits
{
    public class HitOnCollide : MonoBehaviour
    {
        public bool Enabled;
        public bool DisableOnHit;

        public event Action OnCollide;
        
        private WeaponObject weaponObject;
        
        private void Start()
        {
            weaponObject = GetComponent<WeaponObject>();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (Enabled && other.gameObject.TryGetComponent(out Health health))
            {
                HitHandler.Hit(weaponObject.GetHitData(), health);

                if (DisableOnHit)
                {
                    Enabled = false;
                }
                
                OnCollide?.Invoke();
            }
        }
    }
}