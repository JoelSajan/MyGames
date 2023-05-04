using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using WowSudoko.Utilities;
using Xamarin.Forms;

namespace WowSudoko.ViewModels
{
    public class SudokoMenuViewModel : BasePageModel
    {
        public DelegateCommand<string> PlayButtonCommand { get; set; }
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
        public string BarcodeValue { get; set; }
        public ObservableCollection<Level> LevelList { get; set; }
        public ICommand OnLevelSelectedCommand { get; set; }

        public SudokoMenuViewModel()
        {
            OnLevelSelectedCommand = new Command(OnLevelSelectedCommandAsync);
            LevelList = new ObservableCollection<Level>();
            LevelList.Add(new Level() { LevelType = "EASY", IsSelected = true }) ;
            LevelList.Add(new Level() { LevelType = "MEDIUM", IsSelected = false });
            LevelList.Add(new Level() { LevelType = "HARD", IsSelected = false });
        }

        private void OnLevelSelectedCommandAsync(object obj)
        {
            var level = (Level)obj;
            foreach (var level_list in LevelList)
            {
                if (level_list == level)
                {
                    level_list.IsSelected = true;
                }
                else
                {
                    level_list.IsSelected = false;
                }
            }
        }

        public SudokoMenuViewModel(INavigationService navigationService):this()
        {
            _navigationService = navigationService;
            PlayButtonCommand = new DelegateCommand<string>(async (a)=> { await PlayButtonCommandAsync(a); }).ObservesProperty(()=>IsBusy);
            MessagingCenter.Subscribe<SudokoGameViewModel>(this, "Hi", (sender) =>
            {
                IsBusy = true;
            });

            var x = CheckForBoardApi.ListAllProducts();

        }

        public async Task PlayButtonCommandAsync(string patameter)
        {
            if (IsBusy)
                return;
            IsBusy = true;
            var navigationParams = new NavigationParameters();
            navigationParams.Add("title", LevelList.FirstOrDefault(x => x.isSelected));
            await _navigationService.NavigateAsync("SudokoGameView", navigationParams);
            IsBusy = false;
        }

    }

    public class Level : BasePageModel
    {
      public string LevelType { get; set; }
      public bool isSelected { get; set; }
      public bool IsSelected
        {
            get
            {
                return isSelected;
            }
            set
            {
                isSelected = value;
                OnPropertyChanged("IsSelected");
            }
        }
    }
}
