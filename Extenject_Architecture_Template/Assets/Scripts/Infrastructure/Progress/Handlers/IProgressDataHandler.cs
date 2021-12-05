namespace Infrastructure.Progress.Handlers
{
    public interface IProgressDataHandler
    {
        void Save();
        void Load();
        void Clear();
    }
}