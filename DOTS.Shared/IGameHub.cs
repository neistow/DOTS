using System.Threading.Tasks;

namespace DOTS.Shared
{
    public interface IGameHub
    {
        Task UpdatePosition(double newX, double newY);
    }
}