using Infrastructure.Progress.Handlers;
using Infrastructure.Progress.Handlers.Profile;
using Infrastructure.Progress.Handlers.Settings;
using Infrastructure.Progress.Handlers.Wallet;

namespace Infrastructure.Progress
{
    public interface IProgressDataHolder
    {
        IPlayerProfileHandler ProfileProgress { get; }
        IPlayerSettingsDataHandler SettingsProgress { get; }
        IPlayerWalletDataHandler WalletProgress { get; }
        void SaveAllData();
        void LoadAllData();
        void ClearAllData();
    }
}