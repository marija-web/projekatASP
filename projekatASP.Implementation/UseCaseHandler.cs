using Newtonsoft.Json;
using projekatASP.Application.Exceptions;
using projekatASP.Application.Logging;
using projekatASP.Application.UseCases;
using projekatASP.DataAccess;
using projekatASP.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatASP.Implementation
{
    public class UseCaseHandler
    {
        private IExceptionLogger _logger;
        private IApplicationUser _user;
        private IUseCaseLogger _useCaseLogger;
        private ProjekatDbContext _context;

        public UseCaseHandler(IExceptionLogger logger, IApplicationUser user, IUseCaseLogger useCaseLogger, ProjekatDbContext context)
        {
            _logger = logger;
            _user = user;
            _useCaseLogger = useCaseLogger;
            _context = context;
        }
        public TResponse HandleQuery<TRequest, TResponse>(IQuery<TRequest, TResponse> query, TRequest data)
        {
            try
            {
                HandleLoggingAndAuthorization(query, data);
                
                var stopwatch = new Stopwatch();
                stopwatch.Start();

                var response = query.Execute(data);

                stopwatch.Stop();

                Console.WriteLine(query.Name + " Duration: " + stopwatch.ElapsedMilliseconds + " ms.");

                return response;
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                    throw;
            }
        }

        public void HandleCommand<TRequest>(ICommand<TRequest> command, TRequest data)
        {
            try
            {
                HandleLoggingAndAuthorization(command, data);

                var stopwatch = new Stopwatch();
                stopwatch.Start();

                command.Execute(data);

                stopwatch.Stop();

                Console.WriteLine(command.Name + " Duration: " + stopwatch.ElapsedMilliseconds + " ms.");
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                throw;
            }
        }

        private void HandleLoggingAndAuthorization<TRequest>(IUseCase useCase, TRequest data)
        {
            var isAuthorized = _user.UseCaseIds.Contains(useCase.Id);

            var log = new UseCaseLog
            {
                User = _user.Identity,
                ExecutionDateTime = DateTime.UtcNow,
                UseCaseName = useCase.Name,
                UserId = _user.Id,
                Data = JsonConvert.SerializeObject(data),
                IsAuthorized = isAuthorized
            };

            var useCaseLog = new UseCaseLogs
            {
                UseCaseName = log.UseCaseName,
                UserId = log.UserId,
                ExecutionDateTime = log.ExecutionDateTime,
                Data = log.Data,
                IsAuthorized = log.IsAuthorized
            };

            _context.UseCaseLogs.Add(useCaseLog);
            _context.SaveChanges();

            _useCaseLogger.Log(log);

            if (!isAuthorized)
            {
                throw new ForbiddenUseCaseExecutionE(useCase.Name, _user.Identity);
            }
        }
    }
}
