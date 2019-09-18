using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using OrderGrpcServiceWorkerServiceHost;

namespace GrpcWorkerServiceHost
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private Server _server;
        public Worker(Server server, ILogger<Worker> logger)
        {
            _logger = logger;
            _server = server;
        }

        protected  async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _server.Start();
        }
        public async override Task StopAsync(CancellationToken cancellationToken)
        {
            await _server.Stop();
        }
    }
}
