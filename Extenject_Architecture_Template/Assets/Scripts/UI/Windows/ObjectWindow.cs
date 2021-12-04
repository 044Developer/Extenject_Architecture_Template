using UnityEngine;

namespace UI.Windows
{
    public class ObjectWindow : MonoBehaviour, IUIElement
    {
        public void SetParent(Transform parent)
        {
            transform.SetParent(parent);
        }

        public virtual void Initialize()
        {
        }

        public virtual void Show()
        {
        }

        public virtual void Dispose()
        {
        }
    }
}