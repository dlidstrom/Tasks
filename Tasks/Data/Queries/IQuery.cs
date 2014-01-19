using Tasks.Data.Models;

namespace Tasks.Data.Queries
{
    public interface IQuery<out TResult>
    {
        TResult Execute(IDbContext context);
    }
}