using System.Collections.Generic;
using CodeBase;
using CodeBase.CursorLogic;
using CodeBase.Inputs;
using CodeBase.Interactions;
using UnityEngine;

namespace PlayerStuff
{
    [DisallowMultipleComponent]
    public sealed class PlayerInteractions : DepressedBehaviour
    {
        private readonly Dictionary<Transform, Interaction> _interactions = new(); //текущие доступные интеракты
        private Interaction _lastPointed;
        
        private LayerMask _mask;
        
        public Vector2 CursorPosition => Camera.main.ScreenToWorldPoint(Input.mousePosition);

        private void Start()
        {
            _mask = LayerMask.GetMask("Interactions");
        }

        private void OnEnable()
        {
            InputsHandler.OnInteracted += OnInteracted;
        }

        private void OnDisable()
        {
            InputsHandler.OnInteracted -= OnInteracted;
        }

        private void OnInteracted()
        {
            if(_lastPointed != null)
                _lastPointed.Interact();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.TryGetComponent(out Interaction interaction))
                _interactions.Add(other.transform, interaction);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if(other.TryGetComponent(out Interaction interaction))
            {
                if (_lastPointed != null && other.transform == _lastPointed.transform)
                    _lastPointed = null;
                
                _interactions.Remove(other.transform);
            }
        }

        private void Update()
        {
            if (_lastPointed != null)
            {
                CursorSwitcher.SwitchToInteractions();
            }
            else
            {
                CursorSwitcher.SwitchToDefault();
            }
            
            if (_interactions.Count > 0 && !InputsHandler.ISUIMODE)
            {
                var result = Physics2D.Raycast(CursorPosition, Vector2.zero, 0, _mask);
                
                if(result.transform == null)
                {
                    _lastPointed = null;
                    return;
                }

                bool wasChanged = false;
                
                if (_interactions.TryGetValue(result.transform, out Interaction interaction) && interaction != _lastPointed)
                {
                    if(_lastPointed != null)
                        _lastPointed.PointedReleased();
                    
                    interaction.Pointed();
                  
                    _lastPointed = interaction;
                    wasChanged = true;
                }
                else if(interaction == _lastPointed)
                    return;

                if (!wasChanged && _lastPointed != null)
                {
                    _lastPointed.PointedReleased();
                    _lastPointed = null;
                }
            }
            else if (InputsHandler.ISUIMODE && _lastPointed != null)
            {
                _lastPointed = null;
            }
        }
    }
}