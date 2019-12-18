using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TypTop.Logic;

namespace TypTop.GameGui
{
    public class World
    {
        public string PreviewImage { get; }
        public string Background { get; }
        public IList<Level> Levels { get; }
        public WorldId Id { get; }

        public World(string previewImage, string background, IList<Level> levels, WorldId id)
        {
            PreviewImage = previewImage;
            Background = background;
            foreach (Level level in levels)
            {
                level.World = this;
            }
            Levels = levels;
            Id = id;
        }
    }

    public enum WorldId
    {
        Space = 1,
        Tavern = 2,
        Jump = 3
    }
}