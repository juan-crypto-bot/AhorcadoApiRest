using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace AhorcadoApiRest
{
    public interface ILetterService
    {
        Letter CreateLetter(LetterDTO letterDTO);
        Letter ReadLetter(LetterDTO letterDTO);
        void DeleteLetter(LetterDTO letterDTO);
        IEnumerable<Letter> GetAllLetters();
    }
    public class LetterService : ILetterService
    {

        private readonly ILetterRepository _letterRepository;

        private readonly ILogger<LetterService> _logger;
        public LetterService(ILogger<LetterService> logger, ILetterRepository letterRepository)
        {
            _logger = logger;
            _letterRepository = letterRepository;
        }

        public Letter CreateLetter(LetterDTO letterDTO)
        {
            Letter letter = new Letter(letterDTO);
            return _letterRepository.Create(letter);
        }

        public Letter ReadLetter(LetterDTO letterDTO)
        {
            Letter letter = new Letter(letterDTO);
            return _letterRepository.Read(letter);
        }

        public void DeleteLetter(LetterDTO letterDTO)
        {
            Letter letter = new Letter(letterDTO);
            _letterRepository.Delete(letter);
        }

        public IEnumerable<Letter> GetAllLetters()
        {
            return _letterRepository.GetAll();
        }
    }
}