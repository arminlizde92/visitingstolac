using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using VisitingStolac.Common;

namespace VisitingStolac.API.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExceptionHandlingMiddleware
    {
        /// <summary>
        /// private readonly instance of request delegate
        /// </summary>
        private readonly RequestDelegate _next;

        /// <summary>
        /// private readonly instance of logger
        /// </summary>
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        /// <summary>
        /// Exception handling middleware constructor
        /// </summary>
        /// <param name="next">instance of <see cref="RequestDelegate"/></param>
        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        /// <summary>
        /// When exceptions is catched this method is invoked async
        /// </summary>
        /// <param name="httpContext">instance of <see cref="HttpContext"/></param>
        /// <returns>exception or new task</returns>
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            // catch different exceptions TODO: moze li se da se ne ponavljaju ovo linije 
            catch (KeyNotFoundException ex)
            {
                _logger.LogError(ex.Message, ex);
                httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                await HandleExceptionAsync(httpContext, ex);
            }
            catch (KeyAlreadyExistsException ex)
            {
                _logger.LogError(ex.Message, ex);
                httpContext.Response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                await HandleExceptionAsync(httpContext, ex);
            }
            catch (FileNotFoundException ex)
            {
                _logger.LogError(ex.Message, ex);
                httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                await HandleExceptionAsync(httpContext, ex);
            }
            catch (DirectoryNotFoundException ex)
            {
                _logger.LogError(ex.Message, ex);
                httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                await HandleExceptionAsync(httpContext, ex);
            }
            catch (NullReferenceException ex)
            {
                _logger.LogError(ex.Message, ex);
                httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await HandleExceptionAsync(httpContext, ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        /// <summary>
        /// Exception handling logic
        /// </summary>
        /// <param name="context">instance of <see cref="HttpContext"/></param>
        /// <param name="ex">instnace of <see cref="Exception"/></param>
        /// <returns></returns>
        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";

            return context.Response.WriteAsync(new ErrorDetailsDto()
            {
                StatusCode = context.Response.StatusCode,
                Message = ex.Message
            }.ToString());
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ExceptionHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}
