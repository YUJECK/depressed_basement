using destructive_code.Scenes;
using UnityEngine;
using Zenject;

namespace destructive_code
{
    public class Resolver
    {
        private static Resolver _instance;
        private DiContainer _diContainer;

        [Inject]
        private void GetContainer(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public static Resolver Instance()
        {
            if(_instance == null)
                _instance = new Resolver();

            return _instance;
        }

        public void InjectScene(Scene scene)
            => Inject(scene);

        public void InjectGameObject(GameObject gameObject)
        {
            Inject(gameObject);
        }
        

        private void Inject(object obj)
        {
            if (obj == null)
            {
                Debug.LogError("NULL OBJECT TO INJECT");
                return;
            }
            
            _diContainer.Inject(obj);
        }
    }
}