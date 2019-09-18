using System;
using Grpc.Net.Client;
using Grpc.Net;
using Grpc.Core;
using CounterService;
using System.Threading.Tasks;

namespace GrpcTestConsoleClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            var channel = GrpcChannel.ForAddress("http://localhost:8888", new GrpcChannelOptions()
            {
                Credentials = ChannelCredentials.Insecure
            });

            var client = new CounterGrpcService.CounterGrpcServiceClient(channel);
            var value = await client.GetCurrentAsync(new Google.Protobuf.WellKnownTypes.Empty());
            Console.WriteLine("current value:" + value);
            Console.WriteLine("Hello World!");
        }
    }
}
