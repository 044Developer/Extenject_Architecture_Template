namespace Infrastructure.Services.SaveAndLoad.JsonWrapper.JsonUtility
{
    public class JsonUtilityWrapper : IJsonWrapper
    {
        public T FromJson<T>(string json)
        {
            return UnityEngine.JsonUtility.FromJson<T>(json);
        }

        public string ToJson<T>(T value)
        {
            return UnityEngine.JsonUtility.ToJson(value);
        }
    }
}