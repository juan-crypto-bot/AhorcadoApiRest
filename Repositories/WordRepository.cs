using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AhorcadoApiRest
{

    public interface IWordRepository
    {
        Word Create(Word word);
        Word Read(Word word);
        void Delete(Word word);
        IEnumerable<Word> GetAll();
        Word SelectRandomWord();
        Word EmptyList(Word word);
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
            return _db.Word.Include(w => w.Letters).Single(w => w.Meaning == word.Meaning);
        }

        public void Delete(Word word)
        {
            Word wordToDelete = this.Read(word);
            _db.Word.Remove(wordToDelete);
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

        public Word EmptyList(Word word)
        {
            Word wordToEmpty = this.Read(word);
            wordToEmpty.Letters.Clear();
            _db.Word.Update(wordToEmpty);
            _db.SaveChanges();
            return wordToEmpty;
        }

    }
}
