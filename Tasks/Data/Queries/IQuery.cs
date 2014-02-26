using System.Threading.Tasks;
using Tasks.Data.Models;

namespace Tasks.Data.Queries
{
    public interface IQuery<TResult>
    {
        Task<TResult> ExecuteAsync(IDbContext context);
    }
}