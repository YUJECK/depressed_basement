using CodeBase.Items;
using Items.Knife;
using PlayerStuff;
using UnityEngine;

namespace DefaultNamespace.Items.Knife
{
    [CreateAssetMenu(menuName = "Items/Knife")]
    public class KnifeWeapon : Weapon
    {
        private KnifeObject _knife;

        public override void Equip(Player player)
        {
            _knife = player.GetComponentInChildren<KnifeObject>(true);

            _knife.gameObject.SetActive(true);
        }

        public override void Unequip(Player player)
        {
            _knife.gameObject.SetActive(false);
        }

        public override void StopCurrentAction()
        {
            _knife.StopAttack();
        }
    }
}