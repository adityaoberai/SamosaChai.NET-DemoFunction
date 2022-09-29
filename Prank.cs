using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Twilio;
using Twilio.Rest.Api.V2010;
using Twilio.Rest.Api.V2010.Account;

namespace My.Function
{
    public class Prank
    {
        private readonly ILogger _logger;

        public Prank(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Prank>();
        }

        [Function("Prank")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function runs");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            //response.WriteString("Welcome to SamosaChai.NET!");

            var body = await new StreamReader(req.Body).ReadToEndAsync();

            var requestBody = JsonConvert.DeserializeObject<dynamic>(body);

            string number = requestBody?.PhoneNumber;

            var accountSid = Environment.GetEnvironmentVariable("AccountSid");
            var authToken = Environment.GetEnvironmentVariable("AuthToken");
            var fromPhoneNumber = Environment.GetEnvironmentVariable("FromNumber");

            TwilioClient.Init(accountSid, authToken);

            var call = CallResource.Create(
                from: new Twilio.Types.PhoneNumber(fromPhoneNumber),
                to: new Twilio.Types.PhoneNumber(number),
                twiml: new Twilio.Types.Twiml("<Response><Play>https://demo.twilio.com/docs/classic.mp3</Play></Response>")
            );

            response.WriteString(call.Sid);

            return response;
        }
    }
}
