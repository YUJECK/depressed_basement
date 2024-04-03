using UnityEngine;

namespace CodeBase.Items
{
    public abstract class Item
    {
        [field: Header("Information")]
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public string Description { get; private set; }

        public abstract void Equip();
        public abstract void Unequip();
    }
}