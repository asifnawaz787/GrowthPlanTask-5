using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApplication9.ProblemFactory
{
    public class ExternalDependancyExceptionFilter: IActionFilter, IOrderedFilter
    {
        public int Order => int.MaxValue-10;

        

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if(context.Exception is ExceptionFilter exceptionFilter)
            {
                context.Result = new ObjectResult(exceptionFilter._value)
                {
                    StatusCode = (int)exceptionFilter._statusCode
                };
                context.ExceptionHandled = true;
            }
           


        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
