namespace Infrastructure.Progress.Handlers.Settings
{
    public interface IPlayerSettingsDataHandler : IProgressDataHandler
    {
        void SetLanguagePreference(string newLanguage);
        string GetCurrentLanguage();
    }
}