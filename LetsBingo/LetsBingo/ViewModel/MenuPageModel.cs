using System;
using System.Windows.Input;
using LetsBingo.Managers;
using LetsBingo.ViewModel.BaseModels;
using LetsBingo.Views;
using Xamarin.Forms;

namespace LetsBingo.ViewModel
{
    public class MenuPageModel : BaseViewModel
    {
        public ICommand GameButtonClicked { get; set; }
        public MenuPageModel()
        {
            GameButtonClicked = new Command(GameStartAction);
        }

        private async void GameStartAction()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new AutoGenerateBoardPage());
        }
    }
}

