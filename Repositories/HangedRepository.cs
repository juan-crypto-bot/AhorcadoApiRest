using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AhorcadoApiRest
{

    public interface IHangedRepository
    {
        Hanged Create(Player player, Word word);
        Hanged Read(int id);
        Hanged Update(int id);
        void Delete(int id);
        IEnumerable<Hanged> GetAllHangeds();

    }

    public class SqlServerHangedRepository : IHangedRepository
    {

        private readonly HangedDbContext _db;
        public SqlServerHangedRepository(HangedDbContext db)
        {
            _db = db;
            _db.Database.EnsureCreated();
        }
        public Hanged Create(Player player, Word word)
        {
            var hanged = new Hanged(player, word);
            _db.Hanged.Add(hanged);
            _db.SaveChanges();
            return hanged;
        }

        public Hanged Read(int id)
        {
            return _db.Hanged.SingleOrDefault(h => h.Id == id);
        }

        public Hanged Update(int id)
        {
            return new Hanged();
        }

        public void Delete(int id)
        {
            var hanged = this.Read(id);
            _db.Hanged.Remove(hanged);
            _db.SaveChanges();
        }

        public IEnumerable<Hanged> GetAllHangeds()
        {
            return _db.Hanged.ToList();
        }
    }
}