using System;
using System.Collections.Generic;
using System.Linq;

namespace AhorcadoApiRest
{

    public interface IPlayerRepository
    {
        Player Create(Player player);
        Player Read(Player player);
        Player Update(Player player, string newPass);
        void Delete(Player player);
        IEnumerable<Player> GetAll();
    }

    public class SqlServerPlayerRepository : IPlayerRepository
    {

        private readonly HangedDbContext _db;
        public SqlServerPlayerRepository(HangedDbContext db)
        {
            _db = db;
            _db.Database.EnsureCreated();
        }

        public Player Create(Player player)
        {
            _db.Player.Add(player);
            _db.SaveChanges();
            return player;
        }

        public Player Read(Player player)
        {
            return _db.Player.SingleOrDefault(player => player.Username == player.Username);
        }

        public Player Update(Player player, string newPass)
        {
            var playerToUpdate = this.Read(player);
            playerToUpdate.Password = newPass;
            _db.SaveChanges();
            return playerToUpdate;
        }

        public void Delete(Player player)
        {
            var playerToDelete = _db.Player.SingleOrDefault(player => player.Username == player.Username && player.Password == player.Password);
            _db.Player.Remove(playerToDelete);
            _db.SaveChanges();
        }

        public IEnumerable<Player> GetAll()
        {
            return _db.Player.ToList();
        }
    }
}