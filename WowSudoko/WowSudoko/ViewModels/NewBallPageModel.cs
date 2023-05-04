using System;
namespace WowSudoko.ViewModels
{
    public class NewBallPageModel
    {
        public NewBallPageModel()
        {

            var myclass = new IndexterClass();
            myclass["name"] = "Justincooper";
            Console.WriteLine(myclass["name"]);
        }
    }
}
