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
            _apiUri = "https://84dd0f94ad87.ngrok.io";
        }
    }
}
