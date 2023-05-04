using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using FreshMvvm;
using Project3.Management;
using Project3.Model;
using Project3.Pages;

namespace Project3.PageModels
{
    //static class StringClass
    //{
    //    public static float Truncate(this float value, int maxLength)
    //    {
    //        if (string.IsNullOrEmpty(value.ToString())) return value;
    //        return value.ToString().Length <= maxLength ? value : value;
    //    }
    //}
    public class MyGamePageModel : FreshBasePageModel
    {
        Fixture fixture { get; set; }
        float example { get; set; }
        public ISettingsService _settingsService;
        public MyGamePageModel(ISettingsService settingsService)
        {
            _settingsService = settingsService;
            fixture = new Fixture();
            //for(int i=0;i<5;i++)
            //{
            //    var playerinfo = fixture.Create<PlayerInfo>();
            //    insertPlayerDetails(playerinfo);
            //}
            //var list = accessPlayerDetails();
        }

        public async Task NavigateToRoot()
        {
            (CurrentPage as MyGamePage).needToNavigation = true;
            await CurrentPage.Navigation.PopAsync();
        }

        protected override void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);
        }

        public void insertPlayerDetails(PlayerInfo playerInfo)
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.db_Locatoin))
            {
                conn.CreateTable<PlayerInfo>();
                conn.Insert(playerInfo);
            } 
        }

        public List<PlayerInfo> accessPlayerDetails()
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.db_Locatoin))
            {
                conn.CreateTable<PlayerInfo>();
                return conn.Table<PlayerInfo>().ToList();
            }
        }
    }
}
