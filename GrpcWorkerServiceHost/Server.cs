using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static CounterService.CounterGrpcService;

namespace OrderGrpcServiceWorkerServiceHost
{
    public class Server
    {
        private CounterGrpcServiceBase _counterGrpcServiceBase;

        public Server(CounterGrpcServiceBase counterGrpcServiceBase)
        {
            _counterGrpcServiceBase = counterGrpcServiceBase;
        }

        private Grpc.Core.Server _grpcServer;

        const int Port = 50051;


        public async Task Start()
        {
            try
            {
                _grpcServer = new Grpc.Core.Server
                {
                    Services = { BindService(_counterGrpcServiceBase) },

                    Ports = { new ServerPort("localhost", 8888, ServerCredentials.Insecure) }

                };
                _grpcServer.Start();

                Console.WriteLine($"Order server listening on port 8888");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception encountered: {ex}");
            }
        }

        public async Task Stop()
        {
            await _grpcServer.ShutdownAsync();
        }
    }
}
