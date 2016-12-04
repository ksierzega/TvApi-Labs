using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TvApi_Lab.Models
{
    public class Movie
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Author { get; set; }
        public int Year { get; set; }
        public List<string> Comments { get; set; }
    }
}