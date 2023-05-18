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
        HangedStruct CreateHanged(PlayerDTO playerDTO);
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
        private readonly IWordService _wordService;
        private readonly ILogger<HangedService> _logger;

        public HangedService(ILogger<HangedService> logger, IPlayerService playerService, IWordService wordService, IHangedRepository hangedRepository)
        {
            _logger = logger;
            _playerService = playerService;
            _wordService = wordService;
            _hangedRepository = hangedRepository;
        }

        public HangedStruct CreateHanged(PlayerDTO playerDTO)
        {
            var player = _playerService.ReadPlayer(playerDTO);
            var word = _wordService.SelectRandomWord();
            HangedStruct hangedStruct = new HangedStruct(_hangedRepository.Create(player, word));
            return hangedStruct;
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
                bool isGuessed = _wordService.TryLetter(hanged, letterDTO); //Lo ideal es pasar HangedDTO. Falta esa logica.
                Console.WriteLine(isGuessed);
                if (isGuessed)
                {
                    _wordService.Discovery(hanged.Word, letterDTO);//Lo ideal es pasar WordDTO. Falta esa logica.
                }
                else
                {
                    hanged.Lives -= 1;
                }
                Letter letter = new Letter(letterDTO);
                hanged.UsedLetter.Add(letter);
                _hangedRepository.UpdateHanged(hanged);
            }
            return new HangedDTO(hanged);
        }
    }

}
