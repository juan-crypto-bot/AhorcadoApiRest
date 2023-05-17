namespace AhorcadoApiRest
{

    public class LetterDTO
    {

        public int Id { get; set; }
        public char Value { get; set; }
        public bool IsGuessed { get; set; }
        public int IdWord { get; set; }


        public LetterDTO() { }
        public LetterDTO(char value)
        {
            this.Value = value;
            this.IsGuessed = false;
        }
        public LetterDTO(Letter letter)
        {
            this.Id = letter.Id;
            this.Value = letter.Value;
            this.IsGuessed = letter.IsGuessed;
            this.IdWord = letter.IdWord;
        }
    }


}