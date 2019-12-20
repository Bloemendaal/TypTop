using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TypTop.Database
{
    public class Level
    {
        [Key]
        public int LevelId { get; set; }

        [Required]
        public int WorldId { get; set; }

        public virtual World World { get; set; }

        public string Description { get; set; }

        [Required]
        public int Index { get; set; }

        [Required]
        public int WinCondition { get; set; }

        public string WordProvider { get; set; }

        public int ThresholdOneStar { get; set; }

        public int ThresholdTwoStars { get; set; }

        public int ThresholdThreeStars { get; set; }

        [Required]
        public string Variables { get; set; }


    }
}
