using System;
using System.Collections.ObjectModel;
using FreshMvvm;
using Project3.DataModels;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Project3.PageModels
{
    public class CreditsPageModel : FreshBasePageModel
    {
        public ObservableCollection<Box> Boxes { get; set; }
        public CreditsPageModel()
        {
            Boxes = new ObservableCollection<Box>();
            GenerateBoard();
        }

        private void GenerateBoard()
        {
            var random =new  Random();
            for(int i=0;i<15;i++)
            {
                Boxes.Add(new Box { number=random.Next(0, 100).ToString(),boxcolor = Color.Orange});

            }
        }
    }
}

