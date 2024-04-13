using System;
using System.Collections.Generic;
using CodeBase;
using CodeBase.Inputs;
using CodeBase.Items;
using destructive_code.Scenes;
using destructive_code.Sounds;
using UnityEngine;

namespace TraiderElfik
{
    public sealed class StoreLogic : DepressedBehaviour
    {
        [SerializeField] private ItemButton prefab;
        [SerializeField] private Transform buttonsRoot;
        
        [SerializeField] private List<Weapon> items;

        private void Start()
        {
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

        public void DisableStoreUI()
        {
            gameObject.SetActive(false);
            InputsHandler.EnterPlayerMode();
            AudioPlayer.Play("StoreClick");
        }
    }
}