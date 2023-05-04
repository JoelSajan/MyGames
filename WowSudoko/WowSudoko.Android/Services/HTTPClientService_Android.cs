using System;
using System.Net.Http;
using Android.Net;
using Javax.Net.Ssl;
using WowSudoko.Utilities.Interface;
using Xamarin.Android.Net;

[assembly: Xamarin.Forms.Dependency(typeof(WowSudoko.Droid.Services.HTTPClientService_Android))]
namespace WowSudoko.Droid.Services
{
    public class HTTPClientService_Android : IHTTPClientService
    {
        public HttpClientHandler GetInsecureHandler()
        {
            return new IgnoreSSLClientHandler();
        }
        public HttpClient GetHttpClient()
        {
            return new HttpClient(new IgnoreSSLClientHandler());
        }

        internal class IgnoreSSLClientHandler : AndroidClientHandler
        {
            protected override SSLSocketFactory ConfigureCustomSSLSocketFactory(HttpsURLConnection connection)
            {
                return SSLCertificateSocketFactory.GetInsecure(150000, null);
            }

            protected override IHostnameVerifier GetSSLHostnameVerifier(HttpsURLConnection connection)
            {
                return new IgnoreSSLHostnameVerifier();
            }
        }

        internal class IgnoreSSLHostnameVerifier : Java.Lang.Object, IHostnameVerifier
        {
            public bool Verify(string hostname, ISSLSession session)
            {
                return true;
            }
        }

    }
}
