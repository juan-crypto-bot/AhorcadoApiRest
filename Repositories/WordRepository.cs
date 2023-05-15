using System;
using System.Collections.Generic;
using System.Linq;

namespace AhorcadoApiRest
{

    public interface IWordRepository
    {
        Word Create(Word word);
        Word Read(Word word);
        Word Update(Word word);
        void Delete(Word word);
        IEnumerable<Word> GetAll();
        Word SelectRandomWord();
    }

    public class SqlServerWordRepository : IWordRepository
    {

        private readonly HangedDbContext _db;
        public SqlServerWordRepository(HangedDbContext db)
        {
            _db = db;
            _db.Database.EnsureCreated();
        }

        public Word Create(Word word)
        {
            _db.Word.Add(word);
            _db.SaveChanges();
            return word;
        }

        public Word Read(Word word)
        {
            return _db.Word.Single(w => w.Id == word.Id);
        }

        public Word Update(Word word)
        {
            var wordToUpdate = this.Read(word);
            wordToUpdate.Letters = word.Letters;
            _db.SaveChanges();
            return wordToUpdate;
        }

        public void Delete(Word word)
        {
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
