using System.Diagnostics;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using NLog;

namespace TvApi_Lab.Filters
{
    public class ExecutionTimeAttribute : ActionFilterAttribute
    {
        private const string StopwatchKey = "StopwatchKey";

        protected static readonly Logger Nlog = LogManager.GetCurrentClassLogger();

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            actionContext.Request.Properties.Add(StopwatchKey, Stopwatch.StartNew());
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Request.Properties.ContainsKey(StopwatchKey))
            {
                Stopwatch sw = ((Stopwatch)actionExecutedContext.Request.Properties[StopwatchKey]);
                sw.Stop();
                long elapsedMilliseconds = sw.ElapsedMilliseconds;
                actionExecutedContext.Response.Headers.Add("Elapsed-Time", elapsedMilliseconds.ToString());

                var message = $"Elapsed time: {elapsedMilliseconds} ms, {actionExecutedContext.Request.Method} {actionExecutedContext.Request.RequestUri}";
                Nlog.Info(message);
            }
        }
    }
}