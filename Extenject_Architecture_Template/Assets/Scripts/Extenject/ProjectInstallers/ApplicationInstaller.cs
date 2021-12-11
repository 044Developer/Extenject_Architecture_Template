using Infrastructure.Helpers.DoTweenHelper;
using Infrastructure.Progress;
using Infrastructure.Progress.Handlers.Profile;
using Infrastructure.Progress.Handlers.Settings;
using Infrastructure.Progress.Handlers.Wallet;
using Infrastructure.Services.AssetProvider;
using Infrastructure.Services.SaveAndLoad.DatabaseRepository;
using Infrastructure.Services.SaveAndLoad.JsonWrapper.JsonUtility;
using Infrastructure.Services.SaveAndLoad.PlayerPrefsWrapper;
using Infrastructure.Services.SceneLoader;
using StaticData.SceneStaticData.MainApplicationScenes;
using Zenject;

public class ApplicationInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindApplicationHelpers();
        BindAssetProvider();
        BindSceneLoaderService();
        BindPlayerProgress();
    }

    private void BindApplicationHelpers() => 
        Container.Bind<DoTweenHelper>().AsSingle();

    private void BindAssetProvider() => 
        Container.BindInterfacesAndSelfTo<AssetProviderService>().AsSingle();

    private void BindSceneLoaderService() =>
        Container.Bind<ISceneLoaderService<string, SceneType>>().To(it => it.AllNonAbstractClasses()).AsSingle();
    
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