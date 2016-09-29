using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace CinePlazaApp.Model
{
    [Table("movies")]
    public class Movies
    {
        [PrimaryKey,AutoIncrement]
        public long id { get; set; }

        public int cod { get; set; }
        public String week { get; set; }

        [ManyToMany(typeof(MoviesMovie),CascadeOperations =CascadeOperation.All)]
        public List<Movie> movies { get; set; }
       
        public Movies() { }
    }
}
