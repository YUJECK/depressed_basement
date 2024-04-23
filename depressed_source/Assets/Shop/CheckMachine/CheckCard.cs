using destructive_code.Scenes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Shop.CheckMachineCode
{
    [RequireComponent(typeof(Button))]
    public class CheckCard : MonoBehaviour
    {
        [SerializeField] private CheckMachineGUI checkMachineGUI;
        [SerializeField] private TMP_Text nameLabel;
        [SerializeField] private TMP_Text descriptionLabel;
        
        public Check Current { get; private set; }
        
        private void Start()
        {
            GetComponent<Button>().onClick.AddListener(OnClick);
        }

        public void SetCheck(Check check)
        {
            if(check == null)
                return;
            
            Current = check;

            nameLabel.text = check.GetName();
            descriptionLabel.text = check.GetDescription();
        }

        private void OnClick()
        {
            if (Current != null)
            {
                SceneSwitcher.BasementScene.CheckMachine.ReceiveCheck(Current);
                Current = null;
                checkMachineGUI.TerminalSound.Play();
                gameObject.SetActive(false);
            }
        }
    }
}