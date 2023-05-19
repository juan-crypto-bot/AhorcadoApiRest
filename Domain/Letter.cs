namespace AhorcadoApiRest
{

    public class Letter
    {

        public int Id { get; set; }
        public char Value { get; set; }
        public bool IsGuessed { get; set; }
        public int IdWord { get; set; }
        //public Word Word { get; set; }
        //public int IdHanged{get; set;}
        //public Hanged Hanged { get; set; }


        public Letter() { }

        public Letter(LetterDTO letterDTO)
        {
            this.Id = letterDTO.Id;
            this.Value = letterDTO.Value;
            this.IsGuessed = letterDTO.IsGuessed;
            this.IdWord = letterDTO.IdWord;
            //this.Word = letterDTO.Word;
            //this.IdHanged = letterDTO.IdHanged;
            //this.Hanged = letterDTO.Hanged;
        }
    }
}