using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission4Assignment.Models
{
    public class MovieEntry //This gets and sets all the variables 
    {
        //This also has all the validation that the form asked for
        [Key]
        [Required]
        public int MovieId { get; set; }
        [Required]
        public int CategoryId { get; set; } 
        public Category Category { get; set; } //This builds the foreign key relationship with the Category Model that we also created
        [Required]
        public string Title { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Rating { get; set; }
        public Boolean Edited { get; set; }
        public string LentTo { get; set; }
        [MaxLength(25)]
        public string Notes { get; set; }

    }
}
