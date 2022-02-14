using Grpc.Net.Client;
using gRPC_Client_Server;
using System;
using System.Threading.Tasks;

namespace gRPC_Client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //Console.WriteLine("press any key to cont. ");
            //Console.ReadLine();
            //var input = new HelloRequest
            //{
            //    Name = "BADER"
            //};
            //using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            //var client = new Greeter.GreeterClient(channel);
            //var reply = await client.SayHelloAsync(input);
            //Console.WriteLine($"Greetings : {reply.Message}");
            //Console.WriteLine("press any key to exit");
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var CustomerClient = new Customer.CustomerClient(channel);
            var clientRequested = new CustomerLookUpModel { UserId = 2 };
            var customer = await CustomerClient.GetCustomerInfoAsync(clientRequested);
            Console.WriteLine($"{customer.FirstName} {customer.LastName}");
            Console.ReadLine();
        }
    }
}
