using System.Security.Cryptography.X509Certificates;

namespace TypTop.GameGui
{
    public class World
    {
        string PreviewImage { get; }

        public World(string previewImage)
        {
            PreviewImage = previewImage;
        }
    }
}