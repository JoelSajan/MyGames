using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Prism.Mvvm;

namespace WowSudoko.ViewModels
{
    public class BasePageModel : BindableBase,INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertychanged = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertychanged));
        }

    }
}
