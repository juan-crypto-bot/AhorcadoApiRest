using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AhorcadoApiRest
{
    public interface IPlayerService
    {
        Player CreatePlayer(PlayerDTO playerDTO);
        Player ReadPlayer(PlayerDTO playerDTO);
        Player UpdatePlayer(PlayerDTO playerDTO, string newPass);
        void DeletePlayer(PlayerDTO playerDTO);
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

        public Player CreatePlayer(PlayerDTO playerDTO)
        {
            Player player = new Player(playerDTO);
            return _playerRepository.Create(player);
        }
        public Player ReadPlayer(PlayerDTO playerDTO)
        {
            Player player = new Player(playerDTO);
            return _playerRepository.Read(player);
        }
        public Player UpdatePlayer(PlayerDTO playerDTO, string newPass)
        {
            Player player = new Player(playerDTO);
            return _playerRepository.Update(player, newPass);

        }
        public void DeletePlayer(PlayerDTO playerDTO)
        {
            Player player = new Player(playerDTO);
            _playerRepository.Delete(player);
        }
        public IEnumerable<Player> GetAllPlayers()
        {
            return _playerRepository.GetAll();
        }
    }
}
