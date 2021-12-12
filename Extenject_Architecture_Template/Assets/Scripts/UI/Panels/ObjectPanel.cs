using UnityEngine;

namespace UI.Panels
{
    public class ObjectPanel : MonoBehaviour, IUIElement
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

        public virtual void Close()
        {
            Destroy(this.gameObject);
        }

        public virtual void Dispose()
        {
        }
    }
}