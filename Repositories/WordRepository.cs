using System;
using System.Collections.Generic;
using System.Linq;

namespace AhorcadoApiRest
{

    public interface IWordRepository
    {
        Word Create(IEnumerable<Letter> meaning);
        Word Read(IEnumerable<Letter> meaning);
        Word Update(string meaning);
        void Delete(IEnumerable<Letter> meaning);
        IEnumerable<Word> GetAll();
        Word SelectRandomWord();
    }

    public class SqlServerWordRepository : IWordRepository
    {

        private readonly HangedDbContext _db;
        public SqlServerWordRepository(HangedDbContext db)
        {
            _db = db;
        }

        public Word Create(IEnumerable<Letter> meaning)
        {
            var word = new Word(meaning);
            _db.Word.Add(word);
            _db.SaveChanges();
            return word;
        }

        public Word Read(IEnumerable<Letter> meaning)
        {
            return _db.Word.SingleOrDefault(word => word.Letters == meaning.ToList());
        }

        public Word Update(string meaning)
        {
            return new Word();
        }

        public void Delete(IEnumerable<Letter> meaning)
        {
            var word = this.Read(meaning);
            _db.Word.Remove(word);
            _db.SaveChanges();
        }

        public IEnumerable<Word> GetAll()
        {
            return _db.Word.ToList();
        }

        public Word SelectRandomWord()
        {
            return _db.Word.OrderBy(o => Guid.NewGuid()).FirstOrDefault();
        }

    }
}
