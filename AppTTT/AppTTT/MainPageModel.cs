using System;
using Xamarin.Forms;
using FreshMvvm;
using System.Windows.Input;
using PropertyChanged;
using System.Text;
using System.Collections;
using System.Collections.ObjectModel;
using System.Linq;
using AppTTT.Interface;
using SQLite;
using System.IO;

namespace AppTTT
{
    [AddINotifyPropertyChangedInterface]
    public class MainPageModel : FreshBasePageModel
    {
        public string Iteration1 { get; set; }
        public string Iteration2 { get; set; }
        public string Iteration3 { get; set; }
        public string Iteration4 { get; set; }
        public string Iteration5 { get; set; }
        public string Iteration6 { get; set; }
        public string Iteration7 { get; set; }
        public string Iteration8 { get; set; }
        public string Iteration9 { get; set; }
        private SQLiteAsyncConnection _connection;
        public IStorageService _storageService { get; set; }

        public int SampleFlag { get; set; }
        public int Clever_X { get; set; }
        public int Clever_O { get; set; }
        public string[] Board { get; set; }

        public ICommand Comand_Placer { get; set; }
        public bool AnyOneWon { get; private set; }
        public string Winner { get; private set; }
        public PlayerInfo PlayerInfo { get; set; }
        public MainPageModel(IStorageService storageService)
        {
            _storageService = storageService;
            Board = new string[9];
            SampleFlag = 1;
            Clever_X = 0;
            Clever_O = 0;
            Comand_Placer = new Command(Action);
            Iteration1 = Board[0];

            Iteration2 = Board[1];

            Iteration3 = Board[2];

            Iteration4 = Board[3];

            Iteration5 = Board[4];

            Iteration6 = Board[5];

            Iteration7 = Board[6];

            Iteration8 = Board[7];

            Iteration9 = Board[8];
            PlayerInfo = new PlayerInfo() { };
            CreateDBForGame<PlayerInfo>();
            PlayerInfoModelCreated();
        }

        private void PlayerInfoModelCreated()
        {
            PlayerInfo.PlayerName = "JustinCooper";
            PlayerInfo.PlayerUniqueID = "s9Q10F";
            PlayerInfo.GameStartTime = DateTime.Now.ToString();
        }

        private void CreateDBForGame<T>()
        {
            _connection =  _storageService.CreateTable();
        }

        public void Action(object Number)
        {
            _connection.ExecuteAsync($"INSERT INTO PlayerInfo (PlayerUniqueID,PlayerName,GameStartTime) VALUES ('{PlayerInfo.PlayerUniqueID}','{PlayerInfo.PlayerName}','{PlayerInfo.GameStartTime}')");
            string enteredNumber = (string)Number;
            int index = int.Parse(enteredNumber);
            Board[index] = "X";
            UpdateBoardInUI(Board);
            if (Board.All(x=>x?.Length>0))
            {
                AnyOneWon = true;
                Winner = "DRAW";
                return;
            }
            GeneralClass Game = new GeneralClass();
            Board=Game.BasicGameFunction(Board,out string winner);
            if(!Board.All(x=>x==null))
            {
                UpdateBoardInUI(Board);
            }
            else if(winner.Length>0)
            {
                AnyOneWon = true;
                Winner = winner.ToUpper() + " WINS!";
            }
            else if (Board.All(x => x?.Length > 0))
            {
                AnyOneWon = true;
                Winner = "DRAW";
            }
            
        }

        public void UpdateBoardInUI(string[] Board)
        {

            Iteration1 = Board[0];

            Iteration2 = Board[1];

            Iteration3 = Board[2];

            Iteration4 = Board[3];

            Iteration5 = Board[4];

            Iteration6 = Board[5];

            Iteration7 = Board[6];

            Iteration8 = Board[7];

            Iteration9 = Board[8];

        }
    }

}

