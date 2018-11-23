using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Connector.Teams;
using Microsoft.Bot.Connector.Teams.Models;
using Microsoft.Teams.Samples.HelloWorld.Web.Controllers;
using Microsoft.Teams.Samples.HelloWorld.Web.Models;

namespace Microsoft.Teams.Samples.HelloWorld.Web.Controllers
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        [HttpPost]
        public async Task<HttpResponseMessage> Post([FromBody] Activity activity)
        {
            //using (var connector = new ConnectorClient(new Uri(activity.ServiceUrl)))
            //{
            //    if (activity.IsComposeExtensionQuery())
            //    {
            //        var response = MessageExtension.HandleMessageExtensionQuery(connector, activity);
            //        return response != null
            //            ? Request.CreateResponse<ComposeExtensionResponse>(response)
            //            : new HttpResponseMessage(HttpStatusCode.OK);
            //    }
            //    else
            //    {
            //        await EchoBot.EchoMessage(connector, activity);
            //        return new HttpResponseMessage(HttpStatusCode.Accepted);
            //    }
            //}
            if (activity != null && activity.GetActivityType() == ActivityTypes.Message)
            {

                if(activity.Value != null)
                {
                    return await HandleSubmitRequest(activity);
                }
                else
                {
                    await Conversation.SendAsync(activity, () => new EchoDialog());
                }
                
            }
            else
            {
                HandleSystemMessage(activity);
            }
            return new HttpResponseMessage(System.Net.HttpStatusCode.Accepted);
        }

        private void HandleSystemMessage(Activity activity)
        {
            throw new NotImplementedException();
        }

        private static async Task<HttpResponseMessage> HandleSubmitRequest(Activity activity)
        {

            var EmployeeData = Newtonsoft.Json.JsonConvert.DeserializeObject<Employee>(activity.Value.ToString());

            Employee employee = new Employee()
            {
                ID = EmployeeData.ID,
                Name = EmployeeData.Name,
                Gender = EmployeeData.Gender,
                PhoneNumber = EmployeeData.PhoneNumber,
                Address = EmployeeData.Address
            };

            EmployeeList.EmployeesList.Add(employee);

            var connectorClient = new ConnectorClient(new Uri(activity.ServiceUrl));

            Activity replyActivity = activity.CreateReply();

            replyActivity.TextFormat = "xml";

            replyActivity.Text = $@"

            Thanks, <h2>{activity.From.Name}</h2>

            Your Data is Stored.
            
            ";
            //replyActivity.Text = $"Thankyou" + { activity.From.Name} + "data is stored";

            await connectorClient.Conversations.ReplyToActivityWithRetriesAsync(replyActivity);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

    }



}
