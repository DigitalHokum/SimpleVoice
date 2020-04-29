using System;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using SimpleVoice.Abstract;
using SimpleVoice.Handlers;

namespace TheTrailNorth
{
    [RegisterHandler("LaunchRequest")]
    public class LaunchRequest : RequestHandler
    {
        public override ResponseAbstract Handle(RequestAbstract request)
        {
            ResponseAbstract response = request.BuildResponseObject();
            response.Speech = "Welcome to The Trail North.";
            response.Reprompt = "Say something that you would like repeated.";
            
            return response;
        }
    }
    
    [RegisterHandler("RelayIntent",
        new[] {
            "Do something with the {speech}",
            "Test the test with the {speech}"
        })]
    public class RelayHandler : RequestHandler
    {
        [HandlerParam("AMAZON.SearchQuery", "speech")]
        public string Speech;

        public override ResponseAbstract Handle(RequestAbstract request)
        {
            ResponseAbstract response = request.BuildResponseObject();

            response.Speech = Speech;
            response.Reprompt = "Say something that you would like repeated.";
            
            AmazonDynamoDBClient client = new AmazonDynamoDBClient();
            Table table = Table.LoadTable(client, "TrailNorth-Test");
            
            var item = new Document();
            item["guid"] = "Testing";
            
            return response;
        }
    }
    
    [RegisterHandler("AMAZON.FallbackIntent",
        new[] {
            "Do something with the {test}",
            "Test the test with the {test}"
        })]
    public class FallbackHandler : RequestHandler
    {
        public override ResponseAbstract Handle(RequestAbstract request)
        {
            ResponseAbstract response = request.BuildResponseObject();

            response.Speech = "This is the fallback handler";
            response.Reprompt = "Intent was not found, so this was invoked.";
            return response;
        }
    }
}
