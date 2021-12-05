namespace Infrastructure.Services.SaveAndLoad.DatabaseRepository
{
    public interface IDBRepository
    {
        void Update<T>(string path, T value);
        T Get<T>(string path);
        void Remove(string path);
    }
}