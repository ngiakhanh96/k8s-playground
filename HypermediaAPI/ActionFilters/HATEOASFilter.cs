using System;
using System.Collections.Generic;
using HypermediaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Reflection;
using HypermediaAPI.Controllers;

namespace HypermediaAPI.ActionFilters
{
    public class HATEOASFilterAttribute : ActionFilterAttribute
    {
        private readonly string _methodName;

        public HATEOASFilterAttribute(string methodName)
        {
            _methodName = methodName;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            //TODO: Add parameter
            //TODO: Allows multiple Filter switcher in this constructor

            if (context.Controller is ControllerBase controllerBase)
            {

                var methods = context.Controller
                    .GetType()
                    .GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static)
                    .Where(p => string.Equals(p.Name, _methodName, StringComparison.Ordinal))
                    .ToArray();

                var chosenMethod = methods.Length switch
                {
                    1 => methods[0],
                    0 => throw new InvalidOperationException(
                        $"Cannot find {_methodName} method."),
                    _ => throw new InvalidOperationException(
                        $"Overloading the {_methodName} method is not supported.")
                };

                var parameters = chosenMethod.GetParameters();
                if (parameters.Length is not 0)
                {
                    throw new InvalidOperationException(
                        $"The method {_methodName} must have 0 argument.");
                }
                var links = chosenMethod.Invoke(controllerBase, null) as List<Link>;

                if (context.Result is ObjectResult {StatusCode: null or 200} contextResult)
                {
                    context.Result = new JsonResult(new HATEOASWrapper {Result = contextResult.Value, Links = links});
                }
            }

            base.OnActionExecuted(context);
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {

        }
    }
}
