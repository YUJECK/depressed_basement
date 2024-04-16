using CodeBase.FightMiner;
using destructive_code.Scenes;
using UnityEngine;

namespace CodeBase.GameStates
{
    public class FightState : GameState
    {
        public Miner Miner { get; private set; }

        public override void Enter()
        {
            var fightLayer = GameObject.FindObjectOfType<FightGUILayer>();
            SceneSwitcher.CurrentScene.SceneGUI.OpenLayer(fightLayer);
            
            Miner = new Miner();
            Miner.Start();
        }

        public override void Exit()
        {
            Miner.Stop();
        }
    }
}