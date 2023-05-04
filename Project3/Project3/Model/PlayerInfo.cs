using System;
using SQLite;

namespace Project3.Model
{
    public class PlayerInfo
    {
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }
        public string PlayerName { get; set; }
        [MaxLength(10)]
        public string PlayerId { get; set; }
    }
}
