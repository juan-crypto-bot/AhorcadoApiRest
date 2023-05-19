using System.Collections.Generic;

namespace AhorcadoApiRest
{

    public class Word
    {
        public int Id { get; set; }

        public string Meaning { get; set; }
        public List<Letter> Letters { get; set; } = new List<Letter>();
        public Hanged Hanged { get; set; }

        public Word()
        {
        }
        public Word(WordDTO wordDTO)
        {
            this.Id = wordDTO.Id;
            List<Letter> letters = new List<Letter>();
            foreach (var lDTO in wordDTO.Letters)
            {
                Letter let = new Letter(lDTO);
                letters.Add(let);
            }
            Letters = letters;
            this.Meaning = wordDTO.Meaning;
            this.Hanged = wordDTO.Hanged;
        }
    }
}
