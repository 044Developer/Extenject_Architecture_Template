using Infrastructure.Progress.Models;
using Infrastructure.Services.SaveAndLoad.DatabaseRepository;

namespace Infrastructure.Progress.Handlers.Wallet
{
    public class PlayerWalletDataHandler : IPlayerWalletDataHandler
    {
        private const string SAVE_DATA_PATH = "Player_Wallet_Data"; 
        
        private readonly IDBRepository _dbRepository = null;
        private PlayerWalletDataModel _walletDataModel = null;

        public PlayerWalletDataHandler(IDBRepository dbRepository)
        {
            _dbRepository = dbRepository;
            _walletDataModel = new PlayerWalletDataModel();
        }
        
        public void Save()
        {
            _dbRepository.Update(SAVE_DATA_PATH, _walletDataModel);
        }

        public void Load()
        {
            PlayerWalletDataModel savedModel = _dbRepository.Get<PlayerWalletDataModel>(SAVE_DATA_PATH);
            if(savedModel == null)
                return;
                
            _walletDataModel = savedModel;
        }

        public void Clear()
        {
            _dbRepository.Remove(SAVE_DATA_PATH);
        }

        public void AddHardCurrency(int count)
        {
            _walletDataModel.HardCurrency += count;
        }

        public bool CanSpendHardCurrency(int count)
        {
            if (_walletDataModel.HardCurrency < count)
                return false;
            
            _walletDataModel.HardCurrency -= count;
            return true;
        }

        public int GetHardCurrencyCount()
        {
            return _walletDataModel.HardCurrency;
        }

        public void AddSoftCurrency(int count)
        {
            _walletDataModel.SoftCurrency += count;
        }

        public bool CanSpendSoftCurrency(int count)
        {
            if (_walletDataModel.SoftCurrency < count)
                return false;
            
            _walletDataModel.SoftCurrency -= count;
            return true;
        }

        public int GetSoftCurrencyCount()
        {
            return _walletDataModel.SoftCurrency;
        }
    }
}