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
        
        public UIController(ICustomFactory factory, WindowsStaticDataContainer windowStaticData, PanelsStaticDataContainer panelsStaticDataContainer)
        {
            _factory = factory;
            _windowStaticData = windowStaticData;
            _panelsStaticDataContainer = panelsStaticDataContainer;
        }
        
        public async void BootstrapUI(Action onComplete)
        {
            AssetReferenceGameObject assetReference = _windowStaticData.GetAddressableAsset(UIWindowType.UIHolder);
            _uiHolder = await _factory.CreateAsync<UIHolder>(assetReference);
            onComplete?.Invoke();
        }

        public void OnStartLoadingWindow(Action onComplete = null)
        {
            string assetReferencePath = _windowStaticData.GetPath(UIWindowType.LoadingWindow);
            var loadingScreenWindow = _factory.Create<LoadingScreenWindow>(assetReferencePath, _uiHolder.LoadingScreenParent);
            CacheWindow<LoadingScreenWindow>(loadingScreenWindow);
            loadingScreenWindow.Initialize();
            loadingScreenWindow.Show();
            loadingScreenWindow.StartLoading();
            onComplete?.Invoke();
        }

        public void OnFinalizeLoadingWindow()
        {
            bool isWindowCached = IsWindowCached<LoadingScreenWindow>();
            if (!isWindowCached)
                return;

            LoadingScreenWindow loadingScreenWindow = GetCachedWindow<LoadingScreenWindow>();
            loadingScreenWindow.FinalizeLoading();
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
            MainPanel panel = await _factory.CreateAsync<MainPanel>(assetReference, _uiHolder.PanelsScreenParent);
            CachePanel<MainPanel>(panel);
            panel.Initialize();
            panel.Show();
        }

        public async void OnShowEntryWindow()
        {
            AssetReferenceGameObject assetReference = _windowStaticData.GetAddressableAsset(UIWindowType.EnterWindow);
            EntryWindow window = await _factory.CreateAsync<EntryWindow>(assetReference, _uiHolder.WindowsParent);
            CacheWindow<EntryWindow>(window);
            window.Initialize();
            window.Show();
        }

        public async void OnShowExitWindow()
        {
            AssetReferenceGameObject assetReference = _windowStaticData.GetAddressableAsset(UIWindowType.ExitWindow);
            ExitWindow window = await _factory.CreateAsync<ExitWindow>(assetReference, _uiHolder.WindowsParent);
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

        private TWindow GetCachedWindow<TWindow>() where TWindow : ObjectWindow
        {
            return _cachedWindows[typeof(TWindow)] as TWindow;
        }

        private bool IsWindowCached<TWindow>()
        {
            return _cachedWindows.ContainsKey(typeof(TWindow));
        }

        private void CachePanel<TPanel>(ObjectPanel panel)
        {
            if (_cachedPanels.ContainsKey(typeof(TPanel)))
                return;
            _cachedPanels[typeof(TPanel)] = panel;
        }
    }
}