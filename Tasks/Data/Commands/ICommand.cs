using System.Threading.Tasks;
using Tasks.Data.Models;

namespace Tasks.Data.Commands
{
    public interface ICommand
    {
        Task Execute(IDbContext context);
    }
}