namespace AhorcadoApiRest
{

    public class Letter
    {

        public int Id { get; set; }
        public char Value { get; set; }


        public Letter() { }
        public Letter(char value)
        {
            this.Value = value;
        }
        public bool isEqual(Letter letter)
        {
            return this.Value == letter.Value;
        }
    }


}