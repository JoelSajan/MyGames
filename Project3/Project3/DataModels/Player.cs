using System;
using System.ComponentModel;

namespace Project3.DataModels
{
    public class Player
    {
        public string playername;
        public Player(string name)
        {
            playername = name;
        }

        public string PlayerName
        {
            get
            {
                return playername;
            }
            set
            {
                playername = value;
                this.RaisedPropertyChanged("PlayerName");
            }
        }

        public event PropertyChangedEventHandler propertyChanged;

        private void RaisedPropertyChanged(string property)
        {
            propertyChanged(this,new PropertyChangedEventArgs(property));
        }
    }
}
