using CodeBase.Items;
using UnityEngine;

namespace CodeBase.Hits
{
    public class HitOnCollide : MonoBehaviour
    {
        public bool Enabled;
        public bool DisableOnHit;

        private WeaponObject weaponObject;
        
        private void Start()
        {
            weaponObject = GetComponent<WeaponObject>();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            Debug.Log(other.gameObject.name);
            
            Debug.Log(other.gameObject.layer);
            Debug.Log(gameObject.layer);
            
            if (Enabled && other.gameObject.TryGetComponent(out Health health))
            {
                Debug.Log("KFDlkjsf");
                
                HitHandler.Hit(weaponObject.GetHitData(), health);

                if (DisableOnHit)
                {
                    Enabled = false;
                }
            }
        }
    }
}