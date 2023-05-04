using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using WowSudoko.Logic;
using Xamarin.Forms;

namespace WowSudoko.ViewModels
{
    public class SudokoGameViewModel : BasePageModel, INavigationAware
    {
        public DelegateCommand<string> PlayButtonCommand { get; set; }
        public DelegateCommand<string> CheckBoardCommand { get; set; }
        public INavigationService _navigationService { get; set; }
        public bool isBusy { get; set; }
        public bool IsBusy
        {
            get
            {
                return isBusy;
            }
            set
            {
                isBusy = value;
                OnPropertyChanged(nameof(IsBusy));
            }
        }
        public List<string> EmptyBoxes { get; set; }
        public int[,] Matrix_9x9 { get; set; }
        public ObservableCollection<SmallBox> outerBox { get; set; }
        public ObservableCollection<SmallBox> OuterBox
        {
            get
            {
                return outerBox;
            }
            set
            {
                outerBox = value;
                OnPropertyChanged(nameof(OuterBox));
            }
        }
        public string time { get; set; }
        public string Time
        {
            get
            {
                return time;
            }
            set
            {
                time = value;
                OnPropertyChanged();
            }
        }
        public Level level { get; set; }
        public Level Level
        {
            get
            {
                return level;
            }
            set
            {
                level = value;
                OnPropertyChanged(nameof(Level));
            }
        }
        public async void OnNavigatedTo(INavigationParameters parameters)
        {
            try
            {
                IsBusy = true;
                await Task.Run(() => { MakeTheMagic(); });
                Level = new Level();
                var success = parameters.TryGetValue<Level>("title", out Level __level);
                Level = __level;
                await SetTheEmptyBoxes();
                StartTimer();
                IsBusy = false;
            }
            catch (Exception ex)
            {
            }

        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            //var item = parameters.GetValue<Level>("Level");
        }

        public SudokoGameViewModel()
        {

        }

        public SudokoGameViewModel(INavigationService navigationService) : this()
        {
            _navigationService = navigationService;
            PlayButtonCommand = new DelegateCommand<string>(PlayButtonCommandAsync);
            CheckBoardCommand = new DelegateCommand<string>(CheckBoardCommandAsync);
            //MessagingCenter.Send<SudokoGameViewModel>(this, "Hi");
        }

        public void CheckBoardCommandAsync(string obj)
        {
            Matrix_9x9 = new int[9, 9];
            var emptyBoxes = new List<string>();
            //foreach (var emptyBox in EmptyBoxes)
            //{
            //    var outerBoxIndex = int.Parse(emptyBox[0].ToString());
            //    var innerBoxIndex = int.Parse(emptyBox[1].ToString());
            //    if (string.IsNullOrEmpty(OuterBox[outerBoxIndex].InnerBox[innerBoxIndex].EnteredNumber))
            //    {
            //        OuterBox[outerBoxIndex].InnerBox[innerBoxIndex].BoxColor = Color.FromHex("#F24C4C");
            //    }
            //    else if (OuterBox[outerBoxIndex].InnerBox[innerBoxIndex].EnteredNumber == OuterBox[outerBoxIndex].InnerBox[innerBoxIndex].ActualNumber)
            //    {
            //        OuterBox[outerBoxIndex].InnerBox[innerBoxIndex].BoxColor = Color.FromHex("#B4FF9F");
            //    }
            //    else
            //    {
            //        OuterBox[outerBoxIndex].InnerBox[innerBoxIndex].BoxColor = Color.Orange;
            //    }
            //}

            for (int outerbox = 0; outerbox < 9; outerbox++)
            {
                for (int innerbox = 0; innerbox < 9; innerbox++)
                {
                    var number = OuterBox[outerbox].InnerBox[innerbox].EnteredNumber;
                    var row = OuterBox[outerbox].InnerBox[innerbox].RowIndex;
                    var col = OuterBox[outerbox].InnerBox[innerbox].ColumnIndex;
                    OuterBox[outerbox].InnerBox[innerbox].BoxColor = Color.FromHex("#FFA500");
                    Matrix_9x9[col, row] = int.Parse(string.IsNullOrEmpty(number) ? "0" : number);
                }
            }
            LogicMaker.displayBoard_ofChoice(Matrix_9x9);

            var errorList = new List<string>();

            var numberList = new List<int>();
            //Check for Existing Boxes
            for (int index = 0; index < 9; index++)
            {
                //check for numbers from 1-9 in each box
                if (OuterBox[index].InnerBox.Select(x => x.EnteredNumber).Distinct().Count() != 9)
                {
                    var repeats = OuterBox[index].InnerBox.GroupBy(i => i.EnteredNumber).Where(g => g.Count() > 1).Select(g => g.ToList().Where(x => x.EnteredNumber != ""));
                    foreach (var repeat in repeats.ToList())
                    {
                        foreach (var number in repeat)
                        {
                            errorList.Add(OuterBox[index].InnerBox[OuterBox[index].InnerBox.IndexOf(number)].ColumnIndex.ToString() +
                              OuterBox[index].InnerBox[OuterBox[index].InnerBox.IndexOf(number)].RowIndex.ToString());
                        }
                    }
                }

                //check for numbers in 1-9 in rows
                var row_errorList = Enumerable.Range(0, Matrix_9x9.GetLength(1))
                               .Select(x => Matrix_9x9[index, x])
                               .Select((t, i) => new { Index = i, Text = t })
                               .GroupBy(g => g.Text)
                               .Where(g => g.Count() > 1);

                //check for numbers from 1-9 in column
                var col_errorList = Enumerable.Range(0, Matrix_9x9.GetLength(1))
                               .Select(x => Matrix_9x9[x, index])
                               .Select((t, i) => new { Index = i, Text = t })
                               .GroupBy(g => g.Text)
                               .Where(g => g.Count() > 1);

                foreach (var error in row_errorList)
                {
                    if (error.Key != 0)
                    {
                        foreach (var error_sub in error)
                            errorList.Add(index.ToString() + error_sub.Index.ToString());
                    }
                }

                foreach (var error in col_errorList)
                {
                    if (error.Key != 0)
                    {
                        foreach (var error_sub in error)
                            errorList.Add(error_sub.Index.ToString() + index.ToString());
                    }
                }
            }
            //Check for empty boxes

            foreach (var errorBox in errorList)
            {
                //var k = Enumerable.Range(0, 9).Select(x => OuterBox[x]).Where(y=>y.InnerBox.Where(x=>x.ColumnIndex==errorBox[0] && x.RowIndex==errorBox[1]).FirstOrDefault());
                for (int index = 0; index < 9; index++)
                {
                    foreach (var box in OuterBox[index].InnerBox)
                    {
                        if (box.RowIndex.ToString() == errorBox[1].ToString() && box.ColumnIndex.ToString() == errorBox[0].ToString())
                        {
                            box.BoxColor = Color.Red;
                        }
                        else if (box.EnteredNumber == "")
                        {
                            emptyBoxes.Add(box.ColumnIndex.ToString()+box.RowIndex.ToString());
                            box.BoxColor = Color.Purple;
                        }
                    }
                }
            }

        }

        private void MakeTheMagic()
        {
            var theBoard_In_9X9 = LogicMaker.Sudoko;
            OuterBox = new ObservableCollection<SmallBox>();
            int initial_left = 1;
            int initial_right = 1;
            var lefty = initial_right;
            var righty = initial_left;
            for (int i = 1; i <= 9; i++)
            {
                var smallBox = new SmallBox();
                smallBox.InnerBox = new ObservableCollection<Numbers>();
                for (int innerCount = 1; innerCount <= 9; innerCount++)
                {
                    var boxNumber = theBoard_In_9X9[lefty - 1, righty - 1].ToString();
                    smallBox.InnerBox.Add(new Numbers() { ActualNumber = boxNumber, EnteredNumber = boxNumber, ColumnIndex = lefty - 1, RowIndex = righty - 1 });
                    if (innerCount % 3 == 0 && innerCount != 9)
                    {
                        lefty = lefty + 1;
                        righty = righty - 2;
                    }
                    else
                    {
                        righty = righty + 1;
                    }
                }
                OuterBox.Add(smallBox);
                if (lefty == 9 && righty == 9)
                    break;
                if (i % 3 == 0)
                {
                    lefty = lefty + 1;
                    righty = 1;
                }
                else
                {
                    lefty = lefty - 2;
                }
            }
        }

        private async Task SetTheEmptyBoxes()
        {
            try
            {
                int Level_Int = 0;
                EmptyBoxes = new List<string>();
                switch (Level.LevelType)
                {
                    case "EASY":
                        Level_Int = 20;
                        break;
                    case "MEDIUM":
                        Level_Int = 30;
                        break;
                    case "HARD":
                        Level_Int = 41;
                        break;
                    default:
                        Level_Int = 20;
                        break;
                }

                var random = new Random();
                await Task.Run(() =>
                {
                    for (int i = 0; i < Level_Int; i++)
                    {
                        //Select one among 9 boxes
                        var OuterBoxIndex = random.Next(0, 9);
                        var InnerBoxIndex = random.Next(0, 9);
                        if (!OuterBox[OuterBoxIndex].InnerBox[InnerBoxIndex].IsNumberVisible)
                        {
                            OuterBox[OuterBoxIndex].InnerBox[InnerBoxIndex].IsNumberVisible = !OuterBox[OuterBoxIndex].InnerBox[InnerBoxIndex].IsNumberVisible;
                            OuterBox[OuterBoxIndex].InnerBox[InnerBoxIndex].EnteredNumber = string.Empty;
                            EmptyBoxes.Add(OuterBoxIndex.ToString() + InnerBoxIndex.ToString());
                        }
                        else
                        { i--; }
                    }
                });

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void StartTimer()
        {
            Task.Run(() =>
            {
                var startTime = DateTime.Now;
                Device.StartTimer(TimeSpan.FromSeconds(1), () =>
                {
                    // Round duration and get rid of milliseconds.
                    TimeSpan timeSpan = (DateTime.Now - startTime) + TimeSpan.FromSeconds(0.5);
                    timeSpan = new TimeSpan(timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
                    Time = timeSpan.ToString("t");
                    return true;
                });
            });

        }

        public void PlayButtonCommandAsync(string patameter)
        {
            IsBusy = true;
            _navigationService.NavigateAsync("MicroAnimations");
            IsBusy = false;
        }
    }

    public class SmallBox : BasePageModel
    {
        public ObservableCollection<Numbers> innerBox { get; set; }
        public ObservableCollection<Numbers> InnerBox
        {
            get
            {
                return innerBox;
            }
            set
            {
                innerBox = value;
                OnPropertyChanged("InnerBox");
            }
        }
    }

    public class Numbers : BasePageModel
    {
        public string ActualNumber { get; set; }
        public int ColumnIndex { get; set; }
        public int RowIndex { get; set; }
        public string enteredNumber { get; set; }
        public string EnteredNumber
        {
            get
            {
                return enteredNumber;
            }
            set
            {
                enteredNumber = value;
                OnPropertyChanged(nameof(EnteredNumber));
            }
        }
        public Color boxColor { get; set; } = Color.FromHex("#FFA500");
        public Color BoxColor
        {
            get
            {
                return boxColor;
            }
            set
            {
                boxColor = value;
                OnPropertyChanged(nameof(BoxColor));
            }
        }
        private bool isNumberVisible { get; set; }
        public bool IsNumberVisible
        {
            get
            {
                return isNumberVisible;
            }
            set
            {
                isNumberVisible = value;
                OnPropertyChanged(nameof(IsNumberVisible));
            }
        }
    }
}
