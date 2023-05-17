using System.Collections.Generic;

namespace AhorcadoApiRest
{

    public class WordDTO
    {
        public int Id { get; set; }
        public string Meaning { get; set; }
        public List<LetterDTO> Letters { get; set; } = new List<LetterDTO>();

        public WordDTO()
        {
        }
        public WordDTO(List<LetterDTO> letters, string meaning)
        {
            Letters = letters;
            Meaning = meaning;
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
        }

    }

}