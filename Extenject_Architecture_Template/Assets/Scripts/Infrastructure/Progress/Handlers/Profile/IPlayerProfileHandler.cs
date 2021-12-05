namespace Infrastructure.Progress.Handlers.Profile
{
    public interface IPlayerProfileHandler : IProgressDataHandler
    {
        void SetPlayerID(int newID);
        int GetPlayerID();
        void SetPlayerName(string newName);
        string GetPlayerName();
    }
}