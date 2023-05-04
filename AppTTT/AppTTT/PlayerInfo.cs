using SQLite;

namespace AppTTT
{
    public class PlayerInfo
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [NotNull]
        public string PlayerUniqueID { get; set; }
        public string PlayerName { get; set; }
        public string GameDate { get; set; }
        public int DidPlayerWon { get; set; }
        public string GameStartTime { get; set; }
        public string GameEndTime { get; set; }
    }
}