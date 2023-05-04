using System;
using Plugin.Settings.Abstractions;

namespace Project3.Management
{
    public interface ISettingsService
    {
        ISettings AppSettings { get; }

        string MyGameTile { get; set; }
    }
}
