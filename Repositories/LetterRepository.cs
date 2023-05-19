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
        IEnumerable<Letter> GetLettersByIdWord(int id);
        void Discovery(Letter letter);
        void UpdateIdWord(Letter letter);
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
            return _db.Letter.Single(l => l.Id == letter.Id && l.Value == letter.Value);
        }

        public void Delete(Letter letter)
        {
            var letterToDelete = this.Read(letter);
            _db.Letter.Remove(letterToDelete);
            _db.SaveChanges();
        }

        public IEnumerable<Letter> GetAll()
        {
            return _db.Letter.ToList();
        }

        public IEnumerable<Letter> GetLettersByIdWord(int id)  //Se crea porque no hay navegacion del tipo Hanged.Word.Letters
        {
            return _db.Letter.Where(l => l.IdWord == id);
        }
        public void Discovery(Letter letter)
        {
            Letter let = this.Read(letter);
            let.IsGuessed = true;
            _db.Update(let);
            _db.SaveChanges();
        }

        public void UpdateIdWord(Letter letter)
        {
            Letter let = this.Read(letter);
            _db.Update(let);
            _db.SaveChanges();
        }
    }
}