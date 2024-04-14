using System.Collections.Generic;
using CodeBase;
using CodeBase.Inputs;
using CodeBase.Items;
using destructive_code.Scenes;
using destructive_code.Sounds;
using UnityEngine;

namespace TraiderElfik
{
    [RequireComponent(typeof(StoreGUILayer))]
    public sealed class StoreLogic : DepressedBehaviour
    {
        [SerializeField] private ItemButton prefab;
        [SerializeField] private Transform buttonsRoot;
        
        [SerializeField] private List<Weapon> items;

        private StoreGUILayer _layer;
        
        private void Start()
        {
            _layer = GetComponent<StoreGUILayer>();
            
            foreach (var item in items)
            {
                CreateItem(item);
            }
        }

        private void CreateItem(Weapon weapon)
        {
            var button = SceneSwitcher.CurrentScene.Fabric.Instantiate(prefab, Vector3.zero, Quaternion.identity, buttonsRoot);
            weapon = ScriptableObject.Instantiate(weapon);
            
            button.Connect(weapon);
        }
        
        public void EnableStoreUI()
        {
            InputsHandler.EnterPlayerMode();
            SceneSwitcher.CurrentScene.SceneGUI.OpenLayer(_layer);
            
            AudioPlayer.Play("StoreClick");
        }
        
        public void DisableStoreUI()
        {
            InputsHandler.EnterPlayerMode();
            SceneSwitcher.CurrentScene.SceneGUI.OpenLayer(SceneSwitcher.CurrentScene.SceneGUI.PreviousLayer);
            
            AudioPlayer.Play("StoreClick");
        }
    }
}