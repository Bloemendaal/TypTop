using System.Collections.Generic;
using TypTop.GameGui;

namespace TypTop.Logic
{
    public interface IGameLoader
    {
        void LoadWorldMap();
        void LoadLevelMap(World world);
        void LoadMinigame(Level level);
    }
}