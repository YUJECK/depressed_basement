using destructive_code.Scenes;
using FightRoomCode;
using FightRoomCode.Enemies;
using UnityEngine;

namespace Enemies
{
    public sealed class BarbedDummiesSpawner : AbstractSpawner
    {
        public override void Spawn(FightRoom fightRoom, EnemyPrefabProvider enemyPrefabProvider)
        {
            var prefab = enemyPrefabProvider.Get<BarbedWireDwarfAI>();
            var position = fightRoom.Area.GetRandomEmptyPoint(prefab.Size);
            
            SceneSwitcher.CurrentScene.Fabric.Instantiate(prefab, position);
            
        }
    }
}