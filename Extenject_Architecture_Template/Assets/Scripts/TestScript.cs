using Infrastructure.Services.AssetProvider;
using UI.Controller;
using UnityEngine;
using Zenject;

namespace DefaultNamespace
{
    public class TestScript : ITickable
    {
        private readonly UIController _uiController;
        private readonly IAssetProvider _assetProvider;

        public TestScript(UIController uiController, IAssetProvider assetProvider)
        {
            _uiController = uiController;
            _assetProvider = assetProvider;
        }

        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                _uiController.OnShowEntryWindow();       
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                _uiController.OnShowExitWindow();
            }
            else if (Input.GetKeyDown(KeyCode.C))
            {
                _assetProvider.CleanUp();
            }
        }
    }
}