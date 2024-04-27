using AutumnForest;
using UnityEngine;
using GUILayer = CodeBase.GUIWindows.GUILayer;

namespace Shop.CheckMachineCode
{
    public class CheckMachineGUI : GUILayer
    {
        [field: SerializeField] public PitchedAudio TerminalSound { get; private set; }
        
        public override bool DisablePlayerControls => true;

        protected override void OnLayerOpened()
        {
            TerminalSound.Play();
        }

        protected override void OnLayerClosed()
        {
            TerminalSound.Play();
        }
    }
}