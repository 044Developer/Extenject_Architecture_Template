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
        private Dictionary<UIWindowType, ObjectWindow> _cachedWindows = new Dictionary<UIWindowType, ObjectWindow>();
        private Dictionary<UIPanelType, ObjectPanel> _cachedPanels = new Dictionary<UIPanelType, ObjectPanel>();

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

        public async void OnShowLoadingWindow(Action onComplete = null)
        {
            AssetReferenceGameObject assetReference = _windowStaticData.GetAddressableAsset(UIWindowType.LoadingWindow);
            LoadingScreenWindow window = await _factory.Create<LoadingScreenWindow>(assetReference, _uiHolder.LoadingScreenParent);
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
            window.Dispose();
        }

        public void OnClosePanel(UIPanelType panelType)
        {
            if (!_cachedPanels.TryGetValue(panelType, out var panel))
                return;
            _cachedPanels.Remove(panelType);
            panel.Close();
            panel.Dispose();
        }

        public async void OnShowMainPanel()
        {
            AssetReferenceGameObject assetReference = _panelsStaticDataContainer.GetAddressableAsset(UIPanelType.MainPanel);
            MainPanel panel = await _factory.Create<MainPanel>(assetReference, _uiHolder.PanelsScreenParent);
            CachePanel(UIPanelType.MainPanel, panel);
            panel.Initialize();
            panel.Show();
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

        private void CachePanel(UIPanelType panelType, ObjectPanel panel)
        {
            if (_cachedPanels.ContainsKey(panelType))
                return;
            _cachedPanels[panelType] = panel;
        }
    }
}