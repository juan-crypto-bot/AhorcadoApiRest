namespace AhorcadoApiRest
{

    public class Letter
    {

        public int Id { get; set; }
        public char Value { get; set; }
        public bool IsGuessed { get; set; }
        public int IdWord { get; set; }


        public Letter() { }

        public Letter(LetterDTO letterDTO)
        {
            this.Id = letterDTO.Id;
            this.Value = letterDTO.Value;
            this.IsGuessed = letterDTO.IsGuessed;
            this.IdWord = letterDTO.IdWord;
        }
        public Letter(char value)
        {
            this.Value = value;
            this.IsGuessed = false;
        }
        public bool isEqual(Letter letter)
        {
            return this.Value == letter.Value;
        }
    }


}