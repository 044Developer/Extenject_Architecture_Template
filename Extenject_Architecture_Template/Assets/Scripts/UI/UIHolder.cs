using UnityEngine;

namespace UI
{
    public class UIHolder : MonoBehaviour
    {
        [SerializeField] private Transform _windowsParent = null;
        [SerializeField] private Transform _loadingScreenParent = null;
        [SerializeField] private Transform _panelsScreenParent = null;
    
        public Transform WindowsParent => _windowsParent;
        public Transform LoadingScreenParent => _loadingScreenParent;
        public Transform PanelsScreenParent => _panelsScreenParent;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }
    }
}
