using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace AhorcadoApiRest
{
    public interface IHangedService
    {
        HangedDTO CreateHanged(PlayerDTO playerDTO);
        Hanged ReadHanged(int id);
        void DeleteHanged(int id);
        IEnumerable<Hanged> GetAllHangeds();
        HangedDTO Play(int HangedId, LetterDTO letterDTO);
        bool isUsedLetter(Hanged hanged, char letter);

    }
    public class HangedService : IHangedService
    {
        private readonly IPlayerService _playerService;
        private readonly IHangedRepository _hangedRepository;
        private readonly ILetterService _letterService;
        private readonly IWordService _wordService;
        private readonly ILogger<HangedService> _logger;

        public HangedService(ILogger<HangedService> logger, IPlayerService playerService, IWordService wordService, IHangedRepository hangedRepository, ILetterService letterService)
        {
            _logger = logger;
            _playerService = playerService;
            _wordService = wordService;
            _letterService = letterService;
            _hangedRepository = hangedRepository;
        }

        public HangedDTO CreateHanged(PlayerDTO playerDTO)
        {
            var player = _playerService.ReadPlayer(playerDTO);
            var word = _wordService.SelectRandomWord();
            IEnumerable<Letter> letters = _letterService.GetLettersByIdWord(word.Id);
            return new HangedDTO(_hangedRepository.Create(player, word), letters);
        }

        public Hanged ReadHanged(int id)
        {
            return _hangedRepository.Read(id);
        }

        public void DeleteHanged(int id)
        {
            _hangedRepository.Delete(id);
        }

        public IEnumerable<Hanged> GetAllHangeds()
        {
            return _hangedRepository.GetAllHangeds();
        }

        public bool isUsedLetter(Hanged hanged, char letter)
        {
            foreach (var aux in hanged.UsedLetter)
            {
                if (aux.Value == letter) return true;
            }
            return false;
        }

        public HangedDTO Play(int HangedId, LetterDTO letterDTO)
        {
            Hanged hanged = this.ReadHanged(HangedId);

            if (!this.isUsedLetter(hanged, letterDTO.Value))
            {
                bool isGuessed = _wordService.TryLetter(hanged, letterDTO); //Implementarlo en hanged directamente
                if (isGuessed)
                {
                    _wordService.Discovery(hanged.Word, letterDTO);//Lo ideal es pasar WordDTO. Falta esa logica.
                }
                else
                {
                    hanged.Lives -= 1;
                }
                if (hanged.Lives == 0)
                {
                    Console.WriteLine("Game Over.You lose");
                }
                Letter letter = new Letter(letterDTO);
                hanged.UsedLetter.Add(letter);
                _hangedRepository.UpdateHanged(hanged);
            }
            IEnumerable<Letter> letters = _letterService.GetLettersByIdWord(hanged.Word.Id);
            return new HangedDTO(hanged, letters);
        }
        //Controlar cuando termina y controlar las used letters que sean solo enteros
    }

}
