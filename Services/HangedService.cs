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

        Hanged FindById(int id);
        IEnumerable<Hanged> GetAll();
        bool Delete(int id);
        Hanged NewGame(int player);
        Word CreateWord(string param);
        Hanged Play(int HangedId, char letter);

    }
    public class HangedService : IHangedService
    {

        private readonly IPlayerService _playerService;
        private readonly IHangedRepository _hangedRepository;
        private readonly IWordService _wordService;
        private readonly ILogger<HangedService> _logger;
        private readonly HangedDbContext _db;
        public HangedService(ILogger<HangedService> logger, HangedDbContext db, IPlayerService playerService, IWordService wordService, IHangedRepository hangedRepository)
        {
            _db = db;
            _db.Database.EnsureCreated();
            _logger = logger;
            _playerService = playerService;
            _wordService = wordService;
            _hangedRepository = hangedRepository;
            //correjir esto    
        }

        public Hanged FindById(int id)
        {
            _logger.LogInformation("Searching for Hang with id: " + id);
            return _hangedRepository.FindById(id);
        }

        public IEnumerable<Hanged> GetAll()
        {
            return _hangedRepository.GetAll();
        }
        public bool Delete(int id)
        {
            return _hangedRepository.Delete(id);
        }

        public Hanged NewGame(int PlayerId)
        {
            var player = _playerService.FindPlayerById(PlayerId);
            var word = _wordService.SelectRandomWord();
            return _hangedRepository.CreateHanged(player, word);
        }

        public Word CreateWord(string param)
        {
            return _wordService.CreateWord(param);
        }

        public Hanged Play(int HangedId, char letter)
        {
            var hanged = this.FindById(HangedId);
            return _wordService.TryLetter(hanged, letter);
        }
    }
}