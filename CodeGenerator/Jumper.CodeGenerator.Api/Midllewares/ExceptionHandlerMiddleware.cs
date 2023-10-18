using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Persistence.Models.Responses;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Jumper.CodeGenerator.Api.Midllewares;

public static class ExceptionHandlerMiddlewareExtension
{
    #region For Use

    public static IApplicationBuilder UseExceptionHandlerMiddleware(this IApplicationBuilder app)
    {
        return app.UseMiddleware<ExceptionHandlerMiddleware>();
    }

    #endregion
}
public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        //Todo Alper : Burdaki veri ES ye aksın.
        try
        {
            await _next(context);
        }
        catch (ValidationException error)
        {
            var errors = string.Join("<br/>", error.Errors.SelectMany(w => w.Errors ?? new List<string>()));
            await context.Response.WriteAsJsonAsync(Response<MessageResponse>.Fail(errors, 400));
        }
        catch (BusinessException error)
        {
            await context.Response.WriteAsJsonAsync(Response<MessageResponse>.Fail(error.Message, 400));

        }
        catch (NotFoundException error)
        {
            await context.Response.WriteAsJsonAsync(Response<MessageResponse>.Fail(error.Message, 404));
        }
        catch (AuthorizationException error)
        {
            await context.Response.WriteAsJsonAsync(Response<MessageResponse>.Fail(error.Message, 403));
        }
        catch (Exception error)
        {
            await context.Response.WriteAsJsonAsync(Response<MessageResponse>.Fail(error.Message, 400));
        }
    }

}