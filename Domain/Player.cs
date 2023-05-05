namespace AhorcadoApiRest{

    public class Player{    
        
        public int Id{get; set;}
        public string Username{get; set;}
        public string Password{get; set;}
      
        public Player(string u, string p){
            this.Username = u;
            this.Password = p;
        }
    
    }


}