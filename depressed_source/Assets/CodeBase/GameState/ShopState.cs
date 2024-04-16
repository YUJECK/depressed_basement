using CodeBase.FightMiner;
using destructive_code.Scenes;
using PlayerStuff;
using UnityEngine;

namespace CodeBase.GameStates
{
    public class ShopState : GameState
    {
        public override void OnSceneLoaded()
        {
            OpenShopHUD();
        }

        public override void Enter()
        {
            if (SceneSwitcher.IsSceneLoaded)
            {
                OpenShopHUD();    
            }
        }

        private static void OpenShopHUD()
        {
            var shopLayer = GameObject.FindObjectOfType<ShopHUD>();
            SceneSwitcher.CurrentScene.SceneGUI.OpenLayer(shopLayer);
        }
    }
}