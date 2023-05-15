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
        Hanged CreateHanged(PlayerDTO playerDTO);
        Hanged ReadHanged(int id);
        void DeleteHanged(int id);
        IEnumerable<Hanged> GetAllHangeds();
        // bool Play(int HangedId, char letter);

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

        public Hanged CreateHanged(PlayerDTO playerDTO)
        {
            var player = _playerService.ReadPlayer(playerDTO);
            var word = _wordService.SelectRandomWord();
            return _hangedRepository.Create(player, word);
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

        /*public bool Play(int HangedId, char letter)
        {
            var hanged = this.ReadHanged(HangedId);
            return _wordService.TryLetter(hanged, letter);
        }*/
    }
}