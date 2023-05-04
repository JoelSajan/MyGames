using System;
using System.IO;
using AppTTT.Interface;
using SQLite;

namespace AppTTT.Droid
{
    public class StorageService : IStorageService
    {
        public string PlayerInfoLocation => Path.Combine(Path.Combine(GetFolderPath(), "Player"));
        private SQLiteAsyncConnection _connection;

        public string GetFolderPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        }

        public SQLiteAsyncConnection CreateTable()
        {
            if (!Directory.Exists(PlayerInfoLocation))
            {
                Directory.CreateDirectory(PlayerInfoLocation);
            }
            _connection = new SQLiteAsyncConnection(Path.Combine(PlayerInfoLocation,"PlayerInfo.db"));

            _connection.CreateTableAsync<PlayerInfo>(CreateFlags.None).ConfigureAwait(false);
            return _connection;
        }
    }
}
