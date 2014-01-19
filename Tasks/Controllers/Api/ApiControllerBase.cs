using System;
using System.Web.Http;
using Tasks.Commands;
using Tasks.Models;
using Tasks.Queries;

namespace Tasks.Controllers.Api
{
    public abstract class ApiControllerBase : ApiController
    {
        public IDbContext Context { get; set; }

        protected TResult ExecuteQuery<TResult>(IQuery<TResult> query)
        {
            return query.Execute(Context);
        }

        protected void ExecuteCommand(ICommand command)
        {
            if (command == null) throw new ArgumentNullException("command");
            command.Execute(Context);
        }
    }
}