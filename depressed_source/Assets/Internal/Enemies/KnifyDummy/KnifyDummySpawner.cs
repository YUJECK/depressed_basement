using FightRoomCode;
using FightRoomCode.Enemies;
using Internal.Enemies;

namespace Enemies
{
    public sealed class KnifyDummySpawner : AbstractSpawner
    {
        public override void Spawn(FightRoom fightRoom, EnemyPrefabProvider enemyPrefabProvider)
        {
            var prefab = enemyPrefabProvider.Get<KnifyDummyAI>();
            var position = fightRoom.Area.GetRandomEmptyPoint(prefab.Size);

            fightRoom.Spawn<Enemy>(prefab, position);
        }
    }
}