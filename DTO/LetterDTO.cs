namespace AhorcadoApiRest
{

    public class LetterDTO
    {

        public int Id { get; set; }
        public char Value { get; set; }


        public LetterDTO() { }
        public LetterDTO(char value)
        {
            this.Value = value;
        }
    }


}