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
        Hanged CreateHanged(string user);
        Player CreatePlayer(string user, string pass);
        Word CreateWord(string param);
        Letter CreateLetter(string letter);
        Hanged ReadHanged(int id);
        Player ReadPlayer(string user);
        Word ReadWord(string meaning);
        Letter ReadLetter(string letter);
        void DeleteHanged(int id);
        void DeletePlayer(string user, string pass);
        void DeleteWord(string meaning);
        void DeleteLetter(string letter);
        IEnumerable<Hanged> GetAllHangeds();
        IEnumerable<Player> GetAllPlayers();
        IEnumerable<Word> GetAllWords();
        IEnumerable<Letter> GetAllLetters();
        Hanged UpdateHanged(int id);
        Player UpdatePlayer(string user, string pass);
        Word UpdateWord(string meaning);
        Letter UpdateLetter(string letter);
        bool Play(int HangedId, char letter);

    }
    public class HangedService : IHangedService
    {
        private readonly IPlayerService _playerService;
        private readonly IHangedRepository _hangedRepository;
        private readonly IWordService _wordService;
        private readonly ILetterService _letterService;
        private readonly ILogger<HangedService> _logger;

        public HangedService(ILogger<HangedService> logger, ILetterService letterService, IPlayerService playerService, IWordService wordService, IHangedRepository hangedRepository)
        {
            _logger = logger;
            _playerService = playerService;
            _wordService = wordService;
            _letterService = letterService;
            _hangedRepository = hangedRepository;
        }


        //Create--------------------------------------------------------------------------------
        public Hanged CreateHanged(string user)
        {
            var player = _playerService.ReadPlayer(user);
            var word = _wordService.SelectRandomWord();
            return _hangedRepository.Create(player, word);
        }
        public Player CreatePlayer(string user, string pass)
        {
            return _playerService.CreatePlayer(user, pass);
        }
        public Word CreateWord(string param)
        {
            return _wordService.CreateWord(param);
        }
        public Letter CreateLetter(string letter)
        {
            return _letterService.CreateLetter(letter);
        }

        //Read------------------------------------------------------------------------------------
        public Hanged ReadHanged(int id)
        {
            return _hangedRepository.Read(id);
        }
        public Player ReadPlayer(string user)
        {
            return _playerService.ReadPlayer(user);
        }
        public Word ReadWord(string meaning)
        {
            return _wordService.ReadWord(meaning);
        }
        public Letter ReadLetter(string letter)
        {
            return _letterService.ReadLetter(letter);
        }

        //Delete---------------------------------------------------------------------------------

        public void DeleteHanged(int id)
        {
            _hangedRepository.Delete(id);
        }
        public void DeletePlayer(string user, string pass)
        {
            _playerService.DeletePlayer(user, pass);
        }
        public void DeleteWord(string meaning)
        {
            _wordService.DeleteWord(meaning);
        }
        public void DeleteLetter(string letter)
        {
            _letterService.DeleteLetter(letter);
        }

        //GetAll------------------------------------------------------------------------------------

        public IEnumerable<Hanged> GetAllHangeds()
        {
            return _hangedRepository.GetAllHangeds();
        }
        public IEnumerable<Player> GetAllPlayers()
        {
            return _playerService.GetAllPlayers();
        }
        public IEnumerable<Word> GetAllWords()
        {
            return _wordService.GetAllWords();
        }
        public IEnumerable<Letter> GetAllLetters()
        {
            return _letterService.GetAllLetters();
        }

        //Update--------------------------------------------------------------------------------------------
        public Hanged UpdateHanged(int id)
        {
            return _hangedRepository.Update(id);

        }
        public Player UpdatePlayer(string user, string pass)
        {
            return _playerService.UpdatePlayer(user, pass);

        }
        public Word UpdateWord(string meaning)
        {
            return _wordService.UpdateWord(meaning);

        }
        public Letter UpdateLetter(string letter)
        {
            return _letterService.UpdateLetter(letter);

        }

        //----------------------------------------------------------------------------------------------

        public bool Play(int HangedId, char letter)
        {
            var hanged = this.ReadHanged(HangedId);
            return _wordService.TryLetter(hanged, letter);
        }
    }
}