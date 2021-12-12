using UnityEngine;

namespace UI
{
    public class UIHolder : MonoBehaviour
    {
        [SerializeField] private Transform _windowsParent = null;
        [SerializeField] private Transform _loadingScreenParent = null;
    
        public Transform WindowsParent => _windowsParent;
        public Transform LoadingScreenParent => _loadingScreenParent;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }
    }
}
