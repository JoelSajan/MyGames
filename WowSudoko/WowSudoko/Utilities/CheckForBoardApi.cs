using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WowSudoko.Utilities.Interface;
using Xamarin.Forms;

namespace WowSudoko.Utilities
{
    public static class CheckForBoardApi
    {
        static HttpClient _client = new HttpClient();
        static CheckForBoardApi()
        {
            var checkForBoardApi = DependencyService.Get<IHTTPClientService>();
            _client = checkForBoardApi.GetHttpClient();
        }

        public static async Task<HttpResponseMessage> ListAllProducts()
        {
            HttpResponseMessage response = new HttpResponseMessage(System.Net.HttpStatusCode.NotFound);
            try
            {
                Uri uri;
                uri = new Uri(string.Format("http://127.0.0.1:51449/api/Employee"));
                response = await _client.GetAsync(uri);
            }
            catch (Exception ex)
            {
            }
            return response;
        }
    }
}
