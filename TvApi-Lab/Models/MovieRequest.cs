using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TvApi_Lab.Models
{
    public class MovieRequest
    {       
        [Required]
        public string Title { get; set; }
        
        public int Year { get; set; }      
    }
}