using System;
using System.Collections.Generic;
using CodeBase.FightMiner;
using Cysharp.Threading.Tasks;
using Shop;
using destructive_code.Scenes;
using Internal.Enemies;
using UnityEngine;

namespace CodeBase.GameStates
{
    public class FightState : GameState
    {
        public Miner Miner { get; private set; }
        public Enemy[] CurrentEnemies => currentEnemies.ToArray();
        
        private readonly float duration;
        private readonly List<Enemy> currentEnemies = new();
        
        public FightState(float duration)
        {
            this.duration = duration;
        }

        public override void Enter()
        {
            var fightLayer = GameObject.FindObjectOfType<FightGUILayer>();
            SceneSwitcher.CurrentScene.SceneGUI.OpenLayer(fightLayer);
            
            SceneSwitcher.BasementScene.Fabric.OnNewGameObject += CheckIfEnemySpawned;
            SceneSwitcher.BasementScene.Fabric.OnGameObjectDestroyed += CheckIfEnemyDied;
            
            StartMinerAndTimer();
        }

        public override void Exit()
        {
            ClearEnemies();
            
            SceneSwitcher.BasementScene.Fabric.OnNewGameObject -= CheckIfEnemySpawned;
            SceneSwitcher.BasementScene.Fabric.OnGameObjectDestroyed -= CheckIfEnemyDied;
            
            Miner.Stop();
        }

        private void CheckIfEnemyDied(GameObject gameObject)
        {
            if(gameObject.TryGetComponent(out Enemy enemy))
                currentEnemies.Remove(enemy);
        }

        private void CheckIfEnemySpawned(GameObject gameObject)
        {
            if(gameObject.TryGetComponent(out Enemy enemy))
                currentEnemies.Add(enemy);
        }

        private async void StartMinerAndTimer()
        {
            Miner = new Miner();
            Miner.Start();

            await UniTask.Delay(TimeSpan.FromSeconds(duration));
            
            SceneSwitcher.BasementScene.RoomSwitcher.SwitchTo<ShopRoom>();
        }

        private void ClearEnemies()
        {
            while(currentEnemies.Count > 0)
            {
                SceneSwitcher.CurrentScene.Fabric.Destroy(currentEnemies[0].gameObject);
            }

            currentEnemies.Clear();
        }
    }
}