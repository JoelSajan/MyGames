using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using LetsBingo.Interface;
using LetsBingo.ViewModel.BaseModels;
using LetsBingo.Views;
using Xamarin.Forms;

namespace LetsBingo.ViewModel
{
    public class AutoGenerateBoardPageModel : BaseViewModel
    {
        public int[] Board { get; set; }
        public int Number { get; set; }
        public string Choice { get; set; }
        public Color BoxColor { get; set; }
        public ObservableCollection<Numbers> List { get; set; }
        public ICommand StartButtonClicked { get; set; }
        public ICommand SelectedBox { get; set; }
        private  Random Random { get; set; }
        public RegisterLog registerLog { get; set; }
        public int index { get; set; }
        public string Computer { get; set; }
        private string player { get; set; }
        public string Player { get { return player; } set { player = value;OnPropertyChanged(); } }
        public IPageService _pageService;

        public AutoGenerateBoardPageModel(IPageService pageService)
        {
            _pageService = pageService;
            registerLog = new RegisterLog();
            registerLog.SelectedBoxes = new string[25];
            List = new ObservableCollection<Numbers>();
            SelectedBox = new Command(BoxSelectedAction);
            Random = new Random();
            Choice = "Select your first box";
            Board = new int[30];
            Computer = "BINGO";
            Player = "BINGO";
            GenerateBoard();
            index = 0;
        }

        

        private  void BoxSelectedAction(object box)
        {
            var Box = box as Numbers;

            if (Box.boxcolor == Color.Orange || Box.boxcolor == Color.Violet)
            {
                Choice = "Box Already Selected";
                
            }

            else
            {
                Box.boxcolor = Color.Orange;
                registerLog.SelectedBoxes[index] = Box.number.ToString();
                index++;
                ComputersGame();
                
            }

        }
        public void LineCheck()
        {
            //int rowcount = 0;
            //int coloumncount = 0;
            //int i=0;
            //Color columncolor=Color.White;
            //while (rowcount < 25)
            //{
            //    for (coloumncount= rowcount; coloumncount < 5; coloumncount++,i++)
            //    {
            //        if (i == 0)
            //        {
            //            columncolor = List[coloumncount].boxcolor;
            //            continue;
            //        }
            //        if (List[coloumncount].boxcolor == Color.White)
            //        {
            //            break;
            //        }
            //        if (i == 4 && columncolor == List[4].boxcolor) { BingoLine(rowcount,"Row"); }

            //    }
            //    rowcount=rowcount+5;
            //}
            //rowcount = 0;
            //coloumncount = 0;
            //i = 0;
            //while (coloumncount < 5)
            //{
            //    for (rowcount = coloumncount; i < 5; rowcount=rowcount+5,i++)
            //    {
            //        if (i == 0)
            //        {
            //            columncolor = List[rowcount].boxcolor;
            //            continue;
            //        }
            //        if (List[rowcount].boxcolor == Color.White)
            //        {
            //            break;
            //        }
            //        if (i == 4 && columncolor == List[4].boxcolor) { BingoLine(coloumncount, "Column"); }

            //    }
            //    coloumncount = coloumncount ++;
            //}
            for(int j=0;j<25;j=j+5)
            if (List[j].boxcolor != Color.White && List[j+1].boxcolor != Color.White &&
                    List[j + 2].boxcolor != Color.White && List[j + 3].boxcolor != Color.White && List[j + 4].boxcolor != Color.White)
                   
            {
                    int greencheck=0;
                    if (List[j].boxcolor == Color.Green && List[j + 1].boxcolor == Color.Green &&
                    List[j + 2].boxcolor == Color.Green && List[j + 3].boxcolor == Color.Green && List[j + 4].boxcolor == Color.Green)
                        greencheck = 1;
                    else
                    {
                        List[j].boxcolor = List[j + 1].boxcolor = List[j + 2].boxcolor = List[j + 3].boxcolor = List[j + 4].boxcolor = Color.Green;
                        if (!string.IsNullOrEmpty(Player))
                            Player = Player.Remove(Player.Length - 1, 1);
                    }
            }

            for (int j = 0; j < 5; j++)
                if (List[j].boxcolor != Color.White && List[j + 5].boxcolor != Color.White && List[j + 10].boxcolor != Color.White && List[j + 15].boxcolor != Color.White && List[j + 20].boxcolor != Color.White)
                    
                   
            {
                    int greencheck = 0;
                    if (List[j].boxcolor == Color.Green && List[j + 5].boxcolor == Color.Green && List[j + 10].boxcolor == Color.Green && List[j + 15].boxcolor == Color.Green && List[j + 20].boxcolor == Color.Green)
                        greencheck = 1;
                    else
                    {
                        List[j].boxcolor = List[j + 5].boxcolor = List[j + 10].boxcolor = List[j + 15].boxcolor = List[j + 20].boxcolor = Color.Green;
                        if (!string.IsNullOrEmpty(Player))
                            Player = Player.Remove(Player.Length - 1, 1);
                    }
            }

            int index = 0;
                if (List[index].boxcolor != Color.White && List[index+6].boxcolor != Color.White && List[index + 12].boxcolor != Color.White && List[index + 18].boxcolor != Color.White && List[index + 24].boxcolor != Color.White)
            {
                int greencheck = 0;
                if (List[index].boxcolor == Color.Green && List[index + 6].boxcolor == Color.Green && List[index + 12].boxcolor == Color.Green && List[index + 18].boxcolor == Color.Green && List[index + 24].boxcolor == Color.Green)
                    greencheck = 1;
                else
                {
                    List[index].boxcolor = List[index + 6].boxcolor = List[index + 12].boxcolor = List[index + 18].boxcolor = List[index + 24].boxcolor = Color.Green;
                    if (!string.IsNullOrEmpty(Player))
                        Player = Player.Remove(Player.Length - 1, 1);
                }
            }
            index = 4;
                if (List[index].boxcolor != Color.White && List[index + 4].boxcolor != Color.White && List[index + 8].boxcolor != Color.White && List[index + 12].boxcolor != Color.White && List[index + 16].boxcolor != Color.White)
                {
                int greencheck = 0;
                if (List[index].boxcolor == Color.Green && List[index + 4].boxcolor == Color.Green && List[index + 8].boxcolor == Color.Green && List[index + 12].boxcolor == Color.Green && List[index + 16].boxcolor == Color.Green)
                    greencheck = 1;
                else
                {
                    List[index].boxcolor = List[index + 4].boxcolor = List[index + 8].boxcolor = List[index + 12].boxcolor = List[index + 16].boxcolor = Color.Green;
                    if(!string.IsNullOrEmpty(Player))
                       Player = Player.Remove(Player.Length - 1, 1);
                }
            }
            if (Player == "")
            {
                Player = "You Won Buddy";
                
                _pageService.PushAsync(new MenuPage());
            }
        }

        //public void BingoLine()
        //{
        //    linecount = linecount / 5;
        //    if (where == "Row") { for (int i = 0; i < 5; i++) { List[i].boxcolor = Color.Blue; } Player.Remove(Player.Length - 1, 1); }
        //    if (where == "Coloumn") { for (int i = 0; i < 5; i++) List[i].boxcolor = Color.Blue; }

        //}
        public void ComputersGame()
        {
            
            do {
                int flag = 0;
                var Number = Random.Next(1, 26).ToString();
                if (Number.Length < 2)
                { Number = "0" + Number; }
                foreach (string number in registerLog.SelectedBoxes)
                {
                        if (number == Number.ToString())
                    { flag = 1;
                        break;
                    }
                }
                if (flag != 1)
                {
                   Numbers Box= List.FirstOrDefault(x=>x.number== Number.ToString());
                    Box.boxcolor = Color.Violet;
                    Choice = "Computer Chooses "+ Number+", Your Choice";
                    registerLog.SelectedBoxes[index] = Number.ToString();
                    index++;
                    break; }
            } while (true);
            LineCheck();

        }


        public void GenerateBoard()
        {
            for (int i = 1; i < 26; i++)
            {
                while (true)
                {
                    int flag = 0;
                    Number = Random.Next(1, 26);
                    foreach ( int j in Board)
                        if (j == Number)
                        { flag = 1; break; }
                    if (flag == 1)
                        continue;
                    else
                        break;
                }
                Board[i] = Number;
                if (Number.ToString().Length < 2)
                    List.Add(new Numbers { number = "0" + Number.ToString(), boxcolor = Color.White }) ;
                 else
                    List.Add(new Numbers { number = Number.ToString(), boxcolor = Color.White });
                Console.WriteLine(Number);
                 ;

            }
        }

    }
}

