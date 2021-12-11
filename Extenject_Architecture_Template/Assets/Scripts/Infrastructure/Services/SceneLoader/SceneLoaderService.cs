using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure.Services.SceneLoader
{
    public enum SceneType { Initial, Main }
    public class SceneLoaderService : ISceneLoaderService<string, SceneType>
    {
        public void LoadSceneAsync(string scene, LoadSceneMode loadSceneMode)
        {
            SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
        }

        public void LoadSceneAsync(SceneType scene, LoadSceneMode loadSceneMode)
        {
            
        }

        public async Task<AsyncOperation> LoadSceneAsyncs(SceneType scene, LoadSceneMode loadSceneMode)
        {
            AsyncOperation load = SceneManager.LoadSceneAsync("scene", loadSceneMode);
            return load;
        }
    }
}