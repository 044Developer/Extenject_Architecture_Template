using Infrastructure.Services.SaveAndLoad.JsonWrapper.JsonUtility;
using Infrastructure.Services.SaveAndLoad.PlayerPrefsWrapper;

namespace Infrastructure.Services.SaveAndLoad.DatabaseRepository.LocalDatabaseRepository
{
    public class LocalDatabaseRepository : IDBRepository
    {
        private readonly ISaveWrapper _saveWrapper = null;
        private readonly IJsonWrapper _jsonWrapper = null;

        public LocalDatabaseRepository(ISaveWrapper saveWrapper, IJsonWrapper jsonWrapper)
        {
            _saveWrapper = saveWrapper;
            _jsonWrapper = jsonWrapper;
        }

        public void Update<T>(string path, T value)
        {
            string json = _jsonWrapper.ToJson(value);
            _saveWrapper.UpdateSave(path, json);
        }

        public T Get<T>(string path)
        {
            string json = _saveWrapper.GetSave(path);
            T value = _jsonWrapper.FromJson<T>(json);

            return value;
        }

        public void Remove(string path)
        {
            _saveWrapper.RemoveSave(path);
        }
    }
}