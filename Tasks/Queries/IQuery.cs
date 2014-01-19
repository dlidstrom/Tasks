using Tasks.Models;

namespace Tasks.Queries
{
    public interface IQuery<out TResult>
    {
        TResult Execute(IDbContext context);
    }
}