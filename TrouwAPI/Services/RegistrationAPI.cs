
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.Cosmos;
using System.Net;
using System.Text.Json;
using TrouwWebsiteAPI.Models;

namespace TrouwWebsiteAPI
{
    public class RegistrationAPI
    {
        private readonly ILogger _logger;
        private readonly CosmosClient _cosmosClient;
        private readonly Container _container;

        public RegistrationAPI(ILoggerFactory loggerFactory, CosmosClient cosmosClient)
        {
            _logger = loggerFactory.CreateLogger<RegistrationAPI>();
            _cosmosClient = cosmosClient;
            _container = _cosmosClient.GetContainer("TrouwDB", "Registrations");
        }

        [Function("SaveRegistration")]
        public async Task<HttpResponseData> SaveRegistration(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req)
        {
            _logger.LogInformation("Processing registration request.");

            try
            {
                // Read request body
                var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var registration = JsonSerializer.Deserialize<Registration>(requestBody, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (registration == null)
                {
                    var badResponse = req.CreateResponse(HttpStatusCode.BadRequest);
                    await badResponse.WriteStringAsync("Invalid registration data");
                    return badResponse;
                }

                // Save to Cosmos DB
                var result = await _container.CreateItemAsync(registration, new PartitionKey(registration.id));
                
                // Return success response
                var response = req.CreateResponse(HttpStatusCode.OK);
                response.Headers.Add("Content-Type", "application/json");
                await response.WriteStringAsync(JsonSerializer.Serialize(result.Resource));
                
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error saving registration");
                var errorResponse = req.CreateResponse(HttpStatusCode.InternalServerError);
                await errorResponse.WriteStringAsync("Error saving registration");
                return errorResponse;
            }
        }

        [Function("GetRegistrations")]
        public async Task<HttpResponseData> GetRegistrations(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequestData req)
        {
            _logger.LogInformation("Getting all registrations.");

            try
            {
                var query = new QueryDefinition("SELECT * FROM c");
                var iterator = _container.GetItemQueryIterator<Registration>(query);
                var results = new List<Registration>();

                while (iterator.HasMoreResults)
                {
                    var response = await iterator.ReadNextAsync();
                    results.AddRange(response.ToList());
                }

                var httpResponse = req.CreateResponse(HttpStatusCode.OK);
                httpResponse.Headers.Add("Content-Type", "application/json");
                await httpResponse.WriteStringAsync(JsonSerializer.Serialize(results));
                
                return httpResponse;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting registrations");
                var errorResponse = req.CreateResponse(HttpStatusCode.InternalServerError);
                await errorResponse.WriteStringAsync("Error getting registrations");
                return errorResponse;
            }
        }
    }
}