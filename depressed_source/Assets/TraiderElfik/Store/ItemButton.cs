using CodeBase;
using CodeBase.GameState;
using CodeBase.Items;
using destructive_code.Scenes;
using destructive_code.Sounds;
using UnityEngine;
using UnityEngine.UI;

namespace TraiderElfik
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Button))]
    [RequireComponent(typeof(Image))]
    public class ItemButton : DepressedBehaviour
    {
        [SerializeField] private Image boughtImage;
        
        private Button _button;
        private Image _image;   

        private Weapon _currentWeapon;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _image = GetComponent<Image>();
            boughtImage.gameObject.SetActive(false);
            
            _button.onClick.AddListener(BuyItem);
        }

        private void BuyItem()
        {
            if (SceneSwitcher.CurrentScene.TryGetState(out GameplayState state) && state.Money >= _currentWeapon.Cost && !boughtImage.gameObject.activeSelf)
            {
                AudioPlayer.Play("Pay");
                boughtImage.gameObject.SetActive(true);
                state.Money -= _currentWeapon.Cost;
                state.Player.Equiper.Equip(_currentWeapon);    
            }
        }

        public void Connect(Weapon weapon)
        {
            _image.sprite = weapon.Icon;
            _currentWeapon = weapon;
        }
    }
}