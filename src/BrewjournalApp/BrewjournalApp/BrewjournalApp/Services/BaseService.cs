using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BrewjournalApp.Services
{
    public class BaseService
    {

        public static HttpClient httpClient { get; set; }
        public static string apiUri;

        public BaseService()
        {
            httpClient = new HttpClient();
            apiUri = App.Constants.ApiUri;
        }
    }
}
