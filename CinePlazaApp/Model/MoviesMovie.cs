using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinePlazaApp.Model
{
    [Table("moviesmovie")]
    public class MoviesMovie
    {
        [ForeignKey(typeof(Movies))]
        public long id_movies { get; set; }

        [ForeignKey(typeof(Movie))]
        public long id_movie { get; set; }
    }
}
