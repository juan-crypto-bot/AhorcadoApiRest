using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace AhorcadoApiRest
{
    public interface ILetterService
    {
        Letter GetLetterByChar(char l);
    }
    public class LetterService : ILetterService
    {

        private readonly ILetterRepository _letterRepository;

        private readonly ILogger<LetterService> _logger;

        private readonly HangedDbContext _db;
        public LetterService(ILogger<LetterService> logger, HangedDbContext db, ILetterRepository letterRepository)
        {
            _db = db;
            _logger = logger;
            _letterRepository = letterRepository;
        }

        public Letter GetLetterByChar(char l)
        {
            return _letterRepository.GetLetterByChar(l);
        }
    }
}