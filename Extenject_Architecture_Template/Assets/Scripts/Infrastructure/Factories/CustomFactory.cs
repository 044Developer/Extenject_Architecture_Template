using UnityEngine;
using Zenject;

namespace Infrastructure.Factories
{
    public class CustomFactory : ICustomFactory
    {
        private readonly DiContainer _container = null;

        public CustomFactory(DiContainer container)
        {
            _container = container;
        }

        public T Create<T>(GameObject prefab)
        {
            return _container.InstantiatePrefabForComponent<T>(prefab);
        }

        public T Create<T>(GameObject prefab, Transform parent)
        {
            return _container.InstantiatePrefabForComponent<T>(prefab, parent);
        }
    }
}