using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AhorcadoApiRest
{

    public interface IHangedRepository
    {
        Hanged CreateHanged(Player player, Word word);
        IEnumerable<Hanged> GetAll();
        Hanged FindById(int id);
        bool Delete(int id);
    }

    public class SqlServerHangedRepository : IHangedRepository
    {

        private readonly HangedDbContext _db;
        public SqlServerHangedRepository(HangedDbContext db)
        {
            _db = db;
        }
        public Hanged CreateHanged(Player player, Word word)
        {
            var hanged = new Hanged(player, word);
            _db.Hanged.Add(hanged);
            _db.SaveChanges();
            return hanged;
        }

        public IEnumerable<Hanged> GetAll()
        {
            //Console.WriteLine("hola");
            return _db.Hanged.ToList();
        }

        public Hanged FindById(int id)
        {
            Hanged hang = _db.Hanged.Include("Player.Hang.Word").SingleOrDefault(h => h.Id == id);
            return hang;
        }

        public bool Delete(int id)
        {
            var hanged = _db.Hanged.SingleOrDefault(h => h.Id == id);
            if (hanged != null)
            {
                _db.Hanged.Remove(hanged);
                _db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}