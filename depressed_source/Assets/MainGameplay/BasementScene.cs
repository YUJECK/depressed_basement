using CodeBase.GameStates;
using CodeBase.Rooms;
using Shop;
using destructive_code.Scenes;
using PlayerStuff;
using UnityEngine;

namespace DefaultNamespace.MainGameplay
{
    public class BasementScene : Scene
    {
        public PlayerWallet Wallet { get; private set; }
        public Player Player { get; private set; }
        public CheckMachine CheckMachine { get; private set; }
        public RoomSwitcher RoomSwitcher { get; private set; }
        
        public override string GetSceneName()
        {
            return "BasementScene";
        }

        public override Camera GetCamera()
        {
            return Camera.main;
        }

        public override void BeforeSceneLoaded()
        {
            Wallet = new PlayerWallet(20);
            UpdateGameStateTo(new ShopState());
        }

        protected override void OnSceneLoaded()
        {
            RoomSwitcher = new RoomSwitcher(GameObject.FindObjectOfType<RoomsContainer>().transform, this);
            
            Player = GameObject.FindObjectOfType<Player>();
            CheckMachine = GameObject.FindObjectOfType<CheckMachine>();
            
            State.OnSceneLoaded();
            SceneSwitcher.BasementScene.RoomSwitcher.SwitchTo<ShopRoom>();
        }
    }
} 