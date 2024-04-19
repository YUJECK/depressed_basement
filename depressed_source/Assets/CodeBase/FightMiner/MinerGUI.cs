using System.Collections;
using CodeBase.GameStates;
using CodeBase.GUIWindows;
using destructive_code.Scenes;
using TMPro;
using UnityEngine;
using GUILayer = CodeBase.GUIWindows.GUILayer;

namespace CodeBase.FightMiner
{
    public sealed class MinerGUI : GUIWindow
    {
        [SerializeField] private TMP_Text timer;
        [SerializeField] private TMP_Text moneyScore;
        
        private bool _timerEnabled;

        protected override void OnThisOpened(GUILayer layer)
        {
            base.OnThisOpened(layer);
            
            moneyScore.text = "0";
            
            SceneSwitcher.CurrentScene.OnEnteredState += EnteredState;
        }

        protected override void OnThisClosed(GUILayer layer)
        {
            base.OnThisClosed(layer);
            
            if(SceneSwitcher.CurrentScene.TryGetState(out FightState state))
            {
                state.Miner.OnChanged -= OnChanged;
                _timerEnabled = false;
            }
        }

        private void EnteredState(GameState state)
        {
            if (state is FightState fightState)
            {
                fightState.Miner.OnChanged += OnChanged;
                
                StartCoroutine(Timer());
            }
        }

        private IEnumerator Timer()
        {
            _timerEnabled = true;
            
            timer.text = "0";
            int timerTime = 0;
            
            while (_timerEnabled)
            {
                yield return new WaitForSeconds(1);
                
                timerTime += 1;
                timer.text = timerTime.ToString();
            }
        }

        private void OnChanged(int score)
            => moneyScore.text = score.ToString();
    }
}