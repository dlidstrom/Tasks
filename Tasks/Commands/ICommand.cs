using Tasks.Models;

namespace Tasks.Commands
{
    public interface ICommand
    {
        void Execute(IDbContext context);
    }
}