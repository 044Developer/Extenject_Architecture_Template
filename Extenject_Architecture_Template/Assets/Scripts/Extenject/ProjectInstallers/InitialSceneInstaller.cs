using Infrastructure.ApplicationStateMachine;
using Infrastructure.Factories;
using UI.Controller;
using Zenject;

public class InitialSceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindApplicationStates();
        BindUIController();
        BindCustomFactory();
    }
    
    private void BindApplicationStates() => 
        Container.BindInterfacesAndSelfTo<ApplicationStateMachine>().AsSingle();

    private void BindUIController() => 
        Container.Bind<UIController>().AsSingle();

    private void BindCustomFactory() => 
        Container.Bind<ICustomFactory>().To(it => it.AllNonAbstractClasses()).AsSingle();
}