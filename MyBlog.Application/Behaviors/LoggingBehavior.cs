using MediatR;
using Microsoft.Extensions.Logging;

namespace MyBlog.Application.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogError($"{typeof(TRequest).Name} Request before execution");

                return await next();
            }
            finally
            {
                _logger.LogError($"{typeof(TRequest).Name} after execution");
            }
        }
    }
}
