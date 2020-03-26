using System;
using System.Threading.Tasks;
using Amazon.SimpleSystemsManagement;
using Amazon.SimpleSystemsManagement.Model;

namespace ParameterConfigAWS
{
    class Program
    {
        static void Main(string[] args)
        {
            GetConfiguration().Wait();
        }

        static async Task GetConfiguration()
        {
            var region = Amazon.RegionEndpoint.USEast1;
            var request = new GetParameterRequest()
            {
                Name = "/TestParamStore/EnvName"
            };

            using (var client = new AmazonSimpleSystemsManagementClient(region))
            {
                try
                {
                    var response = await client.GetParameterAsync(request);
                    Console.WriteLine($"Parameter {request.Name} value is: {response.Parameter.Value}");
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"Error: {ex.Message}");
                }
            }
        
        } 
    }
    
}