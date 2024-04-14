using System.Collections;
using UnityEngine;

namespace CodeBase.Hits
{
    [RequireComponent(typeof(Health))]
    public sealed class HitColorSwitcher : MonoBehaviour
    {
        public SpriteRenderer spriteRenderer;
        
        public Color color;

        private Health _health;

        private Coroutine _switched;
        
        private void Start()
        {
            _health = GetComponent<Health>();
        }

        private void OnEnable()
        {
            _health = GetComponent<Health>();
            _health.OnHit += OnHit;
        }

        private void OnDisable()
        {
            _health.OnHit -= OnHit;
        }

        private void OnHit()
        {
            if(_switched == null)
                _switched = StartCoroutine(SwitchToColor());
        }

        private IEnumerator SwitchToColor()
        {
            var startColor = spriteRenderer.color;
            
            spriteRenderer.color = color;

            yield return new WaitForSeconds(0.4f);

            spriteRenderer.color = startColor;
            _switched = null;
        }
    }
}