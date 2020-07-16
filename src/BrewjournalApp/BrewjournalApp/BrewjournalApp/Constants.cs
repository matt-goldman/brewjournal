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
            _apiUri = "https://4c3f8f3dea4d.ngrok.io";
        }
    }
}
