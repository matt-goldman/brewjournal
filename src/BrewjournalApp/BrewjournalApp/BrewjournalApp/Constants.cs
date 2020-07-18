using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewjournalApp
{
    public static class Constants
    {
        private static string _apiUri;
        public static string ApiUri
        {
            get
            {
                return "https://3a9b26f298f4.ngrok.io";
            }
        }
    }
}
