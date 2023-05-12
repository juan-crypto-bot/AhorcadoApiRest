using System.Collections.Generic;
using System.Linq;

namespace AhorcadoApiRest
{

    public interface ILetterRepository
    {
        Letter Create(char value);
        Letter Read(char l);
        public Letter Update(char value);
        public void Delete(char value);
        public IEnumerable<Letter> GetAll();
    }

    public class SqlServerLetterRepository : ILetterRepository
    {

        private readonly HangedDbContext _db;
        public SqlServerLetterRepository(HangedDbContext db)
        {
            _db = db;
        }

        public Letter Create(char value)
        {
            var letter = new Letter(value);
            _db.Letter.Add(letter);
            _db.SaveChanges();
            return letter;
        }

        public Letter Read(char value)
        {
            return _db.Letter.ToList().Find(letter => letter.Value.ToString() == value.ToString().ToUpper());
        }

        public Letter Update(char value)
        {
            return new Letter();
        }

        public void Delete(char value)
        {
            var letter = this.Read(value);
            _db.Letter.Remove(letter);
            _db.SaveChanges();
        }

        public IEnumerable<Letter> GetAll()
        {
            return _db.Letter.ToList();
        }
    }
}