using StaticData.SceneStaticData.MainApplicationScenes;
using StaticData.UIStaticData.PanelsData;
using StaticData.UIStaticData.WindowsData;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "StaticDataInstaller", menuName = "Installers/StaticDataInstaller")]
public class StaticDataInstaller : ScriptableObjectInstaller<StaticDataInstaller>
{
    [SerializeField] private WindowsStaticDataContainer _windowStaticData = null;
    [SerializeField] private PanelsStaticDataContainer _panelsStaticDataContainer = null;
    [SerializeField] private SceneStaticDataContainer _sceneStaticDataContainer = null;

    public override void InstallBindings()
    {
        Container.BindInstance(_windowStaticData).AsSingle();
        Container.BindInstance(_panelsStaticDataContainer).AsSingle();
        Container.BindInstance(_sceneStaticDataContainer).AsSingle();
    }
}