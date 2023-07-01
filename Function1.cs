using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EncryptAPI
{
    public static class Function1
    {
        [FunctionName("EncryptAPI")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            string responseMessage = null;
            if (req.Method == "GET")
            {
                responseMessage = "get recebido e API Rodando";
            }else if (req.Method == "POST")
            {
                Encryptmsg encryptMsg = new Encryptmsg("teste de mensagem");
                responseMessage = $"A API recebeu seu Post vindo de {req.HttpContext.Connection.RemoteIpAddress}";
            }
            return new OkObjectResult(responseMessage);
        }
        //public static async Task<IActionResult> RunPost (
        //    [HttpTrigger(authLevel: AuthorizationLevel.Anonymous, methods:"post", Route =null)] HttpRequest req,
        //    ILogger log)
        //{
        //    log.LogInformation("C# HTTP Trigger Function processed a post.");
        //    string responseMessage = $"A Api recebeu seu Post de {req.Host.ToString()}";
        //    return new OkObjectResult(responseMessage);
        //}
    }
}
