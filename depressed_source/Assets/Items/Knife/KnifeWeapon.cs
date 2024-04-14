using CodeBase.Items;
using Items.Knife;
using PlayerStuff;
using UnityEngine;

namespace DefaultNamespace.Items.Knife
{
    [CreateAssetMenu(menuName = "Items/Knife")]
    public class KnifeWeapon : Weapon
    {
        public override void Equip(Player player)
        {
            player.GetComponentInChildren<KnifeObject>(true).gameObject.SetActive(true);

        }

        public override void Unequip(Player player)
        {
            player.GetComponentInChildren<KnifeObject>().gameObject.SetActive(false);
        }

    }
}