using System;
using CodeBase.FightMiner;
using Cysharp.Threading.Tasks;
using DefaultNamespace.Shop;
using destructive_code.Scenes;
using UnityEngine;

namespace CodeBase.GameStates
{
    public class FightState : GameState
    {
        public Miner Miner { get; private set; }
        private float _duration;

        public FightState(float duration)
        {
            _duration = duration;
        }

        public override void Enter()
        {
            var fightLayer = GameObject.FindObjectOfType<FightGUILayer>();
            SceneSwitcher.CurrentScene.SceneGUI.OpenLayer(fightLayer);

            StartMinerAndTimer();
        }

        private async void StartMinerAndTimer()
        {
            Miner = new Miner();
            Miner.Start();

            await UniTask.Delay(TimeSpan.FromSeconds(_duration));
            
            Miner.Stop();
            
            SceneSwitcher.BasementScene.RoomSwitcher.SwitchTo<ShopRoom>();
        }

        public override void Exit()
        {
            Miner.Stop();
        }
    }
}