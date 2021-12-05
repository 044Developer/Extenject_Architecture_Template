namespace Infrastructure.Services.SaveAndLoad.JsonWrapper.JsonUtility
{
    public interface IJsonWrapper
    {
        T FromJson<T>(string json);
        string ToJson<T>(T value);
    }
}