using System.Threading.Tasks;
using Infrastructure.Services.SceneLoader;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace UI.Windows.LoadingScreenWindow
{
    public class LoadingScreenWindow : ObjectWindow
    {
        [SerializeField] private Slider _progressSlider = null;
        [SerializeField] private float _beginProgressFillSpeed = 200f;
        [SerializeField] private float _endProgressFillSpeed = 3f;

        private float _currentProgressFillSpeed = 0f;
        
        private ISceneLoaderService<string, SceneType> _sceneLoaderService = null;
        [Inject]
        public void Construct(ISceneLoaderService<string, SceneType> sceneLoaderService)
        {
            _sceneLoaderService = sceneLoaderService;

            Task<AsyncOperation> a = _sceneLoaderService.LoadSceneAsyncs(SceneType.Main, LoadSceneMode.Additive);
            Debug.Log($"PROGRESS = {a.Result.progress}");
        }
        
        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Show()
        {
            base.Show();
        }

        public override void Dispose()
        {
            base.Dispose();
        }

        private void DisplayFillBar()
        {
            //_progressSlider.value.
        }
    }
}