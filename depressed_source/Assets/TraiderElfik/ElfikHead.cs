using CodeBase;
using PlayerStuff;
using UnityEngine;

namespace TraiderElfik
{
    public sealed class ElfikHead : DepressedBehaviour
    {
        private PlayerMovement _playerMovement;
        private SpriteRenderer _spriteRenderer;
        
        private void Awake()
        {
            _playerMovement = FindObjectOfType<PlayerMovement>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            if(_playerMovement.transform.position.x > transform.position.x)
                _spriteRenderer.flipX = true;
            else if(_playerMovement.transform.position.x < transform.position.x)
                _spriteRenderer.flipX = false;
        }
    }
}