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

        protected Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query)
        {
            return query.ExecuteAsync(Context);
        }

        protected Task ExecuteCommand(ICommand command)
        {
            if (command == null) throw new ArgumentNullException("command");
            return command.Execute(Context);
        }
    }
}