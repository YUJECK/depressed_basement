using Internal.Enemies;
using UnityEngine;

namespace FightRoomCode.Enemies
{
    [CreateAssetMenu(menuName = "PrefabProvider")]
    public sealed class EnemyPrefabProvider : ScriptableObject
    {
        [field: SerializeField] public Enemy[] Enemies { get; private set; }

        public Enemy Get<TEnemy>()
            where TEnemy : Enemy
        {
            for (int i = 0; i < Enemies.Length; i++)
            {
                if (Enemies[i] is TEnemy)
                {
                    return Enemies[i];
                }
            }

            return null;
        }

    }
}