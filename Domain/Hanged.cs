using System.Collections.Generic;

namespace AhorcadoApiRest
{

    public class Hanged
    {

        public int Id { get; set; }
        public int Lives { get; set; }
        public int PlayerId { get; set; }
        public Player Player { get; set; }
        public int WordId { get; set; }
        public Word Word { get; set; }

        public List<Letter> UsedLetter { get; set; } = new List<Letter>();

        public Hanged()
        {

        }

        public Hanged(Player player, Word word)
        {
            this.Lives = 6;
            this.Player = player;
            this.PlayerId = Player.Id;
            this.Word = word;
            this.WordId = Word.Id;

        }

    }

}