using System;
using System.Net.Http;

namespace WowSudoko.Utilities.Interface
{
    public interface IHTTPClientService
    {
        HttpClient GetHttpClient();
    }
}
