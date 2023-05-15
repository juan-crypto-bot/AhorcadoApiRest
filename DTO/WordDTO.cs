using System.Collections.Generic;

namespace AhorcadoApiRest
{

    public class WordDTO
    {
        public int Id { get; set; }
        public IEnumerable<LetterDTO> Letters { get; set; } = new List<LetterDTO>();

        public WordDTO()
        {
        }
        public WordDTO(IEnumerable<LetterDTO> meaning)
        {
            Letters = meaning;
        }

    }

}