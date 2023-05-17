using System.Collections.Generic;

namespace AhorcadoApiRest
{
    public struct HangedStruct
    {
        public string PlayerUsername { get; set; }
        public string WordMeaning { get; set; }
        public int Lives { get; set; }
        public List<Letter> UsedLetters = new List<Letter>();

        public HangedStruct()
        {
        }

        public HangedStruct(Hanged hanged)
        {
            this.PlayerUsername = hanged.Player.Username;
            this.WordMeaning = hanged.Word.Meaning;
            this.Lives = hanged.Lives;
            this.UsedLetters = hanged.UsedLetter;
        }
    }
}