using System;
using CodeBase.GameState;
using destructive_code.Scenes;
using TMPro;
using UnityEngine;

namespace CodeBase.FightMiner
{
    [RequireComponent(typeof(TMP_Text))]
    public class MinerGUI : MonoBehaviour
    {
        private TMP_Text _moneyScore;

        private void Start()
        {
            _moneyScore = GetComponent<TMP_Text>();
            SceneSwitcher.CurrentScene.TryGetState(out GameplayState gameplayState);
            gameplayState.
        }
        
        
    }
}