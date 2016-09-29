using System.IO;
using System.Threading.Tasks;
using SQLite.Net.Async;
using System;
using SQLite.Net;
using System.Data;
using SQLite.Net.Platform.WinRT;
using CinePlazaApp.Model;

namespace CinePlazaApp.functions
{
    public class DbConnection
    {
        string dbPath;
        SQLiteAsyncConnection conn;

        public DbConnection()
        {
            dbPath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "cineplazzaapp.sqlite");

            var connectionFactory = new Func<SQLiteConnectionWithLock>(() => new SQLiteConnectionWithLock(new SQLitePlatformWinRT(), new SQLiteConnectionString(dbPath, storeDateTimeAsTicks: false)));
            conn = new SQLiteAsyncConnection(connectionFactory);
        }

        public async Task InitializeDatabase()
        {
            await conn.CreateTableAsync<Movies>();
            await conn.CreateTableAsync<Movie>();
            await conn.CreateTableAsync<MoviesMovie>();
        }

        public SQLiteAsyncConnection GetAsyncConnection()
        {
            return conn;
        }

    }
}
    