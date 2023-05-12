using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AhorcadoApiRest
{
    public interface IPlayerService
    {
        Player CreatePlayer(string user, string pass);
        Player ReadPlayer(string user);
        Player UpdatePlayer(string user, string pass);
        void DeletePlayer(string user, string pass);
        IEnumerable<Player> GetAllPlayers();
    }
    public class PlayerService : IPlayerService
    {

        private readonly ILogger<PlayerService> _logger;

        private readonly IPlayerRepository _playerRepository;
        public PlayerService(ILogger<PlayerService> logger, IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
            _logger = logger;
        }

        public Player CreatePlayer(string user, string pass)
        {
            return _playerRepository.Create(user, pass);
        }
        public Player ReadPlayer(string user)
        {
            return _playerRepository.Read(user);
        }
        public Player UpdatePlayer(string user, string pass)
        {
            return _playerRepository.Update(user, pass);

        }
        public void DeletePlayer(string user, string pass)
        {
            _playerRepository.Delete(user, pass);
        }
        public IEnumerable<Player> GetAllPlayers()
        {
            return _playerRepository.GetAll();
        }
    }
}
