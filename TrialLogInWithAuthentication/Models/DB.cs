using Newtonsoft.Json;
using System.Net;

namespace TrialLogInWithAuthentication.Models
{
    public static class DB
    {
        private static readonly List<User> _users = new List<User>()
        {
            new User("Marco", "1"),
            new User("Nicolò", "2"),
            new User("Davide", "3")
        };


        public static string Login(User U)
        {
            var utente = _users.FirstOrDefault(l => l.Username == U.Username && l.Password == U.Password);

            if (utente != null)
            {
                return Randomize().ToString();
            }
            else return null;
        }

        private static int Randomize()
        {
            var rnd = new Random();
            return rnd.Next(1, 10000);
        }

        public static List<Telephone> GetTelephones()
        {
            using (var client = new WebClient())
            {
                var json = client.DownloadString("https://gist.githubusercontent.com/hanse/4458506/raw/a702c19d07bd7693ee75efef18502c421b565949/phones.json");
                var products = JsonConvert.DeserializeObject<List<Telephone>>(json);
                return products;
            }
        }

        public static Telephone GetTelephone(string name)
        {
            List<Telephone> Elements = GetTelephones();
            Telephone element = Elements.FirstOrDefault(l => l.Model == name);
            return element;
        }


    }
}
