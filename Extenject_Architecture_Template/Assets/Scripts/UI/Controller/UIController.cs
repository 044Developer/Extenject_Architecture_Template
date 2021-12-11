using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Factories;
using StaticData.UIStaticData.WindowsData;
using UI.Windows;
using UI.Windows.EntryWindow;
using UI.Windows.ExitWindow;
using UI.Windows.LoadingScreenWindow;
using UnityEngine.AddressableAssets;

namespace UI.Controller
{
    public class UIController
    {
        private UIHolder _uiHolder = null;
        private readonly ICustomFactory _factory = null;
        private readonly WindowsStaticDataContainer _windowStaticData = null;
        private Dictionary<UIWindowType, ObjectWindow> _cachedWindows = new Dictionary<UIWindowType, ObjectWindow>();

        public UIController(ICustomFactory factory, WindowsStaticDataContainer windowStaticData)
        {
            _factory = factory;
            _windowStaticData = windowStaticData;
        }
        
        public async void BootstrapUI(Action onComplete)
        {
            AssetReferenceGameObject assetReference = _windowStaticData.GetAddressableAsset(UIWindowType.UIHolder);
            _uiHolder = await _factory.Create<UIHolder>(assetReference);
            onComplete?.Invoke();
        }

        public async void OnShowLoadingWindow(Action onComplete = null)
        {
            AssetReferenceGameObject assetReference = _windowStaticData.GetAddressableAsset(UIWindowType.LoadingWindow);
            LoadingScreenWindow window = await _factory.Create<LoadingScreenWindow>(assetReference, _uiHolder.WindowsParent);
            CacheWindow(UIWindowType.LoadingWindow, window);
            window.Initialize();
            window.Show();
            onComplete?.Invoke();
        }

        public void OnCloseWindow(UIWindowType windowType)
        {
            if (!_cachedWindows.TryGetValue(windowType, out var window))
                return;
            _cachedWindows.Remove(windowType);
            window.Close();
        }

        public async void OnShowEntryWindow()
        {
            AssetReferenceGameObject assetReference = _windowStaticData.GetAddressableAsset(UIWindowType.EnterWindow);
            EntryWindow window = await _factory.Create<EntryWindow>(assetReference, _uiHolder.WindowsParent);
            CacheWindow(UIWindowType.EnterWindow, window);
            window.Initialize();
            window.Show();
        }

        public async void OnShowExitWindow()
        {
            AssetReferenceGameObject assetReference = _windowStaticData.GetAddressableAsset(UIWindowType.ExitWindow);
            ExitWindow window = await _factory.Create<ExitWindow>(assetReference, _uiHolder.WindowsParent);
            CacheWindow(UIWindowType.ExitWindow, window);
            window.Initialize();
            window.Show();
        }

        private void CacheWindow(UIWindowType windowType, ObjectWindow window)
        {
            if (_cachedWindows.ContainsKey(windowType))
                return;
            _cachedWindows[windowType] = window;
        }
    }
}