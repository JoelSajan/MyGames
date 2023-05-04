using System;
namespace LetsBingo.Interface
{
    public interface IDataCommunications
    {
        void ApplicationStorage(string EntryDetails);
        string ApplicationRetrieve();
    }

}
