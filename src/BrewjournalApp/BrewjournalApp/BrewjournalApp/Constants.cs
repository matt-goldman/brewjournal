using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewjournalApp
{
    public class Constants
    {
        private string _apiUri;

        public string ApiUri
        {
            get
            {
                return _apiUri;
            }
        }

        public Constants()
        {
            _apiUri = ""; //TODO: copy your API uri here
        }
    }
}
