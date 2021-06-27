using System.Collections.Generic;
using System.Threading.Tasks;
using DOTS.Shared;

namespace DOTS.Server.Services
{
    public interface IPlayerService
    {
        Task<Player> AddPlayer(string connectionId);
        Task<Player> RemovePlayer(string connectionId);
        Task<Player> UpdatePosition(string connectionId, double positionX, double positionY);
        Task<List<Player>> GetAllPlayers();
    }
}