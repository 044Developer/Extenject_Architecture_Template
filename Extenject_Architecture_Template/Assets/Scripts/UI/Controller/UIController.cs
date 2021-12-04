using Infrastructure.Factories;
using Infrastructure.Services.AssetProvider;
using StaticData.UIStaticData.WindowsData;
using UI.Windows.EntryWindow;
using UI.Windows.ExitWindow;

namespace UI.Controller
{
    public class UIController
    {
        private readonly IAssetProvider _assetProvider = null;
        private readonly ICustomFactory _factory = null;
        private readonly WindowsStaticDataContainer _windowStaticData = null;

        public UIController(IAssetProvider assetProvider, ICustomFactory factory, WindowsStaticDataContainer windowStaticData)
        {
            _assetProvider = assetProvider;
            _factory = factory;
            _windowStaticData = windowStaticData;
        }

        public void OnShowEntryWindow()
        {
            string path = _windowStaticData.GetPath(UIWindowType.EnterWindow);
            EntryWindow window = SpawnElement<EntryWindow>(path);
            window.Initialize();
            window.Show();
        }

        public void OnShowExitWindow()
        {
            string path = _windowStaticData.GetPath(UIWindowType.ExitWindow);
            ExitWindow window = SpawnElement<ExitWindow>(path);
            window.Initialize();
            window.Show();
        }

        private T SpawnElement<T>(string path)
        {
            var prefab = _assetProvider.GetAsset(path); 
            return _factory.Create<T>(prefab);
        }
    }
}