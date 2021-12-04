using Infrastructure.Factories;
using Infrastructure.Services.AssetProvider;
using UI.Controller;
using Zenject;

public class ServicesInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IAssetProvider>().To(it => it.AllNonAbstractClasses()).AsSingle();
        Container.Bind<ICustomFactory>().To(it => it.AllNonAbstractClasses()).AsSingle();
        Container.Bind<UIController>().AsSingle();
    }
}                                                                                                                