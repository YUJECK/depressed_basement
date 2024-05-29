using FightRoomCode;
using FightRoomCode.Enemies;
using Internal.Enemies;

namespace Enemies
{
    public sealed class BarbedDummiesSpawner : AbstractSpawner
    {
        public override void Spawn(FightRoom fightRoom, EnemyPrefabProvider enemyPrefabProvider)
        {
            var prefab = enemyPrefabProvider.Get<BarbedWireDwarfAI>();
            var position = fightRoom.Area.GetRandomEmptyPoint(prefab.Size);

            fightRoom.Spawn<Enemy>(prefab, position);
        }
    }
}