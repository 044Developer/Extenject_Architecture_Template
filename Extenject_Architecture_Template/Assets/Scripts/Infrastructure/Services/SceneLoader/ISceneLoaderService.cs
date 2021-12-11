using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure.Services.SceneLoader
{
    public interface ISceneLoaderService<TPayLoad, UPayLoad>
    {
        public void LoadSceneAsync(TPayLoad scene, LoadSceneMode loadSceneMode);
        public void LoadSceneAsync(UPayLoad scene, LoadSceneMode loadSceneMode);
        public Task<AsyncOperation> LoadSceneAsyncs(UPayLoad scene, LoadSceneMode loadSceneMode);
    }
}