using System.Collections.Generic;

namespace AhorcadoApiRest
{

    public class Word
    {

        public int Id { get; set; }

        public IEnumerable<Letter> Letters { get; set; } = new List<Letter>();
        public Word()
        {

        }
        public Word(IEnumerable<Letter> meaning)
        {
            Letters = meaning;
        }

    }

}
