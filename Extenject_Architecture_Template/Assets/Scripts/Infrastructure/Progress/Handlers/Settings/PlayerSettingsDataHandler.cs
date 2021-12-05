using Infrastructure.Progress.Models;
using Infrastructure.Services.SaveAndLoad.DatabaseRepository;

namespace Infrastructure.Progress.Handlers.Settings
{
    public class PlayerSettingsDataHandler : IPlayerSettingsDataHandler
    {
        private const string SAVE_DATA_PATH = "Player_Settings_Data"; 
        
        private readonly IDBRepository _dbRepository = null;
        private PlayerSettingsDataModel _settingsDataModel = null;

        public PlayerSettingsDataHandler(IDBRepository dbRepository)
        {
            _dbRepository = dbRepository;
            _settingsDataModel = new PlayerSettingsDataModel();
        }
        
        public void Save()
        {
            _dbRepository.Update(SAVE_DATA_PATH, _settingsDataModel);
        }

        public void Load()
        {
            PlayerSettingsDataModel savedModel = _dbRepository.Get<PlayerSettingsDataModel>(SAVE_DATA_PATH);
            if (savedModel == null)
                return;
            
            _settingsDataModel = savedModel;
        }

        public void Clear()
        {
            _dbRepository.Remove(SAVE_DATA_PATH);
        }

        public void SetLanguagePreference(string newLanguage)
        {
            _settingsDataModel.CurrentLanguage = newLanguage;
        }

        public string GetCurrentLanguage()
        {
            return _settingsDataModel.CurrentLanguage;
        }
    }
}