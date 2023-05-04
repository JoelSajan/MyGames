using System;
using SQLite;

namespace WowSudoko.Model
{
    public class SudokoSqlModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        public int GameScore { get; set; }
    }
}
