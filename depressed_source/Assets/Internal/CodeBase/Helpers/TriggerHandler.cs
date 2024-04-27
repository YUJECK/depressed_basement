using System;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Helpers
{
    public sealed class TriggerHandler : MonoBehaviour
    {
        public event Action<GameObject> OnEnter;
        public event Action<GameObject> OnExit;

        public GameObject Last => current[current.Count - 1];
        public GameObject[] Current => current.ToArray();
        private readonly List<GameObject> current = new List<GameObject>();
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            OnEnter?.Invoke(other.gameObject);
            current.Add(other.gameObject);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            OnExit?.Invoke(other.gameObject);
            current.Remove(other.gameObject);
        }
    }
}