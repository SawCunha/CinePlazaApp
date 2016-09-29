using CinePlazaApp.functions;
using CinePlazaApp.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinePlazaApp.DataBase
{
    public class DbFunctions
    {

        private static async Task<MoviesRepository> obtem_conexao_bd()
        {
            DbConnection db = new DbConnection();
            await db.InitializeDatabase();
            MoviesRepository mr = new MoviesRepository(db);
            return mr;
        }

        public static async Task<Movies> obtem_movies()
        {
            MoviesRepository mr = await obtem_conexao_bd();
            try
            {
                return (await mr.SelectAllMoviesAsync())[0];
            }
            catch (Exception e)
            {
                Debug.Write(e.ToString());
                return null;
            }

        }

        public static async void salva_movies(Movies movies)
        {
            MoviesRepository mr = await obtem_conexao_bd();

            bool ok = false;

            foreach (var item in (await mr.SelectAllMoviesAsync()))
            {
                if (item.week.Equals(movies.week))
                    ok = true;
                Debug.Write(item.cod+"\n\n");
            }


            if (!ok)
            {
                Debug.Write("SAW\n");
                await mr.InsertMoviesAsync(movies);
            }
            else { Debug.Write("LOOL\n"); }

        }
    }
}
