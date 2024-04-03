using CodeBase;
using CodeBase.Items;
using UnityEngine;

namespace Player
{
    public class PlayerItemEquiper : DepressedBehaviour
    {
        public void Equip(Item item)
        {
            item.Equip();
        }

        public void Drop(Item item)
        {
            item.Unequip();
        }
    }
}