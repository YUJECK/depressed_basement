using Items.Knife;
using PlayerStuff;
using UnityEngine;

namespace CodeBase.Items
{
    public abstract class Weapon : ScriptableObject
    {
        [field: Header("Information")]
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public string Description { get; private set; }
        [field: SerializeField] public int Cost { get; private set; }
        
        [field: Header("Visual")]
        [field: SerializeField] public Sprite Icon { get; private set; }

        public abstract void Equip(Player player);
        public abstract void Unequip(Player player);
        
        public abstract void StopCurrentAction();
    }
}