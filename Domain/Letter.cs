namespace AhorcadoApiRest{

    public class Letter{    
        
        public int Id{get; set;}
        public char Value{get; set;}

        public bool isEqual(Letter letter){
           return this.Value == letter.Value;
        }
    }


}