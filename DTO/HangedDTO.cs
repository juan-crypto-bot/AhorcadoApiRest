using System.Collections.Generic;

namespace AhorcadoApiRest
{

    public class HangedDTO
    {

        public int Id { get; set; }
        public int Lives { get; set; }
        public string Word { get; set; }
        public List<Letter> UsedLetter { get; set; } = new List<Letter>();

        public HangedDTO()
        {

        }
        public HangedDTO(Hanged hanged)
        {
            this.Id = hanged.Id;
            this.Lives = hanged.Lives;
            foreach (var c in hanged.Word.Letters)
            {
                if (c.IsGuessed == true) this.Word += c;
                else this.Word += '*';
            }
            this.UsedLetter = hanged.UsedLetter;
        }


    }

}