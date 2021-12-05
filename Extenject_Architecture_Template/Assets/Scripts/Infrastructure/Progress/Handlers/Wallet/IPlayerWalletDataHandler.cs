namespace Infrastructure.Progress.Handlers.Wallet
{
    public interface IPlayerWalletDataHandler : IProgressDataHandler
    {
        void AddHardCurrency(int count);
        bool CanSpendHardCurrency(int count);
        int GetHardCurrencyCount();
        void AddSoftCurrency(int count);
        bool CanSpendSoftCurrency(int count);
        int GetSoftCurrencyCount();
    }
}