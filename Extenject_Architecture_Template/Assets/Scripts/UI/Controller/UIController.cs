using System;
using System.Collections.Generic;
using Infrastructure.Factories;
using StaticData.UIStaticData.PanelsData;
using StaticData.UIStaticData.WindowsData;
using UI.Panels;
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
        private readonly PanelsStaticDataContainer _panelsStaticDataContainer = null;
        private Dictionary<Type, ObjectWindow> _cachedWindows = new Dictionary<Type, ObjectWindow>();
        private Dictionary<Type, ObjectPanel> _cachedPanels = new Dictionary<Type, ObjectPanel>();

        private LoadingScreenWindow _loadingScreenWindow = null;
        
        public UIController(ICustomFactory factory, WindowsStaticDataContainer windowStaticData, PanelsStaticDataContainer panelsStaticDataContainer)
        {
            _factory = factory;
            _windowStaticData = windowStaticData;
            _panelsStaticDataContainer = panelsStaticDataContainer;
        }
        
        public async void BootstrapUI(Action onComplete)
        {
            AssetReferenceGameObject assetReference = _windowStaticData.GetAddressableAsset(UIWindowType.UIHolder);
            _uiHolder = await _factory.Create<UIHolder>(assetReference);
            onComplete?.Invoke();
        }

        public async void OnStartLoadingWindow(Action onComplete = null)
        {
            AssetReferenceGameObject assetReference = _windowStaticData.GetAddressableAsset(UIWindowType.LoadingWindow);
            _loadingScreenWindow = await _factory.Create<LoadingScreenWindow>(assetReference, _uiHolder.LoadingScreenParent);
            CacheWindow<LoadingScreenWindow>(_loadingScreenWindow);
            _loadingScreenWindow.Initialize();
            _loadingScreenWindow.Show();
            _loadingScreenWindow.StartLoading();
            onComplete?.Invoke();
        }

        public void OnFinalizeLoadingWindow()
        {
            _loadingScreenWindow.FinalizeLoading();
        }

        public void OnCloseWindow<TWindow>()
        {
            if (!_cachedWindows.TryGetValue(typeof(TWindow), out var window))
                return;
            _cachedWindows.Remove(typeof(TWindow));
            window.Close();
            window.Dispose();
        }

        public void OnClosePanel<TPanel>()
        {
            if (!_cachedPanels.TryGetValue(typeof(TPanel), out var panel))
                return;
            _cachedPanels.Remove(typeof(TPanel));
            panel.Close();
            panel.Dispose();
        }

        public async void OnShowMainPanel()
        {
            AssetReferenceGameObject assetReference = _panelsStaticDataContainer.GetAddressableAsset(UIPanelType.MainPanel);
            MainPanel panel = await _factory.Create<MainPanel>(assetReference, _uiHolder.PanelsScreenParent);
            CachePanel<MainPanel>(panel);
            panel.Initialize();
            panel.Show();
        }

        public async void OnShowEntryWindow()
        {
            AssetReferenceGameObject assetReference = _windowStaticData.GetAddressableAsset(UIWindowType.EnterWindow);
            EntryWindow window = await _factory.Create<EntryWindow>(assetReference, _uiHolder.WindowsParent);
            CacheWindow<EntryWindow>(window);
            window.Initialize();
            window.Show();
        }

        public async void OnShowExitWindow()
        {
            AssetReferenceGameObject assetReference = _windowStaticData.GetAddressableAsset(UIWindowType.ExitWindow);
            ExitWindow window = await _factory.Create<ExitWindow>(assetReference, _uiHolder.WindowsParent);
            CacheWindow<ExitWindow>(window);
            window.Initialize();
            window.Show();
        }

        private void CacheWindow<TWindow>(ObjectWindow window)
        {
            if (_cachedWindows.ContainsKey(typeof(TWindow)))
                return;
            _cachedWindows[typeof(TWindow)] = window;
        }

        private ObjectWindow GetCachedWindow<TWindow>()
        {
            if (_cachedWindows.TryGetValue(typeof(TWindow), out var window))
            {
                return window;
            }

            return null;
        }

        private void CachePanel<TPanel>(ObjectPanel panel)
        {
            if (_cachedPanels.ContainsKey(typeof(TPanel)))
                return;
            _cachedPanels[typeof(TPanel)] = panel;
        }
    }
}