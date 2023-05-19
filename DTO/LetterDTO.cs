namespace AhorcadoApiRest
{

    public class LetterDTO
    {

        public int Id { get; set; }
        public char Value { get; set; }
        public bool IsGuessed { get; set; }
        public int IdWord { get; set; }
        //public Word Word { get; set; }
        //public int IdHanged { get; set; }
        //public Hanged Hanged { get; set; }


        public LetterDTO() { }
        public LetterDTO(Letter letter)
        {
            this.Id = letter.Id;
            this.Value = letter.Value;
            this.IsGuessed = letter.IsGuessed;
            this.IdWord = letter.IdWord;
            //this.Word = letter.Word;
            //this.IdHanged = letter.IdHanged;
            //this.Hanged = letter.Hanged;
        }
    }


}