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
        public Word CreateWord(string meaning);
        Word ReadWord(string meaning);
        Word UpdateWord(string meaning);
        void DeleteWord(string meaning);
        IEnumerable<Word> GetAllWords();
        Word SelectRandomWord();
        bool TryLetter(Hanged hanged, char letter);
    }
    public class WordService : IWordService
    {
        private IWordRepository _wordRepository;
        private ILetterService _letterService;
        private readonly ILogger<WordService> _logger;
        public WordService(ILogger<WordService> logger, ILetterService letterService, IWordRepository wordRepository)
        {
            _logger = logger;
            _letterService = letterService;
            _wordRepository = wordRepository;
        }


        public Word CreateWord(string meaning)
        {
            IEnumerable<Letter> letters = meaning.ToCharArray().Select(letter => _letterService.ReadLetter(letter.ToString())).ToList();

            foreach (var i in letters)
            {
                Console.WriteLine(i.Value);
            }
            return _wordRepository.Create(letters);
        }


        public Word ReadWord(string meaning)
        {
            IEnumerable<Letter> letters = meaning.Select(letter => _letterService.ReadLetter(letter.ToString())).ToList();
            return _wordRepository.Read(letters);
        }


        public Word UpdateWord(string meaning)
        {
            return _wordRepository.Update(meaning);

        }


        public void DeleteWord(string meaning)
        {
            IEnumerable<Letter> letters = meaning.Select(letter => _letterService.ReadLetter(letter.ToString())).ToList();
            _wordRepository.Delete(letters);
        }


        public IEnumerable<Word> GetAllWords()
        {
            return _wordRepository.GetAll();
        }


        public Word SelectRandomWord()
        {
            return _wordRepository.SelectRandomWord();
        }



        public bool TryLetter(Hanged hanged, char letter)
        {
            Letter l = _letterService.ReadLetter(letter.ToString());
            if (hanged.UsedLetter.Contains(l)) return true;
            else return false;

            /* foreach (var i in hanged.Word.Letters)
             {
                 if (i.Value == letter)
                 {
                     //Que pasa si es igual??
                 }
                 else //que pasa si es diferente???*/


        }
    }
}

