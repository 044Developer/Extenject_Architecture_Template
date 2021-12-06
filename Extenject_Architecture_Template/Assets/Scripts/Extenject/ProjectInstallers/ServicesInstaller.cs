using DefaultNamespace;
using Infrastructure.Factories;
using Infrastructure.Progress;
using Infrastructure.Progress.Handlers.Profile;
using Infrastructure.Progress.Handlers.Settings;
using Infrastructure.Progress.Handlers.Wallet;
using Infrastructure.Services.AssetProvider;
using Infrastructure.Services.SaveAndLoad.DatabaseRepository;
using Infrastructure.Services.SaveAndLoad.JsonWrapper.JsonUtility;
using Infrastructure.Services.SaveAndLoad.PlayerPrefsWrapper;
using UI.Controller;
using Zenject;

public class ServicesInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<AssetProviderService>().AsSingle();
        Container.Bind<ICustomFactory>().To(it => it.AllNonAbstractClasses()).AsSingle();
        Container.Bind<UIController>().AsSingle();
        Container.BindInterfacesAndSelfTo<TestScript>().AsSingle();
        
        BindPlayerProgress();
    }

    private void BindPlayerProgress()
    {
        Container.Bind<IDBRepository>().To(it => it.AllNonAbstractClasses()).AsSingle();
        Container.Bind<ISaveWrapper>().To(it => it.AllNonAbstractClasses()).AsSingle();
        Container.Bind<IJsonWrapper>().To(it => it.AllNonAbstractClasses()).AsSingle();
        Container.Bind<IPlayerProfileHandler>().To(it => it.AllNonAbstractClasses()).AsSingle();
        Container.Bind<IPlayerSettingsDataHandler>().To(it => it.AllNonAbstractClasses()).AsSingle();
        Container.Bind<IPlayerWalletDataHandler>().To(it => it.AllNonAbstractClasses()).AsSingle();
        Container.BindInterfacesAndSelfTo<ProgressDataHolder>().AsSingle();
    }
}                                                                                                                