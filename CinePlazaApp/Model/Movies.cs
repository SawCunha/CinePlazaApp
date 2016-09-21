using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinePlazaApp.Model
{
    class Movies
    {

        public int cod { get; set; }
        public String week { get; set; }
        public List<Movie> movies { get; set; }

        public Movies() { }
    }
}
