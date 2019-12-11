namespace TypTop.Logic
{
    public interface IMinigameLoader
    {
        void LoadWorldMap();
        void LoadLevelMap(int worldId);
        void LoadMinigame(Level level);
    }
}