using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SnakeGame.Models
{
    class HighScore
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Score { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}
