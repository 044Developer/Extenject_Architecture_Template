namespace Infrastructure.Services.SaveAndLoad.PlayerPrefsWrapper
{
    public interface ISaveWrapper
    {
        void UpdateSave(string path, string value);
        string GetSave(string path);
        void RemoveSave(string path);
    }
}