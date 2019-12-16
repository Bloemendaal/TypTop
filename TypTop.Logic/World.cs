using System.Collections.Generic;
using TypTop.Logic;

namespace TypTop.GameGui
{
    public class World
    {
        public World(string previewImage, string background, IList<Level> levels, WorldId id)
        {
            PreviewImage = previewImage;
            Background = background;
            foreach (Level level in levels) level.World = this;
            Levels = levels;
            Id = id;
        }

        public string PreviewImage { get; }
        public string Background { get; }
        public IList<Level> Levels { get; }
        public WorldId Id { get; }
    }

    public enum WorldId
    {
        Space = 1,
        Tavern = 2
    }
}