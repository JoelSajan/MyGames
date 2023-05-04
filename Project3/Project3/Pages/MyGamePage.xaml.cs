using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Project3.AudioManager;
using Project3.PageModels;
using Project3.Templates;
using Xamarin.Forms;
using Xamarin.Forms.StyleSheets;

namespace Project3.Pages
{
    public partial class MyGamePage : ContentPage
    {
        private int emptySquareRow = 3;
        public IAudioPlayerService audioplayer;
        private int emptySquareCol = 3;
        public double squareSize;
        public bool isShuffling;
        public int styleCount { get; set; } = 0;
        public static Box[,] boxs;
        public string winText = "congratulations";
        public bool needToNavigation;
        public int shuffleMin { get; set; } = 0;
        AbsoluteLayout absoluteLayout { get; set; }
        StackLayout stackLayout { get; set; }
        Label shiftCount { get; set; }
        Assembly assembly = typeof(MyGamePage).GetTypeInfo().Assembly;
        Button button { get; set; }
        Label timeLabel { get; set; }
        public MyGamePage()
        {
            InitializeComponent();
            audioplayer = DependencyService.Get<IAudioPlayerService>();
            audioplayer.Play("pop.mp3");
            //ControlTemplate = new ControlTemplate(typeof(HamburgerTemplate));
            boxs = new Box[4, 4];
            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    if (row == 3 && col == 3)
                    {
                        break;
                    }
                    boxs[row, col] = new Box((row * 4 + col + 1).ToString(), row * 4 + col + 1) { row = row, coloum = col };
                }
            }
            
            
            timeLabel = new Label
            {
                 Text="00:00:00",
                FontSize = 64,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                TextColor = Color.Accent
            };
            shiftCount = new Label
            {
                FontSize = 20,
                Text = shuffleMin.ToString(),
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                TextColor = Color.Accent
            };
            stackLayout = new StackLayout()
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            absoluteLayout = new AbsoluteLayout
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
            foreach (Box box in boxs)
            {
                if (box != null)
                    absoluteLayout.Children.Add(box);
            }
            button = new Button()
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                StyleClass = new List<string>() { "button" }
            };
            button.Pressed += OnChangeStyleButtonPressed;
            stackLayout.LayoutChanged += StackSizeChanged;
            this.LayoutChanged += BoxReordered;
            stackLayout.Children.Add(timeLabel);
            stackLayout.Children.Add(absoluteLayout);
            stackLayout.Children.Add(button);
            stackLayout.Padding = 0;
            Content = stackLayout;
            Stream stream = assembly.GetManifestResourceStream("Project3.Styles.ChosedStyles1.css");
            StreamReader Stylesheet = new System.IO.StreamReader(stream);
            Xamarin.Forms.StyleSheets.StyleSheet styleSheet = Xamarin.Forms.StyleSheets.StyleSheet.FromReader(Stylesheet);
            this.Resources.Add(styleSheet);
            //Win();
            Shuffle();
            stackLayout.Children.Add(shiftCount);
        }

        private void OnChangeStyleButtonPressed(object sender, EventArgs e)
        {
            //if (Application.Current.UserAppTheme == OSAppTheme.Light)
            //    Application.Current.UserAppTheme = OSAppTheme.Dark;
            //else
            //    Application.Current.UserAppTheme = OSAppTheme.Light;
            var pagemodel = (MyGamePageModel)this.BindingContext;
            button.Text = pagemodel._settingsService.MyGameTile = styleCount.ToString();
            styleCount++;
            if (styleCount > 3)
            {
                styleCount = 0;
            }
            Stream stream = assembly.GetManifestResourceStream("Project3.Styles.ChosedStyles" + styleCount + ".css");
            StreamReader Stylesheet = new System.IO.StreamReader(stream);
            Xamarin.Forms.StyleSheets.StyleSheet styleSheet = Xamarin.Forms.StyleSheets.StyleSheet.FromReader(Stylesheet);
            this.Resources.Add(styleSheet);
        }

        private async void Win()
        {
            foreach(View view in absoluteLayout.Children)
            {
                var box = (Box)view;
                await box.AnimateWinAsync(false);
            }
        }

        private void StackSizeChanged(object sender, EventArgs e)
        {

            double width = stackLayout.Width;
            double height = stackLayout.Height;

            if (width <= 0 || height <= 0)
                return;

            // Orient StackLayout based on portrait/landscape mode.
            stackLayout.Orientation = (width < height) ? StackOrientation.Vertical :
                StackOrientation.Horizontal;

            // Calculate square size and position based on stack size.
            squareSize = Math.Min(height, width);
            squareSize = squareSize / 6;
        }

        private void BoxReordered(object obj, EventArgs e)
        {
            int count = 0;
            using (UserDialogs.Instance.Loading())
            {
                foreach (View view in absoluteLayout.Children)
                {
                    var square = (Box)view;
                    var tapped = new TapGestureRecognizer();
                    square.winText = winText[count].ToString().ToUpper().Trim();
                    count++;
                    tapped.Tapped += BoxTappedOn;
                    square.GestureRecognizers.Add(tapped);
                    AbsoluteLayout.SetLayoutBounds(square, new Rectangle(square.coloum * squareSize, square.row * squareSize, squareSize, squareSize));
                }
            }
        }

        private async void Shuffle()
        {
            isShuffling = true;
            var random = new Random();
            Box box = new Box();
            int rowOrcol;
            int lurd;
            int previousRow = 3;
            int previousCol = 3;
            bool shifted;
            for (int i = 0; i < 200; ++i)
            {
                if(needToNavigation)
                    break;
                do
                {
                    rowOrcol = random.Next(0, 2);
                    lurd = random.Next(0, 2);
                    shifted = true;
                    switch (rowOrcol)
                    {
                        case 0:
                            if (!(emptySquareRow - 1 < 0) && previousRow != emptySquareRow - 1 && lurd == 0)
                            {
                                //Left
                                box = ShiftToEmpty(emptySquareRow - 1, emptySquareCol);
                                previousRow = box.row;
                                previousCol = box.coloum;
                                shiftCount.Text =(shuffleMin++).ToString();
                                shifted = false;
                            }
                            else if (!(emptySquareRow + 1 > 3) && previousRow != emptySquareRow + 1)
                            {
                                //Right
                                box = ShiftToEmpty(emptySquareRow + 1, emptySquareCol);
                                previousRow = box.row;
                                previousCol = box.coloum;
                                shiftCount.Text = (shuffleMin++).ToString();
                                shifted = false;
                            }
                            break;
                        case 1:
                            if (!(emptySquareCol - 1 < 0) && previousCol != emptySquareCol - 1 && lurd == 0)
                            {
                                //Up
                                box = ShiftToEmpty(emptySquareRow, emptySquareCol - 1, 1);
                                previousRow = box.row;
                                previousCol = box.coloum;
                                shiftCount.Text = (shuffleMin++).ToString();
                                shifted = false;
                            }
                            else if (!(emptySquareCol + 1 > 3) && previousCol != emptySquareCol + 1)
                            {
                                //Down
                                box = ShiftToEmpty(emptySquareRow, emptySquareCol + 1, 1);
                                previousRow = box.row;
                                previousCol = box.coloum;
                                shiftCount.Text =(shuffleMin++).ToString();
                                shifted = false;
                            }
                            break;
                        default:
                            shifted = false;
                            break;
                    }
                }
                while (shifted);
                await AnimateBoxes(box, squareSize, 60);
            }
            isShuffling = false;

            var startTime = DateTime.Now;
            Device.StartTimer(TimeSpan.FromSeconds(1), () => {
                // Round duration and get rid of milliseconds.
                TimeSpan timeSpan = (DateTime.Now - startTime) + TimeSpan.FromSeconds(0.5);
                timeSpan = new TimeSpan(timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
                timeLabel.Text = timeSpan.ToString("t");

                // Display the duration.
                return !isShuffling;
            });
        }

        private async void BoxTappedOn(object sender, EventArgs e)
        {
            if (isShuffling == true)
                return;
            var box = (Box)sender;
            if (emptySquareCol == box.coloum || emptySquareRow == box.row)
            {
                if (emptySquareRow == box.row)
                    await RearrangeBoxRow(box);
                else
                    await RearrangeBoxCol(box);
            }
            if (emptySquareCol == 3 && emptySquareRow == 3)
            {
                if (DidYouWin())
                    Shuffle();
            }
        }

        private bool DidYouWin()
        {
            int count = 1;
            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    if (row == 3 && col == 3)
                    {
                        break;
                    }
                    if (GetBoxFromBoxes(row, col).index != count)
                    {
                        return false;
                    }
                    count++;
                }
            }
            return true;
        }

        private async Task RearrangeBoxRow(Box box)
        {
            if (Math.Abs(emptySquareCol - box.coloum) == 1)
            {
                var empty = box.coloum;
                box.coloum = emptySquareCol;
                emptySquareCol = empty;
                await AnimateBoxes(box, squareSize);
            }
            else
            {
                if (emptySquareCol > box.coloum)
                {
                    var emptybox = emptySquareCol;
                    for (int i = box.coloum; i < emptybox; i++)
                    {
                        box = ShiftToEmpty(box.row, emptySquareCol - 1, 1);
                        await AnimateBoxes(box, squareSize);
                    }
                }
                else
                {
                    var emptybox = emptySquareCol;
                    for (int i = box.coloum - 1; i >= emptybox; i--)
                    {
                        box = ShiftToEmpty(box.row, emptySquareCol + 1, 1);
                        await AnimateBoxes(box, squareSize);
                    }
                }
            }
        }

        private async Task RearrangeBoxCol(Box box)
        {
            if (Math.Abs(emptySquareRow - box.row) == 1)
            {
                var empty = box.row;
                box.row = emptySquareRow;
                emptySquareRow = empty;
                await AnimateBoxes(box, squareSize);
            }
            else
            {
                var emptybox = emptySquareRow;
                if (emptySquareRow > box.row)
                {
                    for (int i = box.row; i < emptybox; i++)
                    {
                        box = ShiftToEmpty(emptySquareRow - 1, box.coloum);
                        await AnimateBoxes(box, squareSize);
                    }
                }
                else
                {
                    for (int i = box.row - 1; i >= emptybox; i--)
                    {
                        box = ShiftToEmpty(emptySquareRow + 1, box.coloum);
                        await AnimateBoxes(box, squareSize);
                    }
                }
            }
        }

        private async Task AnimateBoxes(Box box, double squareSize, uint time = 100)
        {
            //if (shuffleMin != 0 && !isShuffling)
            //    shiftCount.Text = (shuffleMin--).ToString();
            audioplayer.Play();
            await box.LayoutTo(new Rectangle(box.coloum * squareSize, box.row * squareSize, squareSize, squareSize), time, Easing.Linear);
        }

        private Box GetBoxFromBoxes(int row, int col)
        {
            Box box = new Box();
            foreach (View view in absoluteLayout.Children)
            {
                box = (Box)view;
                if (box.row == row && box.coloum == col)
                    break;
            }
            return box ?? new Box();
        }

        private Box ShiftToEmpty(int row, int col, int isRow = 0)
        {
            Box box;
            if (isRow == 0)
            {
                box = GetBoxFromBoxes(row, col);
                box.row = emptySquareRow;
                emptySquareRow = row;
            }
            else
            {
                box = GetBoxFromBoxes(row, col);
                box.coloum = emptySquareCol;
                emptySquareCol = col;
            }
            return box;
        }


        private void LayoutMovedBack()
        {
            foreach (View view in absoluteLayout.Children)
            {
                var square = (Box)view;
                var tapped = new TapGestureRecognizer();
                tapped.Tapped += BoxTappedOn;
                square.GestureRecognizers.Add(tapped);
                view.LayoutTo(new Rectangle(square.row * squareSize, square.coloum * squareSize, squareSize, squareSize));
            }
        }
    }
}
