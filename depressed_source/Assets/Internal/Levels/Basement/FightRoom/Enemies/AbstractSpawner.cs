namespace FightRoomCode.Enemies
{
    public abstract class AbstractSpawner
    {
        public abstract void Spawn(FightRoom fightRoom, EnemyPrefabProvider enemyPrefabProvider);
    }
}