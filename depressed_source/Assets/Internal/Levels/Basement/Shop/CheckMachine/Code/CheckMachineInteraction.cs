using AutumnForest;
using CodeBase.GUIWindows;
using CodeBase.Interactions;
using destructive_code.Scenes;

namespace Shop.CheckMachineCode
{
    public class CheckMachineInteraction : Interaction
    {
        public GUILayer layer;
        
        public override void Interact()
        {
            SceneSwitcher.CurrentScene.SceneGUI.OpenLayer(layer);
        }
    }
}