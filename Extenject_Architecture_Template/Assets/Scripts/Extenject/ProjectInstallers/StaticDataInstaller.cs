using StaticData.UIStaticData.WindowsData;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "StaticDataInstaller", menuName = "Installers/StaticDataInstaller")]
public class StaticDataInstaller : ScriptableObjectInstaller<StaticDataInstaller>
{
    [SerializeField] private WindowsStaticDataContainer _windowStaticData = null;
    
    public override void InstallBindings()
    {
        Container.BindInstance(_windowStaticData).AsSingle();
    }
}