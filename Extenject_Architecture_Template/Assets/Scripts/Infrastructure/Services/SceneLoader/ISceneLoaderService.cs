using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure.Services.SceneLoader
{
    public interface ISceneLoaderService<TPayLoad>
    {
        public AsyncOperation LoadSceneAsync(TPayLoad scene, LoadSceneMode loadSceneMode);
    }
}