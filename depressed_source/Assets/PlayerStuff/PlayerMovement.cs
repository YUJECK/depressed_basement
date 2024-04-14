using System;
using CodeBase.GameState;
using CodeBase.Inputs;
using destructive_code.Scenes;
using UnityEngine;

namespace PlayerStuff
{
    public sealed class PlayerMovement : MonoBehaviour
    {
        private Animator _animator;
        private static readonly int PlayerWalk = Animator.StringToHash("PlayerWalk");
        
        private Player Player => SceneSwitcher.BasementScene.Player;

        private void Awake()
        {
            _animator = GetComponentInChildren<Animator>();
        }

        private void OnEnable()
        {
        }

        private void OnDisable()
        {
            
        }

        private void Update()
        {
            if(Player.Stopped)
                return;
            
            Vector2 movemet = InputsHandler.Movement;
            
            transform.position += new Vector3(movemet.x,movemet.y, 0) * (Time.deltaTime * 3);

            if (movemet != Vector2.zero)
            {
                _animator.SetBool(PlayerWalk, true);
            }
            else
            {
                _animator.SetBool(PlayerWalk, false);
            }

            if(movemet.x < 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (movemet.x > 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);          
            }
        }
    }
}