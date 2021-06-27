using System;
using System.Threading.Tasks;
using DOTS.Server.Services;
using DOTS.Shared;
using Microsoft.AspNetCore.SignalR;

namespace DOTS.Server.Hubs
{
    public class GameHub : Hub<IGameClient>, IGameHub
    {
        private readonly IPlayerService _playerService;

        public GameHub(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        public override async Task OnConnectedAsync()
        {
            var player = await _playerService.AddPlayer(Context.ConnectionId);
            
            await Clients.Caller.ReceiveSelf(player);
            await Clients.Others.PlayerJoined(player);
        }

        public async Task UpdatePosition(double newX, double newY)
        {
            var player = await _playerService.UpdatePosition(Context.ConnectionId, newX, newY);
            await Clients.Others.PlayerPositionUpdated(player);
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var player = await _playerService.RemovePlayer(Context.ConnectionId);
            await Clients.Others.PlayerLeft(player);
        }
    }
}