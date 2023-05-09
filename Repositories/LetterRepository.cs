using System.Collections.Generic;
using System.Linq;

namespace AhorcadoApiRest
{

    public interface ILetterRepository
    {
        Letter GetLetterByChar(char l);
    }

    public class SqlServerLetterRepository : ILetterRepository
    {

        private readonly HangedDbContext _db;
        public SqlServerLetterRepository(HangedDbContext db)
        {
            _db = db;
        }
        public Letter GetLetterByChar(char l)
        {
            return _db.Letter.ToList().Find(letter => letter.Value.ToString() == l.ToString().ToUpper());
        }
    }
}