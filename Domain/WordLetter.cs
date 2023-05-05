

namespace AhorcadoApiRest{

    public class WordLetter{    
        

        public int WordId {get;set;}
        

        public int LetterId {get;set;}
        public virtual Word Word{get; set;}
        
        public virtual Letter Letter{get; set;}

        public int Position{get; set;}
        public WordLetter(){

        }
    }
}