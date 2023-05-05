
namespace AhorcadoApiRest{

    public class HangedLetter{    

        public int HangedId {get;set;}

        public int LetterId {get;set;}
        public virtual Hanged Hanged{get; set;}
        public virtual Letter Letter{get; set;}

        public bool IsGuessed{get; set;}

        public HangedLetter(){
            
        }
      
    }


}