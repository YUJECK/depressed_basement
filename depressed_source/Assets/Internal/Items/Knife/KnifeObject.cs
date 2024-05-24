using System;
using System.Collections;
using AutumnForest;
using CodeBase.GameStates;
using CodeBase.Hits;
using CodeBase.Inputs;
using CodeBase.Items;
using destructive_code.Scenes;
using PlayerStuff;
using UnityEngine;

namespace Items.Knife
{
    [RequireComponent(typeof(HitOnTrigger))]
    public sealed class KnifeObject : WeaponObject
    {
        [Header("Stats")]
        [SerializeField] private BladeHitData data;
        [SerializeField] private float speed;
        [SerializeField] private float duration;

        [Header("Other")]
        [SerializeField] private PitchedAudio attackSound;
        [SerializeField] private Transform knifeDefaultPoint;

        private Player player;
        private HitOnTrigger hitOnTrigger;
        
        private bool CurrentAttack => knifeAttackRoutine != null;
        private Coroutine knifeAttackRoutine;

        private void Start()
        {
            GetComponent<HitOnTrigger>().AddExclude<PlayerHealth>();
        }

        private void OnEnable()
        {
            InputsHandler.OnAttack += Attack;

            hitOnTrigger = GetComponentInChildren<HitOnTrigger>(true);
            
            player = SceneSwitcher.BasementScene.Player;
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
            if(CurrentAttack)
                return;
            
            knifeAttackRoutine = StartCoroutine(Animation());
        }

        private IEnumerator Animation()
        {
            player.Stopped = true;
            hitOnTrigger.Enabled = true;
            attackSound.Play();
            
            var startTime = Time.time;
            var direction = transform.up;
            
            float effect = 5;

            while (startTime + duration > Time.time)
            {
                transform.position += direction * (speed * Time.deltaTime * effect);
                effect -= 0.2f;
                yield return new WaitForFixedUpdate();
            }
            
            while (Vector3.Distance(transform.position, knifeDefaultPoint.position) > 0.01)
            {
                transform.position = Vector3.MoveTowards(transform.position, knifeDefaultPoint.position, (Time.deltaTime * speed));
                yield return new WaitForFixedUpdate();
            }

            transform.position = knifeDefaultPoint.position;
            
            player.Stopped = false;
            hitOnTrigger.Enabled = false;

            knifeAttackRoutine = null;
        }

        public void StopAttack()
        {
            if(!CurrentAttack)
                return;
            
            StopCoroutine(knifeAttackRoutine);
            knifeAttackRoutine = null;
            
            transform.position = knifeDefaultPoint.position;
            
            player.Stopped = false;
            hitOnTrigger.Enabled = false;
        }
    }
}