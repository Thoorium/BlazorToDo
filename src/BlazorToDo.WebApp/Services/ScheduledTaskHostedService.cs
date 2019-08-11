using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BlazorToDo.WebApp.Services
{
    public class ScheduledTaskHostedService : IHostedService, IDisposable
    {
        private readonly ILogger _logger;
        private Timer _timer;

        public IServiceProvider Services { get; }

        public ScheduledTaskHostedService(IServiceProvider services, ILogger<ScheduledTaskHostedService> logger)
        {
            Services = services;
            _logger = logger;
        }
        public void Dispose()
        {
            _timer?.Dispose();
        }

        private void DoWork(object state)
        {
            _logger.LogInformation("Timed Background Service is working.");

            using (var scope = Services.CreateScope())
            {
                IToDoUpdateService toDoUpdateService = scope.ServiceProvider.GetService<IToDoUpdateService>();
                toDoUpdateService.ProcessQueue();
            }
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Timed Background Service is starting.");

            _timer = new Timer(DoWork, null, TimeSpan.Zero, 
                TimeSpan.FromMilliseconds(500)); // Triggers every .5 seconds

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Timed Background Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }
    }
}