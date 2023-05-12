using System;
using System.Collections.Generic;
using System.Linq;

namespace AhorcadoApiRest
{

    public interface IPlayerRepository
    {
        Player Create(string user, string pass);
        Player Read(string user);
        Player Update(string user, string pass);
        void Delete(string user, string pass);
        IEnumerable<Player> GetAll();
        Player FindPlayerById(int id);
    }

    public class SqlServerPlayerRepository : IPlayerRepository
    {

        private readonly HangedDbContext _db;
        public SqlServerPlayerRepository(HangedDbContext db)
        {
            _db = db;
        }

        public Player Create(string user, string pass)
        {
            var player = new Player(user, pass);
            _db.Player.Add(player);
            _db.SaveChanges();
            return player;
        }

        public Player Read(string user)
        {
            return _db.Player.SingleOrDefault(player => player.Username == user);
        }

        public Player Update(string user, string pass)
        {
            return new Player();
        }

        public void Delete(string user, string pass)
        {
            var player = _db.Player.SingleOrDefault(player => player.Username == user && player.Password == pass);
            _db.Player.Remove(player);
            _db.SaveChanges();
        }

        public IEnumerable<Player> GetAll()
        {
            return _db.Player.ToList();
        }

        public Player FindPlayerById(int id)
        {
            return _db.Player.SingleOrDefault(p => p.Id == id);
        }
    }
}