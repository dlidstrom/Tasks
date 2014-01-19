using Tasks.Data.Models;

namespace Tasks.Data.Commands
{
    public interface ICommand
    {
        void Execute(IDbContext context);
    }
}