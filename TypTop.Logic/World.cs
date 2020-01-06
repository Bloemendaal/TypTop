using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TypTop.Logic;

namespace TypTop.GameGui
{
    public class World
    {
        public string PreviewImage { get; }
        public string PreviewHoverImage { get; }
        public string Background { get; }
        public IList<Level> Levels { get; }
        public WorldId Id { get; }
        public string Description { get; }

        public World(string previewImage, string background, IList<Level> levels, WorldId id, string previewHoverImage, string description)
        {
            PreviewImage = previewImage;
            Background = background;
            foreach (Level level in levels)
            {
                level.World = this;
            }
            Levels = levels;
            Id = id;
            PreviewHoverImage = previewHoverImage;
            Description = description;
        }
    }

    public enum WorldId
    {
        Space = 0,
        Tavern = 1,
        Jump = 2
    }
}