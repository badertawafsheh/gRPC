using Grpc.Core;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace gRPC_Client_Server.Services
{
    public class CustomerService : Customer.CustomerBase
    {
        private readonly ILogger<CustomerService> _logger;

        public CustomerService(ILogger<CustomerService> logger)
        {
            _logger = logger;
        }
               public override Task<customerModel> GetCustomerInfo(CustomerLookUpModel request, ServerCallContext context)
        {
            customerModel output = new customerModel();
            if (request.UserId == 1)
            {
                output.FirstName = "Bader";
                output.LastName = "Tawafsheh";
            }
            else if (request.UserId == 2)
            {
                output.FirstName = "Nader";
                output.LastName = "Emad";
            }
            else
            {
                output.FirstName = "yousef";
                output.LastName = "Tawafheh";
            }
            return Task.FromResult(output);
        }
    }
        public override async Task GetNewCustomers(newCustomerRequest request,IServerStreamWriter<customerModel> responseStream, ServerCallContext context)
        {
        List<customerModel> customers = new List<customerModel>
        {
            new customerModel{
                FirstName ="bader",
                LastName ="Tawafsheh" ,
                EmailAddress="bader.tawafsheh@exalt.ps",
                Age=22,
                IsAlive=true,
            },
             new customerModel{
                FirstName ="nader",
                LastName ="Tawafsheh" ,
                EmailAddress="nader.tawafsheh@gmail.com",
                Age=23,
                IsAlive=true,
            },
        };
        foreach (var customer in customers)
        {
            await responseStream.WriteAsync(customer);

        }
    }



    }
