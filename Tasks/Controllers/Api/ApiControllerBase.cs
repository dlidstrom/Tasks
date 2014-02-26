using System;
using System.Threading.Tasks;
using System.Web.Http;
using Tasks.Data.Commands;
using Tasks.Data.Models;
using Tasks.Data.Queries;

namespace Tasks.Controllers.Api
{
    public abstract class ApiControllerBase : ApiController
    {
        public IDbContext Context { get; set; }

        protected async Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query)
        {
            return await query.ExecuteAsync(Context);
        }

        protected async void ExecuteCommand(ICommand command)
        {
            if (command == null) throw new ArgumentNullException("command");
            await command.Execute(Context);
        }
    }
}