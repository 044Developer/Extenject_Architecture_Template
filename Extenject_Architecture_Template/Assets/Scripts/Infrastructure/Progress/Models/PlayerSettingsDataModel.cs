using System;

namespace Infrastructure.Progress.Models
{
    [Serializable]
    public class PlayerSettingsDataModel : IProgressDataModel
    {
        public string CurrentLanguage = "English";
    }
}