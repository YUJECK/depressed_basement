using CodeBase.Inputs;
using destructive_code.Sounds;
using UnityEngine;

namespace PlayerStuff
{
    [RequireComponent(typeof(Player))]
    public sealed class PlayerMovement : MonoBehaviour
    {
        public string WalkSound;
        
        private Animator _animator;
        private static readonly int PlayerWalk = Animator.StringToHash("PlayerWalk");

        private Player _player;

        private void Awake()
        {
            _animator = GetComponentInChildren<Animator>();
            _player = GetComponent<Player>();
        }
        
        private void Update()
        {
            if(_player.Stopped)
                return;
            
            Vector2 movemet = InputsHandler.Movement;
            
            transform.position += new Vector3(movemet.x,movemet.y, 0) * (Time.deltaTime * 3);

            if (movemet != Vector2.zero)
            {
                _animator.SetBool(PlayerWalk, true);
                
                if(WalkSound != null && !AudioPlayer.IsPlaying(WalkSound))
                {
                    AudioPlayer.Play(WalkSound);
                }
            }
            else
            {
                _animator.SetBool(PlayerWalk, false);
                
                if(WalkSound != "")
                {
                    AudioPlayer.Stop(WalkSound);
                }
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