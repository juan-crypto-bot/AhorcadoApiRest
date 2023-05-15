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
        public Word CreateWord(WordDTO wordDTO);
        Word ReadWord(WordDTO wordDTO);
        Word UpdateWord(WordDTO wordDTO);
        void DeleteWord(WordDTO wordDTO);
        IEnumerable<Word> GetAllWords();
        Word SelectRandomWord();
        bool TryLetter(Hanged hanged, LetterDTO letterDTO);
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


        public Word CreateWord(WordDTO wordDTO)
        {
            IEnumerable<Letter> letters = wordDTO.Letters.Select(letterDTO => _letterService.ReadLetter(letterDTO)).ToList();
            Word word = new Word(letters);

            foreach (var i in letters)
            {
                Console.WriteLine(i.Value);
            }
            return _wordRepository.Create(word);
        }


        public Word ReadWord(WordDTO wordDTO)
        {
            IEnumerable<Letter> letters = wordDTO.Letters.Select(letterDTO => _letterService.ReadLetter(letterDTO)).ToList();
            Word word = new Word(letters);
            return _wordRepository.Read(word);
        }


        public Word UpdateWord(WordDTO wordDTO)
        {
            IEnumerable<Letter> letters = wordDTO.Letters.Select(letterDTO => _letterService.ReadLetter(letterDTO)).ToList();
            Word word = new Word(letters);
            return _wordRepository.Update(word);
        }


        public void DeleteWord(WordDTO wordDTO)
        {
            IEnumerable<Letter> letters = wordDTO.Letters.Select(letterDTO => _letterService.ReadLetter(letterDTO)).ToList();
            Word word = new Word(letters);
            _wordRepository.Delete(word);
        }


        public IEnumerable<Word> GetAllWords()
        {
            return _wordRepository.GetAll();
        }


        public Word SelectRandomWord()
        {
            return _wordRepository.SelectRandomWord();
        }



        public bool TryLetter(Hanged hanged, LetterDTO letterDTO)
        {
            Letter l = _letterService.ReadLetter(letterDTO);
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

