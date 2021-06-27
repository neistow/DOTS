using System.Threading.Tasks;

namespace DOTS.Shared
{
    public interface IGameClient
    {
        Task ReceiveSelf(Player player);
        Task PlayerJoined(Player player);
        Task PlayerLeft(Player player);
        Task PlayerPositionUpdated(Player player);
    }
}