using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WowSudoko.CustomControls
{
    public class CustomLoader : Image
    {
        #region Fields

        private CancellationTokenSource cancellationToken;
        #endregion
 
        #region Binadables

        public static BindableProperty IsRunningProperty = BindableProperty.Create(
            propertyName: nameof(IsRunning),
            returnType: typeof(bool),
            declaringType: typeof(CustomLoader),
            defaultValue: false);

        public bool IsRunning
        {
            get { return (bool)GetValue(IsRunningProperty); }
            set { SetValue(IsRunningProperty, value); }
        }

        public static BindableProperty RotationLenghtProperty = BindableProperty.Create(
            propertyName: nameof(RotationLenght),
            returnType: typeof(int),
            declaringType: typeof(CustomLoader),
            defaultValue: 2500);

        public int RotationLenght
        {
            get { return (int)GetValue(RotationLenghtProperty); }
            set { SetValue(RotationLenghtProperty, value); }
        }

        public static BindableProperty EasingProperty = BindableProperty.Create(
            propertyName: nameof(Easing),
            returnType: typeof(Easing),
            declaringType: typeof(CustomLoader),
            defaultValue: Easing.CubicInOut);

        public Easing Easing
        {
            get { return (Easing)GetValue(EasingProperty); }
            set { SetValue(EasingProperty, value); }
        }

        #endregion

        #region Constructor(s)

        public CustomLoader()
        {
            Opacity = 0;
        }

        #endregion

        protected async override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == IsRunningProperty.PropertyName)
            {
                cancellationToken = new CancellationTokenSource();
                if (IsRunning)
                {
                    await this.FadeTo(1);
                    await RotateElement(this) ;
                }
                else
                {
                    cancellationToken?.Cancel();
                    await this.FadeTo(0);
                }
            }
        }

        public async Task RotateElement(VisualElement element)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
               await element.RotateTo(360, (uint)RotationLenght, this.Easing);
               await element.RotateTo(0, 0);
            }
            return;
        }
    }
}
