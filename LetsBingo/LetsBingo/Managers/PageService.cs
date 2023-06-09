﻿using System;
using System.Threading.Tasks;
using LetsBingo.Interface;
using Xamarin.Forms;

namespace LetsBingo.Managers
{
    public class PageService : IPageService
    {
        public PageService()
        {
        }

        public async Task<bool> DisplayAlert(string title, string message, string ok, string cancel)
        {
            return await Application.Current.MainPage.DisplayAlert(title, message, ok, cancel);
        }

        public async Task PushAsync(Page page)
        {
            await Application.Current.MainPage.Navigation.PushAsync(page);
        }
    }
}

