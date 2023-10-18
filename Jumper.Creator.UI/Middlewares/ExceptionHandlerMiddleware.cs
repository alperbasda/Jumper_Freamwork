using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Persistence.Models.Responses;
using Core.WebHelper.ControllerExtensions;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Jumper.Creator.UI.Middlewares;

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

    public async Task Invoke(HttpContext context, ITempDataProvider tempDataProvider)
    {
        //Todo Alper : Burdaki veri ES ye aksın.
        try
        {
            await _next(context);
        }
        catch (ValidationException error)
        {
            var errors = string.Join("<br/>", error.Errors.SelectMany(w => w.Errors?? new List<string>()));
            if (AjaxRequestExtension.IsAjaxRequest(context.Request))
            {
                await context.Response.WriteAsJsonAsync(Response<MessageResponse>.Fail(errors, 400));
                return;
            }

            var dict = new Dictionary<string, object>
            {
                { "Error", errors }
            };
            tempDataProvider.SaveTempData(context, dict);
            string refer = context.Request.Headers["Referer"]!;
            context.Response.Redirect(string.IsNullOrEmpty(refer) ? context.Request.Path : refer);
        }
        catch (BusinessException error)
        {
            if (AjaxRequestExtension.IsAjaxRequest(context.Request))
            {
                await context.Response.WriteAsJsonAsync(Response<MessageResponse>.Fail(error.Message, 400));
                return;
            }

            var dict = new Dictionary<string, object>
            {
                { "Error", error.Message }
            };
            tempDataProvider.SaveTempData(context, dict);
            string refer = context.Request.Headers["Referer"]!;
            context.Response.Redirect(string.IsNullOrEmpty(refer) ? context.Request.Path : refer);

        }
        catch (NotFoundException error)
        {
            if (AjaxRequestExtension.IsAjaxRequest(context.Request))
            {
                await context.Response.WriteAsJsonAsync(Response<MessageResponse>.Fail(error.Message, 400));
                return;
            }

            var dict = new Dictionary<string, object>
            {
                { "Error", error.Message }
            };
            tempDataProvider.SaveTempData(context, dict);
            context.Response.Redirect("/home/Index");
        }
        catch (AuthorizationException error)
        {
            if (AjaxRequestExtension.IsAjaxRequest(context.Request))
            {
                await context.Response.WriteAsJsonAsync(Response<MessageResponse>.Fail(error.Message, 400));
                return;
            }

            var dict = new Dictionary<string, object>
            {
                { "Error", error.Message }
            };
            tempDataProvider.SaveTempData(context, dict);
            context.Response.Redirect("/Auth/Login");

        }
        catch (Exception error)
        {
            if (AjaxRequestExtension.IsAjaxRequest(context.Request))
            {
                await context.Response.WriteAsJsonAsync(Response<MessageResponse>.Fail(error.Message, 400));
                return;
            }

            var dict = new Dictionary<string, object>
            {
                { "Error", error.Message }
            };
            tempDataProvider.SaveTempData(context, dict);
            string refer = context.Request.Headers["Referer"]!;
            context.Response.Redirect(string.IsNullOrEmpty(refer) ? context.Request.Path : refer);

        }

    }

}