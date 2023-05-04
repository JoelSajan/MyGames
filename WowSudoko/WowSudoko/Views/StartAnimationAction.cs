using System;
using Xamarin.Forms;

namespace WowSudoko.Views
{
    public class StartAnimationAction : TriggerAction<VisualElement>
    {
        public Animation anime1 { get; set;}
        public Animation anime2 { get; set; }
        public StartAnimationAction()
        {
            
        }

        protected override void Invoke(VisualElement sender)
        {
            anime1 = new Animation(v=>sender.ScaleTo(v,1000,easing: Easing.Linear),1,10);
            anime1.Commit(sender, "ScaleIt", length: 1000, easing: Easing.Linear,
                finished:(x,y)=> finalMethod(sender), repeat: () => true);
        }

        public void finalMethod(VisualElement sender)
        {
            sender.AbortAnimation("ScaleIt");
            //Action<int>intAction = new Action<int>(i => {
            //    anime2 = new Animation(v => sender.ScaleTo(v, 1000, easing: Easing.BounceOut), i, 1);
            //    anime2.Commit(sender, "ScaleOut", length: 1000, easing: Easing.Linear);
            //});
            //intAction(10);
            
        }
    }
}
