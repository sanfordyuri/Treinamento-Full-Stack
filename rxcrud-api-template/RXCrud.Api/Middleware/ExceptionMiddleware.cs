﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using RXCrud.Domain.Exception;
using System.Net;

namespace RXCrud.Api.Middleware
{
    public static class ExceptionMiddleware
    {
        public static void UseExceptionHandlerCuston(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        if (contextFeature.Error is RXCrudException)
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                            context.Response.ContentType = "application/json";
                            await context.Response.WriteAsync(JsonConvert.SerializeObject(new ExceptionMessage(contextFeature.Error.Message)));
                        }
                        else
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                            context.Response.ContentType = "application/json";
                            await context.Response.WriteAsync(JsonConvert.SerializeObject(new ExceptionMessage("Erro interno no servidor ao processar a solicitação." + contextFeature.Error.Message)));
                        }
                    }
                });
            });
        }
    }
}