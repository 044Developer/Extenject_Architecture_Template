using System;

namespace Infrastructure.Progress.Models
{
    [Serializable]
    public class PlayerProfileModel : IProgressDataModel
    {
        public int PlayerID = 0;
        public string PlayerName = "Player_01";
    }
}