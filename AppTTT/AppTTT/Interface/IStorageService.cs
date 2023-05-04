using System;
using SQLite;

namespace AppTTT.Interface
{
    public interface IStorageService
    {
        string GetFolderPath();
        SQLiteAsyncConnection CreateTable();
    }
}
