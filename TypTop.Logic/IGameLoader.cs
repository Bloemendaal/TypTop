namespace TypTop.Logic
{
    public interface IGameLoader
    {
        void LoadWorldMap();
        void LoadLevelMap(int worldId);
        void LoadMinigame(Level level);
    }
}