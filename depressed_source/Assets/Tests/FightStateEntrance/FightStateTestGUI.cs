using CodeBase.GameState;
using destructive_code.Scenes;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.Tests.FightStateEntrance
{
    [RequireComponent(typeof(Button))]
    public class FightStateTestGUI : MonoBehaviour
    {
        private void Start()
        {
            GetComponent<Button>().onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            if(SceneSwitcher.CurrentScene.State is ShopState)
            {
                SceneSwitcher.CurrentScene.UpdateGameStateTo(new FightState());
            }
            else
            {
                SceneSwitcher.CurrentScene.UpdateGameStateTo(new ShopState());
            }
        }
    }
}