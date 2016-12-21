using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TvApi_Lab.DAL
{
    public class TvApiContext : DbContext
    {
        public TvApiContext() 
            : base("tvApiDb")
        {

        }

        public DbSet<Movie> Movies { get; set; }
    }
}