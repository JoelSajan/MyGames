using System;
using LetsBingo.Interface;
using Xamarin.Forms;

namespace LetsBingo.Managers
{
    public class DataService : IDataCommunications
    {
        string EntryDetails { get; set; }


        public string ApplicationRetrieve()
        {
            if (Application.Current.Properties.ContainsKey("EntryDetailsRecorded"))
                return Application.Current.Properties["EntryDetailsRecorded"].ToString();

            return EntryDetails;

        }

        public void ApplicationStorage(string EntryDetails)
        {
            Application.Current.Properties["EntryDetailsRecorded"] = EntryDetails;
            Application.Current.SavePropertiesAsync();
        }
        public DataService()
        {
        }
    }
}

