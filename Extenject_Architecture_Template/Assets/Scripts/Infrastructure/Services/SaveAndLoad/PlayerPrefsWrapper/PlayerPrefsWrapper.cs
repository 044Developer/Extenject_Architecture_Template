using UnityEngine;

namespace Infrastructure.Services.SaveAndLoad.PlayerPrefsWrapper
{
    public class PlayerPrefsWrapper : ISaveWrapper
    {
        public void UpdateSave(string path, string value)
        {
            if(value == string.Empty)
                return;
            
            PlayerPrefs.SetString(path, value);
        }

        public string GetSave(string path)
        {
            return PlayerPrefs.GetString(path);
        }

        public void RemoveSave(string path)
        {
            PlayerPrefs.DeleteKey(path);
        }
    }
}