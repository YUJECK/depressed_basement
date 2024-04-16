using CodeBase.GameStates;
using destructive_code.Scenes;
using PlayerStuff;
using UnityEngine;

namespace DefaultNamespace.MainGameplay
{
    public class BasementScene : Scene
    {
        public PlayerWallet Wallet { get; private set; }
        public Player Player { get; private set; }
        public CameraBrain CameraBrain { get; private set; }
        
        public override string GetSceneName()
        {
            return "SampleScene";
        }

        public override Camera GetCamera()
        {
            return Camera.main;
        }

        public override void BeforeSceneLoaded()
        {
            Wallet = new PlayerWallet(100);
            UpdateGameStateTo(new ShopState());
        }

        protected override void OnSceneLoaded()
        {
            Player = GameObject.FindObjectOfType<Player>();
            
            State.OnSceneLoaded();
        }
    }
} 