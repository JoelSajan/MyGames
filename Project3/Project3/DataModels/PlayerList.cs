using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Project3.DataModels
{
    public class PlayerList:ObservableCollection<Player> ,INotifyPropertyChanged
    {
        public PlayerList()
        {
            foreach(var player in PlayerNames)
            {
                var gamer = new Player(player);
                this.Add(gamer);
            }
        }

    string[] PlayerNames = new string[] {
    "Kyle",
    "Gina",
    "Irene",
    "Katie",
    "Michael",
    "Oscar",
    "Ralph",
    "Torrey",
    "William",
    "Bill",
    "Daniel",
    "Frank",
    "Brenda",
    "Danielle",
    "Fiona",
    "Howard",
    "Jack",
    "Larry",
    };
    }
}
