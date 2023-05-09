using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace AhorcadoApiRest
{
    public interface IWordService
    {
        Word SelectRandomWord();

        Hanged TryLetter(Hanged hanged, char letter);

        Word CreateWord(string meaning);

    }
    public class WordService : IWordService
    {

        private ILetterRepository _letterRepository;
        private IWordRepository _wordRepository;
        private ILetterService _letterService;
        private readonly ILogger<PlayerService> _logger;

        private readonly HangedDbContext _db;
        public WordService(ILogger<PlayerService> logger, HangedDbContext db, ILetterService letterService, IWordRepository wordRepository, ILetterRepository letterRepository)
        {
            _db = db;
            _logger = logger;
            _letterService = letterService;
            _wordRepository = wordRepository;
            _letterRepository = letterRepository;
            //_db.Database.EnsureCreated();    
        }

        public Word SelectRandomWord()
        {
            return _wordRepository.SelectRandomWord();
        }

        public Word CreateWord(string meaning)
        {
            var letters = meaning.ToCharArray().Select(letter => _letterService.GetLetterByChar(letter)).ToList();
            return _wordRepository.CreateWord(letters);
        }

        public Hanged TryLetter(Hanged hanged, char letter)
        {
            foreach (var i in hanged.Word.Letters)
            {
                if (i.Value == letter)
                {
                    //Que pasa si es igual??
                }
                else //que pasa si es diferente???


            }
        }
    }
}
