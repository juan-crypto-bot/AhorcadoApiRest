using System.Collections.Generic;

namespace AhorcadoApiRest{

    public class Word{    
        
        public int Id{get; set;}

        public IEnumerable<WordLetter> WordLetter{get; set;}
        
        public Word(){


        }
    
    }
}  