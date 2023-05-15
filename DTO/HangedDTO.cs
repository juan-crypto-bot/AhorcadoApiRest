using System.Collections.Generic;

namespace AhorcadoApiRest
{

    public class HangedDTO
    {

        public int Id { get; set; }
        public int Lives { get; set; }
        public PlayerDTO PlayerDTO { get; set; }
        public WordDTO WordDTO { get; set; }

        public List<Letter> UsedLetter { get; set; } = new List<Letter>();

        public HangedDTO()
        {

        }

        public HangedDTO(PlayerDTO playerDTO, WordDTO wordDTO)
        {
            this.Lives = 6;
            this.PlayerDTO = playerDTO;
            this.WordDTO = wordDTO;

        }

    }

}