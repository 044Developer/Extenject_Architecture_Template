using UnityEngine;

namespace UI
{
    public class UIHolder : MonoBehaviour
    {
        [SerializeField] private Transform _windowsParent = null;
    
        public Transform WindowsParent => _windowsParent;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }
    }
}
