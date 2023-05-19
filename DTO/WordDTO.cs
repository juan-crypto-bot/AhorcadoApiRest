using System.Collections.Generic;

namespace AhorcadoApiRest
{

    public class WordDTO
    {
        public int Id { get; set; }
        public string Meaning { get; set; }
        public List<LetterDTO> Letters { get; set; } = new List<LetterDTO>();
        public Hanged Hanged { get; set; }

        public WordDTO()
        {
        }
        public WordDTO(Word word)
        {
            this.Id = word.Id;
            List<LetterDTO> letters = new List<LetterDTO>();
            foreach (var l in word.Letters)
            {
                LetterDTO letDTO = new LetterDTO(l);
                letters.Add(letDTO);
            }
            Letters = letters;
            this.Meaning = word.Meaning;
            this.Hanged = word.Hanged;
        }

    }

}