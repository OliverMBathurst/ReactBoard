using System.Threading.Tasks;

namespace ReactBoard.Domain.Common
{
    public interface IHasStatistic<TStatistic>
    {
        Task<TStatistic> GetStatisticAsync();
    }
}