using System;
using System.Web.Http;
using Tasks.Data.Commands;
using Tasks.Data.Models;
using Tasks.Data.Queries;

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