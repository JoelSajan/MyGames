using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using WowSudoko.Model;

namespace WowSudoko.Managers
{
    public class SQLHelperManager
    {
        private readonly SQLiteAsyncConnection db;
        public SQLHelperManager(string dbpath)
        {
            db = new SQLiteAsyncConnection(dbpath);
            db.CreateTableAsync<SudokoSqlModel>();
        }

        public async Task<int> AddPlayer(SudokoSqlModel sudokoSqlModel)
        {
            return await db.InsertAsync(sudokoSqlModel);
        }

        public async Task<List<SudokoSqlModel>> GetAllPreviousPlayers()
        {
            return await db.Table<SudokoSqlModel>().ToListAsync();
        }

        public async Task<int> UpdatePlayer(SudokoSqlModel sudokoSqlModel)
        {
            return await db.UpdateAsync(sudokoSqlModel);
        }

        public async Task<int> DeletePlayer(SudokoSqlModel sudokoSqlModel)
        {
            return await db.DeleteAsync(sudokoSqlModel);
        }
    }
}
