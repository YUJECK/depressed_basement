using System.Collections;
using AutumnForest;
using CodeBase.GameState;
using CodeBase.Hits;
using CodeBase.Inputs;
using CodeBase.Items;
using destructive_code.Scenes;
using PlayerStuff;
using UnityEngine;

namespace Items.Knife
{
    public sealed class KnifeObject : WeaponObject
    {
        [SerializeField] private BladeHitData data;
        
        [SerializeField] private float speed;
        [SerializeField] private float duration;

        [SerializeField] private PitchedAudio attackSound;

        private bool currentAttack = false;
        private Player _player;
        private HitOnTrigger hitOnTrigger;

        private void OnEnable()
        {
            InputsHandler.OnAttack += Attack;
            SceneSwitcher.CurrentScene.TryGetState(out GameplayState state);

            hitOnTrigger = GetComponentInChildren<HitOnTrigger>(true);
            
            _player = state.Player;
        }

        public override HitData GetHitData()
        {
            return data;
        }

        private void OnDisable()
        {
            InputsHandler.OnAttack -= Attack;  
        }

        private void Attack()
        {
            if(currentAttack)
                return;
            
            StartCoroutine(Animation());
        }

        private IEnumerator Animation()
        {
            currentAttack = true;
            _player.Stopped = true;
            hitOnTrigger.Enabled = true;
            attackSound.Play();
            
            var startTime = Time.time;
            var direction = transform.up;
            Vector3 startPosition = transform.position;
            
            float effect = 5;

            while (startTime + duration > Time.time)
            {
                transform.position += direction * (speed * Time.deltaTime * effect);
                effect -= 0.2f;
                yield return new WaitForFixedUpdate();
            }
            
            while (Vector3.Distance(transform.position, startPosition) > 0.01)
            {
                transform.position = Vector3.MoveTowards(transform.position, startPosition, (Time.deltaTime * speed));
                yield return new WaitForFixedUpdate();
            }

            transform.position = startPosition;
            
            _player.Stopped = false;
            hitOnTrigger.Enabled = false;
            currentAttack = false;
        }
    }
}