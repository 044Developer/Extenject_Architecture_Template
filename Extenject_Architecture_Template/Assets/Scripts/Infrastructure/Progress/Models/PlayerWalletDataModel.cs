using System;

namespace Infrastructure.Progress.Models
{
    [Serializable]
    public class PlayerWalletDataModel : IProgressDataModel
    {
        public int SoftCurrency = 0;
        public int HardCurrency = 0;
    }
}