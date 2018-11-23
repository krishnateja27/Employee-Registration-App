using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Scorables;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Connector.Teams.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Microsoft.Teams.Samples.HelloWorld.Web.Controllers
{
    //[Serializable]
    //public class EchoDialog : IDialog<object>
    //{
    //    public async Task StartAsync(IDialogContext context)
    //    {
    //        // Root dialog initiates and waits for the next message from the user. 
    //        // When a message arrives, call MessageReceivedAsync.
    //        context.Wait(this.MessageReceivedAsync);
    //    }

    //    // This sample dialog shows two simple flows:
    //    // 1) A silly example of receiving a file from the user, processing the key elements,
    //    //    and then constructing the attachment and sending it back.
    //    // 2) Creating a new file consent card requesting user permission to upload a file.
    //    private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
    //    {
    //        var replyMessage = context.MakeMessage();
    //        Attachment returnCard;

    //        var message = await result as Activity;

    //        // Check to see if the user is sending the bot a file.
    //        if (message.Attachments != null && message.Attachments.Any())
    //        {
    //            var attachment = message.Attachments.First();

    //            //if (attachment.ContentType == FileDownloadInfo.ContentType)
    //            //{
    //              FileDownloadInfo downloadInfo = (attachment.Content as JObject).ToObject<FileDownloadInfo>();
    //            if (downloadInfo != null)
    //            {
    //                returnCard = CreateFileInfoAttachment(downloadInfo, attachment.Name, attachment.ContentUrl);
    //                replyMessage.Attachments.Add(returnCard);
    //            }
    //        }
        
    //        else
    //        {
    //            // Illustrates creating a file consent card.
    //            returnCard = CreateFileConsentAttachment();
    //            replyMessage.Attachments.Add(returnCard);
    //        }
    //        await context.PostAsync(replyMessage);

    //    }


    //    private static Attachment CreateFileInfoAttachment(FileDownloadInfo downloadInfo, string name, string contentUrl)
    //    {
    //        FileInfoCard card = new FileInfoCard()
    //        {
    //            FileType = downloadInfo.FileType,
    //            UniqueId = downloadInfo.UniqueId
    //        };

    //        Attachment att = card.ToAttachment();
    //        att.ContentUrl = contentUrl;
    //        att.Name = name;

    //        return att;
    //    }

    //    private static Attachment CreateFileConsentAttachment()
    //    {
    //        JObject acceptContext = new JObject();
    //        // Fill in any additional context to be sent back when the user accepts the file.

    //        JObject declineContext = new JObject();
    //        // Fill in any additional context to be sent back when the user declines the file.

    //        FileConsentCard card = new FileConsentCard()
    //        {
    //            AcceptContext = acceptContext,
    //            DeclineContext = declineContext,
    //            SizeInBytes = 102635,
    //            Description = "File description"
    //        };

    //        Attachment att = card.ToAttachment();
    //        att.Name = "Example file";

    //        return att;
    //    }
    //}
    [Serializable]
    public class EchoDialog : DispatchDialog
    {
        #region Help Dialog

        [RegexPattern(DialogMatches.Help)]
        [ScorableGroup(1)]
        public void Help(IDialogContext context, IActivity activity)
        {
            this.Default(context, activity);
        }

        [MethodBind]
        [ScorableGroup(2)]
        public void Default(IDialogContext context, IActivity activity)
        {
            context.Call(new HelpDialog(), this.EndDefaultDialog);
        }

        public Task EndDefaultDialog(IDialogContext context, IAwaitable<object> result)
        {
            context.Done<object>(null);
            return Task.CompletedTask;
        }

        public Task EndDialog(IDialogContext context, IAwaitable<object> result)
        {
            context.Done<object>(null);
            return Task.CompletedTask;
        }

        #endregion
    }
}