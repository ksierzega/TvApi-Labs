using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using NLog;
using TvApi_Lab.Common;

namespace TvApi_Lab.Filters
{
    public class TvApiExceptionFilterAttribute: ExceptionFilterAttribute
    {
        protected static readonly Logger Nlog = LogManager.GetCurrentClassLogger();

        public override Task OnExceptionAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            if (actionExecutedContext.Exception is TvApiException)
            {
                actionExecutedContext.Response =
                    actionExecutedContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                        actionExecutedContext.Exception.Message);
            }

            return null;
        }
    }
}