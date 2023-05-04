using System;
using PropertyChanged;

namespace Project3.DataModels
{
    [AddINotifyPropertyChangedInterface]
    public class AnimationModel
    {
        public string H { get; set; }
        public string A { get; set; }
        public string N { get; set; }
        public string G { get; set; }
    }
}
