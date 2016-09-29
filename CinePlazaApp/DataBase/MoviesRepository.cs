using CinePlazaApp.Model;
using SQLite.Net.Async;
using SQLiteNetExtensionsAsync.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinePlazaApp.functions
{
    public class MoviesRepository
    {
        SQLiteAsyncConnection conn;

        public MoviesRepository(DbConnection oIDbConnection)
        {
            conn = oIDbConnection.GetAsyncConnection();
        }

        public async Task InsertMoviesAsync(Movies movies)
        {
            foreach (var item in movies.movies)
            {
                await conn.InsertOrReplaceWithChildrenAsync(item, recursive: true);
            }
            
            await conn.InsertOrReplaceWithChildrenAsync(movies,recursive:true);
        }

        public async Task InsertMoviesAsync(Movie movies)
        {
            await conn.InsertOrReplaceWithChildrenAsync(movies, recursive: true);
            await conn.InsertOrReplaceWithChildrenAsync(movies, recursive: true);
        }

        public async Task UpdateMoviesAsync(Movies movies)
        {
            await conn.UpdateWithChildrenAsync(movies);
        }

        public async Task DeleteMoviesAsync(Movies movies)
        {
            await conn.DeleteAsync(movies);
        }

        public async Task<List<Movies>> SelectAllMoviesAsync()
        {
            
            return await conn.GetAllWithChildrenAsync<Movies>(recursive: true);
        }

        public async Task<List<MoviesMovie>> SelectAllMoviesMovieAsync()
        {

            return await conn.GetAllWithChildrenAsync<MoviesMovie>(recursive: true);
        }

        public async Task<List<Movies>> SelectMoviesAsync(string query)
        {
            return await conn.QueryAsync<Movies>(query);
        }
    }
}
