using System;
using CodeBase.Inputs;
using UnityEngine;

namespace Player
{
    public sealed class PlayerMovement : MonoBehaviour
    {
        private Animator _animator;
        private static readonly int PlayerWalk = Animator.StringToHash("PlayerWalk");

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