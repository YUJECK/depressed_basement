using CodeBase.GUIWindows;
using destructive_code.Scenes;
using GUILayer = CodeBase.GUIWindows.GUILayer;

namespace Shop.CheckMachineCode
{
    public sealed class TerminalWindow : GUIWindow
    {
        protected override void OnThisOpened(GUILayer layer)
        {
            base.OnThisOpened(layer);
            
            var checks = SceneSwitcher.BasementScene.CheckMachine.Current;
            var guiElements = GetComponentsInChildren<CheckCard>(true);

            foreach (var guiElement in guiElements)
            {
                guiElement.gameObject.SetActive(false);
            }
            for(int i = 0; i < checks.Length; i++)
            {
                guiElements[i].SetCheck(checks[i]);
                guiElements[i].gameObject.SetActive(true);
            }
        }

        protected override void OnThisClosed(GUILayer layer)
        {
            base.OnThisClosed(layer);
            
            
        }
    }
}