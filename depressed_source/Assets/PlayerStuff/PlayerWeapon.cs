using CodeBase;
using CodeBase.Items;
using UnityEngine;

namespace PlayerStuff
{
    [RequireComponent(typeof(Player))]
    public class PlayerWeapon : DepressedBehaviour
    {
        private Player _player;
        private Weapon current;

        private void Awake()
        {
            _player = GetComponent<Player>();
        }

        public void Equip(Weapon weapon)
        {
            if(current != null)
            {
                current.Unequip(_player);
            }

            weapon.Equip(_player);
            current = weapon;
        }
    }
}