using FightRoomCode;
using FightRoomCode.Enemies;

namespace Enemies
{
    public sealed class BarbedDummiesSpawner : AbstractSpawner
    {
        public override void Spawn(FightRoom fightRoom, EnemyPrefabProvider enemyPrefabProvider)
        {
            var prefab = enemyPrefabProvider.Get<BarbedWireDwarfAI>();
            var position = fightRoom.Area.GetRandomEmptyPoint(prefab.Size);

            fightRoom.Spawn(prefab, position);
        }
    }
}