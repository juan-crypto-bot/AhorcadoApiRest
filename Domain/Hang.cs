namespace AhorcadoApiRest{

    public class Hang{    
        
      public int Id{get; set;}
      public int Lives{get; set;}
      
      public Hang(int lives){
          this.Lives = lives;
      }

      public Hang(){

      }
    }
}