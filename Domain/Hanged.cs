using System.Collections.Generic;

namespace AhorcadoApiRest{

    public class Hanged{    
        
        public int Id{get; set;}
        public Player Player{get; set;}
        public Hang Hang{get; set;}
        public Word Word{get; set;}

        public IEnumerable<HangedLetter> HangedLetter{get; set;}
      
    }    

}