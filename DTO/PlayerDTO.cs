namespace AhorcadoApiRest
{

    public class PlayerDTO
    {

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public PlayerDTO()
        {
        }

        public PlayerDTO(string user, string pass)
        {
            this.Username = user;
            this.Password = pass;
        }

        public PlayerDTO(Player player)
        {
            this.Username = player.Username;
            this.Password = player.Password;
        }

    }


}