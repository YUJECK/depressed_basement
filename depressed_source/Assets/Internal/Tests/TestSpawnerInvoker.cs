using CodeBase.GameStates;
using Cysharp.Threading.Tasks;
using destructive_code.Scenes;
using Enemies;
using FightRoomCode.Enemies;
using UnityEngine;

[RequireComponent(typeof(EnemySpawner))]
public class TestSpawnerInvoker : MonoBehaviour 
{
    private EnemySpawner spawner;
    
    private void Start()
    {
        spawner = GetComponent<EnemySpawner>();
        
        SceneSwitcher.BasementScene.OnEnteredState += OnState;
    }

    private void OnState(GameState state)
    {
        if (state is FightState)
        {
            Spawn();
        }
    }

    private async void Spawn()
    {
        while (gameObject.activeSelf && SceneSwitcher.BasementScene.State is FightState)
        {
            spawner.InvokeRandomSpawnerFrom<KnifyDummySpawner>();
            await UniTask.WaitForSeconds(4.5f);
            spawner.InvokeRandomSpawnerFrom<BarbedDummiesSpawner>();
            await UniTask.WaitForSeconds(4.5f);
        }
    }
}
