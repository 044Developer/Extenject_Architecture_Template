using Infrastructure.Factories;
using StaticData.UIStaticData.WindowsData;
using UI.Windows.EntryWindow;
using UI.Windows.ExitWindow;
using UI.Windows.LoadingScreenWindow;
using UnityEngine.AddressableAssets;

namespace UI.Controller
{
    public class UIController
    {
        private readonly ICustomFactory _factory = null;
        private readonly WindowsStaticDataContainer _windowStaticData = null;

        public UIController(ICustomFactory factory, WindowsStaticDataContainer windowStaticData)
        {
            _factory = factory;
            _windowStaticData = windowStaticData;
        }

        public async void OnShowLoadingWindow()
        {
            AssetReferenceGameObject assetReference = _windowStaticData.GetAddressableAssetGetAsset(UIWindowType.LoadingWindow);
            LoadingScreenWindow window = await _factory.Create<LoadingScreenWindow>(assetReference);
            window.Initialize();
            window.Show();
        }

        public async void OnShowEntryWindow()
        {
            AssetReferenceGameObject assetReference = _windowStaticData.GetAddressableAssetGetAsset(UIWindowType.EnterWindow);
            EntryWindow window = await _factory.Create<EntryWindow>(assetReference);
            window.Initialize();
            window.Show();
        }

        public async void OnShowExitWindow()
        {
            AssetReferenceGameObject assetReference = _windowStaticData.GetAddressableAssetGetAsset(UIWindowType.ExitWindow);
            ExitWindow window = await _factory.Create<ExitWindow>(assetReference);
            window.Initialize();
            window.Show();
        }
    }
}