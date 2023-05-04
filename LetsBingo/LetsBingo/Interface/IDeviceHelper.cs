using System;
using Xamarin.Forms;

namespace LetsBingo.Interface
{
    public interface IDeviceHelper
    {
        string GetPlatformName();

        Size GetScreenSize();
    }

}
