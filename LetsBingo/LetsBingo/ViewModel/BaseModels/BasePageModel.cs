using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace LetsBingo.ViewModel.BaseModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertychanged = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertychanged));
        }

    }

}

