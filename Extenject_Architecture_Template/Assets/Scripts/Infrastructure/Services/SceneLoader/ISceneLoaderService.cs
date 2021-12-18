using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure.Services.SceneLoader
{
    public interface ISceneLoaderService<TPayLoad, UPayLoad>
    {
        public void LoadSceneAsync(TPayLoad scene, LoadSceneMode loadSceneMode);
        public AsyncOperation LoadSceneAsync(UPayLoad scene, LoadSceneMode loadSceneMode);
    }
}