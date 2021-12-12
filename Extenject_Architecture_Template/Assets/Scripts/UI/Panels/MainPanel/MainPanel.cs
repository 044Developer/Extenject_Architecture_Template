using Infrastructure.Services.SceneLoader;
using StaticData.SceneStaticData.MainApplicationScenes;
using UI.Panels;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

public class MainPanel : ObjectPanel
{
    [SerializeField] private Button _firstLevelButton = null;
    [SerializeField] private Button _secondLevelButton = null;
    [SerializeField] private Button _thirdLevelButton = null;
    [SerializeField] private Button _fourthLevelButton = null;

    private ISceneLoaderService<string, SceneType> _sceneLoaderService = null;
    
    [Inject]
    public void Construct(ISceneLoaderService<string, SceneType> sceneLoaderService)
    {
        _sceneLoaderService = sceneLoaderService;
    }
    
    public override void Initialize()
    {
        base.Initialize();
        InitializeButtons();
    }

    public override void Show()
    {
        base.Show();
    }

    public override void Close()
    {
        base.Close();
    }

    public override void Dispose()
    {
        base.Dispose();
        DisposeButtons();
    }

    private void InitializeButtons()
    {
        _firstLevelButton.onClick
            .AddListener(() =>
            {
                OnLoadLevelButtonClicked(SceneType.Level_1);
            });
        
        _secondLevelButton.onClick
            .AddListener(() =>
            {
                OnLoadLevelButtonClicked(SceneType.Level_2);
            });
        
        _thirdLevelButton.onClick
            .AddListener(() =>
            {
                OnLoadLevelButtonClicked(SceneType.Level_3);
            });
        
        _fourthLevelButton.onClick
            .AddListener(() =>
            {
                OnLoadLevelButtonClicked(SceneType.Level_4);
            });
    }

    private void DisposeButtons()
    {
        _firstLevelButton.onClick.RemoveAllListeners();
        _secondLevelButton.onClick.RemoveAllListeners();
        _thirdLevelButton.onClick.RemoveAllListeners();
        _fourthLevelButton.onClick.RemoveAllListeners();
    }

    private void OnLoadLevelButtonClicked(SceneType sceneType)
    {
        _sceneLoaderService.LoadSceneAsync(sceneType, LoadSceneMode.Additive);
    }
}
