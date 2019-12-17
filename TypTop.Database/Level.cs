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

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public int Index { get; set; }

        [Required]
        public string Variables { get; set; }

        [Required]
        public int RequiredLevelId { get; set; }

        public virtual Level RequiredLevel { get; set; }

    }
}
