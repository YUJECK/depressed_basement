using CodeBase.GUIWindows;
using destructive_code.Scenes;
using PlayerStuff;
using TMPro;
using UnityEngine;

namespace DefaultNamespace.Interface
{
    [RequireComponent(typeof(TMP_Text))]
    public class WalletGUI : GUIWindow
    {
        private TMP_Text _text;
        private PlayerWallet _wallet;

        private void Awake()
        {
            _text = GetComponent<TMP_Text>();
            _wallet = SceneSwitcher.BasementScene.Wallet;
        }

        public void Update()
        {
            _text.text = _wallet.Balance.ToString();
        }
    }
}