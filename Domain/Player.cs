namespace AhorcadoApiRest
{

    public class Player
    {

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        //public Hanged Hanged { get; set; }

        public Player()
        {
        }
        public Player(PlayerDTO playerDTO)
        {
            this.Id = playerDTO.Id;
            this.Username = playerDTO.Username;
            this.Password = playerDTO.Password;
            //this.Hanged = playerDTO.Hanged;
        }
    }
}