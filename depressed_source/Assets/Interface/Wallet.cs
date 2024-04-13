using System;
using CodeBase.GameState;
using destructive_code.Scenes;
using TMPro;
using UnityEngine;

namespace DefaultNamespace.Interface
{
    [RequireComponent(typeof(TMP_Text))]
    public class Wallet : MonoBehaviour
    {
        private TMP_Text _text;
        private GameplayState _state;

        private void Awake()
        {
            _text = GetComponent<TMP_Text>();
            _state = SceneSwitcher.CurrentScene.State as GameplayState;
        }

        public void Update()
        {
            _text.text = _state.Money.ToString();
        }
    }
}