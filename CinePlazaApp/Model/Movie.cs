using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace CinePlazaApp.Model
{
    [Table("movie")]
    public class Movie
    {
        [PrimaryKey, AutoIncrement]
        public long id { get; set; }

        public String name { get; set; }
        public String cover { get; set; }
        public String trailer { get; set; }
        public String genre { get; set; }
        public String duration { get; set; }
        public String classification { get; set; }
        public String exibition { get; set; }

        public Movie() { }
    }
}
