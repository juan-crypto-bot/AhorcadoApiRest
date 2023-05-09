using System.Collections.Generic;

namespace AhorcadoApiRest
{

    public class Hanged
    {

        public int Id { get; set; }
        public Player Player { get; set; }
        public Hang Hang { get; set; }
        public Word Word { get; set; }

        public List<Letter> UsedLetter { get; set; } = new List<Letter>();

        public Hanged()
        {

        }

        public Hanged(Player player, Word word)
        {
            this.Player = player;
            this.Hang = new Hang();
            this.Word = word;

        }

    }

}