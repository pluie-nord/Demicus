namespace Demicus.Code.Infrastructure.Services.SaveLoadService
{
    public interface IPersistentProgressService
    {
        PlayerProgress Progress { get; set; }
    }
}