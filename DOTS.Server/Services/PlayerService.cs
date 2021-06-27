using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DOTS.Shared;

namespace DOTS.Server.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly Random _rng = new();
        private readonly ConcurrentDictionary<string, Player> _players = new();

        public Task<Player> AddPlayer(string connectionId)
        {
            var player = new Player
            {
                Id = Guid.NewGuid().ToString(),
                PositionX = 250,
                PositionY = 250,
                Color = $"#{_rng.Next(0x1000000):X6}"
            };

            if (!_players.TryAdd(connectionId, player))
            {
                throw new ArgumentException("Player can't be added");
            }

            return Task.FromResult(player);
        }

        public Task<Player> RemovePlayer(string connectionId)
        {
            if (!_players.TryRemove(connectionId, out var player))
            {
                throw new ArgumentException("Can't remove player");
            }

            return Task.FromResult(player);
        }

        public Task<Player> UpdatePosition(string connectionId, double positionX, double positionY)
        {
            if (!_players.TryGetValue(connectionId, out var player))
            {
                throw new ArgumentException("Can't update players position");
            }

            player.PositionX = positionX;
            player.PositionY = positionY;

            return Task.FromResult(player);
        }

        public Task<List<Player>> GetAllPlayers()
        {
            var players = _players.Select(kvp => kvp.Value).ToList();
            return Task.FromResult(players);
        }
    }
}