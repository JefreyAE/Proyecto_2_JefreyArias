using Front_Proyecto_2.Models;

namespace Front_Proyecto_2.Helpers
{
    public sealed class TokenKeeper
    {
        private static string _token;
        private static User _user;

        private TokenKeeper()
        {

        }

        public static string Token
        {
            get { return _token; }
            set { _token = value; }
        }

        public static User User
        {
            get { return _user; }
            set { _user = value; }
        }
    }
}
