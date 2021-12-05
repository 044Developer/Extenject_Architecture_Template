using Infrastructure.Progress.Models;
using Infrastructure.Services.SaveAndLoad.DatabaseRepository;

namespace Infrastructure.Progress.Handlers.Profile
{
    public class PlayerProfileHandler : IPlayerProfileHandler
    {
        private const string SAVE_DATA_PATH = "Player_Profile_Data"; 
        
        private readonly IDBRepository _dbRepository = null;
        private PlayerProfileModel _playerProfileModel = null;

        public PlayerProfileHandler(IDBRepository dbRepository)
        {
            _dbRepository = dbRepository;
            _playerProfileModel = new PlayerProfileModel();
        }

        public void Save()
        {
            _dbRepository.Update(SAVE_DATA_PATH, _playerProfileModel);
        }

        public void Load()
        {
            PlayerProfileModel savedModel = _dbRepository.Get<PlayerProfileModel>(SAVE_DATA_PATH);
            if(savedModel == null)
                return;
            
            _playerProfileModel = savedModel;
        }

        public void Clear()
        {
            _dbRepository.Remove(SAVE_DATA_PATH);
        }

        public void SetPlayerID(int newID)
        {
            _playerProfileModel.PlayerID = newID;
        }

        public int GetPlayerID()
        {
            return _playerProfileModel.PlayerID;
        }

        public void SetPlayerName(string newName)
        {
            _playerProfileModel.PlayerName = newName;
        }

        public string GetPlayerName()
        {
            return _playerProfileModel.PlayerName;
        }
    }
}