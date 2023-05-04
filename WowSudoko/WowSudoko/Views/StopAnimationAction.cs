using System;
using Xamarin.Forms;

namespace WowSudoko.Views
{
    public class StopAnimationAction: TriggerAction<VisualElement>
    {
        public StopAnimationAction()
        {
        }

        protected override void Invoke(VisualElement sender)
        {
            ViewExtensions.CancelAnimations(sender);
        }
    }
}
