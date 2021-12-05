using System;
using System.Collections.Generic;
using Infrastructure.Progress.Handlers;
using Infrastructure.Progress.Handlers.Profile;
using Infrastructure.Progress.Handlers.Settings;
using Infrastructure.Progress.Handlers.Wallet;
using Zenject;

namespace Infrastructure.Progress
{   
    public class ProgressDataHolder : IProgressDataHolder, IInitializable, IDisposable
    {
        public IPlayerProfileHandler ProfileProgress => _progressDataHandlers[typeof(IPlayerProfileHandler)] as IPlayerProfileHandler;
        public IPlayerSettingsDataHandler SettingsProgress => _progressDataHandlers[typeof(IPlayerSettingsDataHandler)] as IPlayerSettingsDataHandler;
        public IPlayerWalletDataHandler WalletProgress => _progressDataHandlers[typeof(IPlayerWalletDataHandler)] as IPlayerWalletDataHandler;
        
        private Dictionary<Type, IProgressDataHandler> _progressDataHandlers = null;
        
        public ProgressDataHolder(IPlayerProfileHandler playerProfileHandler, IPlayerSettingsDataHandler playerSettingsDataHandler, IPlayerWalletDataHandler walletDataHandler)
        {
            _progressDataHandlers = new Dictionary<Type, IProgressDataHandler>()
            {
                [typeof(IPlayerProfileHandler)] = playerProfileHandler,
                [typeof(IPlayerSettingsDataHandler)] = playerSettingsDataHandler,
                [typeof(IPlayerWalletDataHandler)] = walletDataHandler
            };
        }

        public void Initialize()
        {
            LoadAllData();
        }

        public void Dispose()
        {
            SaveAllData();
        }

        public void SaveAllData()
        {
            foreach (IProgressDataHandler progress in _progressDataHandlers.Values) 
                progress.Save();
        }
 
        public void LoadAllData()
        {
            foreach (IProgressDataHandler progress in _progressDataHandlers.Values) 
                progress.Load();
        }

        public void ClearAllData()
        {
            foreach (IProgressDataHandler progress in _progressDataHandlers.Values) 
                progress.Clear();
        }
    }
}