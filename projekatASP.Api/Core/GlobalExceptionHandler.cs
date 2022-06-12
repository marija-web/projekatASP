using Microsoft.AspNetCore.Http;
using projekatASP.Application.Exceptions;
using projekatASP.Application.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using ValidationException = FluentValidation.ValidationException;

namespace projekatASP.Api.Core
{
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _request;
        private readonly IExceptionLogger _logger;

        public GlobalExceptionHandler(RequestDelegate next, IExceptionLogger logger)
        {
            _request = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _request(httpContext);
            }
            catch (System.Exception ex)
            {
                _logger.Log(ex);

                httpContext.Response.ContentType = "application/json";
                object response = null;
                var statusCode = StatusCodes.Status500InternalServerError;

                if (ex is ForbiddenUseCaseExecutionE)
                {
                    statusCode = StatusCodes.Status403Forbidden;
                }

                if (ex is ForbiddenUseCaseExecutionE)
                {
                    statusCode = StatusCodes.Status404NotFound;
                }

                if (ex is ValidationException e)
                {
                    statusCode = StatusCodes.Status422UnprocessableEntity;
                    response = new
                    {
                        errors = e.Errors.Select(x => new
                        {
                            property = x.PropertyName,
                            error = x.ErrorMessage
                        })
                    };
                }

                if (ex is ContextConflictE conflictEx)
                {
                    statusCode = StatusCodes.Status409Conflict;
                    response = new { message = conflictEx.Message };
                }


                httpContext.Response.StatusCode = statusCode;
                if (response != null)
                {
                    await httpContext.Response.WriteAsJsonAsync(response);
                }
            }
        }
    }
}
