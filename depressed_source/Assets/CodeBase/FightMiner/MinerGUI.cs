using CodeBase.GameStates;
using CodeBase.GUIWindows;
using destructive_code.Scenes;
using TMPro;
using UnityEngine;
using GUILayer = CodeBase.GUIWindows.GUILayer;

namespace CodeBase.FightMiner
{
    [RequireComponent(typeof(TMP_Text))]
    public sealed class MinerGUI : GUIWindow
    {
        private TMP_Text _moneyScore;

        protected override void OnThisOpened(GUILayer layer)
        {
            base.OnThisOpened(layer);

            if(_moneyScore == null)
            {
                _moneyScore = GetComponent<TMP_Text>();
            }

            _moneyScore.text = "0";
            SceneSwitcher.CurrentScene.OnEnteredState += EnteredState;
        }

        protected override void OnThisClosed(GUILayer layer)
        {
            base.OnThisClosed(layer);
            
            if(SceneSwitcher.CurrentScene.TryGetState(out FightState state)) 
                state.Miner.OnChanged -= OnChanged;
        }

        private void EnteredState(GameState state)
        {
            if (state is FightState fightState)
                fightState.Miner.OnChanged += OnChanged;
        }

        private void OnChanged(int score)
            => _moneyScore.text = score.ToString();
    }
}