using UnityEngine;

namespace UI
{
    public interface IUIElement
    {
        void SetParent(Transform parent);
        void Initialize();
        void Show();
        void Dispose();
    }
}