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
        void DeleteWord(WordDTO wordDTO);
        IEnumerable<Word> GetAllWords();
        Word SelectRandomWord();
        void Discovery(Word word, LetterDTO letterDTO);
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
            Word word = new Word(wordDTO);
            word = _wordRepository.Create(word); //se crea la palabra primero
            foreach (var c in word.Letters)
            {
                c.IdWord = word.Id;
                LetterDTO letterDTO = new LetterDTO(c);
                _letterService.UpdateIdWord(letterDTO); //por cada letra de la palabra se le asigna el id de la palabra en la columna IdWord
            }
            return word;
        }


        public Word ReadWord(WordDTO wordDTO)
        {
            Word word = new Word(wordDTO);
            return _wordRepository.Read(word);
        }

        public void DeleteWord(WordDTO wordDTO)
        {
            Word word = new Word(wordDTO);
            _wordRepository.EmptyList(word); //vacio la lista de letras que tiene word sino se producen conflictos con la foreign key
            IEnumerable<Letter> letters = _letterService.GetLettersByIdWord(wordDTO.Id);

            foreach (var l in letters)
            {
                LetterDTO letterDTO = new LetterDTO(l);
                _letterService.DeleteLetter(letterDTO); //se borran las letras primero sino se producen conflictos con la foreign key
            }
            _wordRepository.Delete(word); //por ultimo se borra la word
        }


        public IEnumerable<Word> GetAllWords()
        {
            return _wordRepository.GetAll();
        }


        public Word SelectRandomWord()
        {
            return _wordRepository.SelectRandomWord();
        }

        public void Discovery(Word word, LetterDTO letterDTO)
        {
            IEnumerable<Letter> letters = _letterService.GetLettersByIdWord(word.Id);
            for (int i = 0; i < letters.Count(); i++)
            {
                if (letters.ElementAt(i).Value == letterDTO.Value)
                {
                    LetterDTO lDTO = new LetterDTO(letters.ElementAt(i));
                    _letterService.Discovery(lDTO);
                }
            }
        }

        public bool TryLetter(Hanged hanged, LetterDTO letterDTO)
        {
            //Letter letter = _letterService.ReadLetterForValue(letterDTO);
            WordDTO wordDTO = new WordDTO(hanged.Word);
            IEnumerable<Letter> letters = _letterService.GetLettersByIdWord(wordDTO.Id);
            Letter letter = new Letter(letterDTO);
            for (int i = 0; i < letters.Count(); i++)
            {
                if (letters.ElementAt(i).Value == letterDTO.Value) return true;
            }
            return false;
        }
    }
}

