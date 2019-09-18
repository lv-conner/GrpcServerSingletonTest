using CounterService;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GrpcWorkerServiceHost
{
    public class CounterService:CounterGrpcService.CounterGrpcServiceBase
    {
        private int Current = 0;
        public override Task<CounterResponse> GetCurrent(Empty request, ServerCallContext context)
        {
            Current++;
            var reply = new CounterResponse() { Value = Current };
            return Task.FromResult(reply);
        }
    }
}
