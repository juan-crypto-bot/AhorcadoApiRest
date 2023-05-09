using System;
using System.Collections.Generic;
using System.Linq;

namespace AhorcadoApiRest
{

    public interface IWordRepository
    {
        void Add(Word word);
        Word SelectRandomWord();

        Word CreateWord(IEnumerable<Letter> letters);
    }

    public class SqlServerWordRepository : IWordRepository
    {

        private readonly HangedDbContext _db;
        public SqlServerWordRepository(HangedDbContext db)
        {
            _db = db;
        }
        public void Add(Word word)
        {
            _db.Word.Add(word);
            _db.SaveChanges();
        }
        public Word SelectRandomWord()
        {
            return _db.Word.OrderBy(o => Guid.NewGuid()).FirstOrDefault();
        }
        public Word CreateWord(IEnumerable<Letter> letters)
        {
            var word = new Word(letters);
            _db.Word.Add(word);
            _db.SaveChanges();
            return word;
        }
    }
}
