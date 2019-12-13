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

        public World(string previewImage, string background, IList<Level> levels)
        {
            PreviewImage = previewImage;
            Background = background;
            Levels = levels;
        }
    }
}