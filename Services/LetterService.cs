using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace AhorcadoApiRest
{
    public interface ILetterService
    {
        Letter CreateLetter(string value);
        Letter ReadLetter(string value);
        Letter UpdateLetter(string value);
        void DeleteLetter(string value);
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

        public Letter CreateLetter(string value)
        {
            char firstChar = value.FirstOrDefault();
            return _letterRepository.Create(firstChar);
        }

        public Letter ReadLetter(string value)
        {
            char firstChar = value.FirstOrDefault();
            return _letterRepository.Read(firstChar);
        }

        public Letter UpdateLetter(string value)
        {
            char firstChar = value.FirstOrDefault();
            return _letterRepository.Update(firstChar);

        }

        public void DeleteLetter(string value)
        {
            char firstChar = value.FirstOrDefault();
            _letterRepository.Delete(firstChar);
        }

        public IEnumerable<Letter> GetAllLetters()
        {
            return _letterRepository.GetAll();
        }
    }
}