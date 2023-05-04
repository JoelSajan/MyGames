using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using LetsBingo.ViewModel.BaseModels;
using Xamarin.Forms;

namespace LetsBingo.ViewModel
{
    public class Numbers: BaseViewModel
    {
       public string number { get; set; }
        private Color _boxcolor { get; set; }
        public Color boxcolor { get { return _boxcolor; } set {if (value != null)

                { _boxcolor = value; OnPropertyChanged(); }


                else
                    _boxcolor = Color.White;
                OnPropertyChanged();
            } }

        
    }
}
