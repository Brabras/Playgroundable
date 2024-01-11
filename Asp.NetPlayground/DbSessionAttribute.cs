using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Asp.NetPlayground;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
public sealed class DbSessionAttributeActionFilter : Attribute, IAsyncActionFilter, IEndpointFilter
{
    public DbSessionAttributeActionFilter()
    {
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context,
                                             ActionExecutionDelegate next)
    {
        if (!context.ActionDescriptor.IsControllerAction())
        {
            await next();
            return;
        }

        var methodInfo = context.ActionDescriptor.GetMethodInfo();
        var attributes = methodInfo.GetCustomAttributes(typeof(DbSessionAttributeActionFilter), false);
        var attribute1 = attributes.FirstOrDefault();

        var attribute2 = AttributeProvider<DbSessionAttributeActionFilter>.FirstOrDefault(context.ActionDescriptor.GetMethodInfo());

        if (attribute2 == null)
        {
            await next();
            return;
        }

        // some action

        await next();
    }

    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        // some action
        Console.WriteLine("Filter works");
        return await next(context);
    }
}