using System.ComponentModel.DataAnnotations;

namespace TypTop.Database
{
    public class Word
    {
        [Key] public string Letters { get; set; }
    }
}