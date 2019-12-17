using System;
using System.ComponentModel.DataAnnotations;

namespace TypTop.Database
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Salt { get; set; }
        public DateTime LastLogin { get; set; }
        [Required]
        public bool Teacher { get; set; }
        public int TeacherId { get; set; }
    }
}