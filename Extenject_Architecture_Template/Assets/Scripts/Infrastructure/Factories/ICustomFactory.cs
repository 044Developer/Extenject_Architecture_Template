using UnityEngine;

namespace Infrastructure.Factories
{
    public interface ICustomFactory
    {
        T Create<T>(GameObject prefab);
        T Create<T>(GameObject prefab, Transform parent);
    }
}