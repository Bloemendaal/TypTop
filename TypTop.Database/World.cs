using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TypTop.Database
{
    public class World
    {
        [Key]
        public int WorldId { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public int Index { get; set; }

        [Required]
        public int Stars { get; set; }

        public string Background { get; set; }

    }
}
