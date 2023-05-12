namespace AhorcadoApiRest
{

    public class Player
    {

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public Player()
        {
        }

        public Player(string user, string pass)
        {
            this.Username = user;
            this.Password = pass;
        }

    }


}