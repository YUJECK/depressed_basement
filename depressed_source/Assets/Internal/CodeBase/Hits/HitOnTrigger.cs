using System;
using System.Collections.Generic;
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

        private WeaponObject weaponObject;
        private List<Type> excludeList = new List<Type>();
        
        private void Start()
        {
            weaponObject = GetComponent<WeaponObject>();
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (Enabled && other.TryGetComponent(out Health health) && !excludeList.Contains(health.GetType()))
            {
                HitHandler.Hit(weaponObject.GetHitData(), health);

                if (DisableOnHit)
                {
                    Enabled = false;
                }
            }
        }
        
        public void AddExclude<THealth>()
            where THealth : Health
        {
            if(!excludeList.Contains(typeof(THealth)))
                excludeList.Add(typeof(THealth));
        }
    }
}