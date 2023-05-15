using System.Collections.Generic;
using System.Linq;

namespace AhorcadoApiRest
{

    public interface ILetterRepository
    {
        Letter Create(Letter letter);
        Letter Read(Letter letter);
        public void Delete(Letter letter);
        public IEnumerable<Letter> GetAll();
    }

    public class SqlServerLetterRepository : ILetterRepository
    {

        private readonly HangedDbContext _db;
        public SqlServerLetterRepository(HangedDbContext db)
        {
            _db = db;
            _db.Database.EnsureCreated();
        }

        public Letter Create(Letter letter)
        {
            letter.Value = char.ToUpper(letter.Value);
            _db.Letter.Add(letter);
            _db.SaveChanges();
            return letter;
        }

        public Letter Read(Letter letter)
        {
            return _db.Letter.FirstOrDefault(letter);
        }

        public void Delete(Letter letter)
        {
            _db.Letter.Remove(letter);
            _db.SaveChanges();
        }

        public IEnumerable<Letter> GetAll()
        {
            return _db.Letter.ToList();
        }
    }
}