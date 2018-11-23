using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
//using Microsoft.Teams.TemplateBotCSharp.Properties;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdaptiveCards;
using System.Configuration;

namespace Microsoft.Teams.Samples.HelloWorld.Web.Controllers
{
    /// <summary>
    /// This is Help Dialog Class. Main purpose of this dialog class is to post the help commands in Teams.
    /// These are Actionable help commands for easy to use.
    /// </summary>
    [Serializable]
    public class HelpDialog : IDialog<object>
    {

        private string botId = ConfigurationManager.AppSettings["MicrosoftAppId"];
        private const string TabEntityID = "holidaytab";

        public async Task StartAsync(IDialogContext context)
        {
            
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var message = context.MakeMessage();

            //Set the Last Dialog in Conversation Data
            //context.UserData.SetValue(Strings.LastDialogKey, Strings.LastDialogHelpDialog);

            //// This will create Interactive Card with help command buttons

            //message.Attachments = new List<Attachment>
            //{
            //    new HeroCard(Strings.HelpTitle)
            //    {
            //        Buttons = new List<CardAction>
            //        {
            //            new CardAction(ActionTypes.ImBack, "demotext", value: "demovalue"),
            //            new CardAction(ActionTypes.ImBack, Strings.HelpCaptionFetchRoster, value: Strings.cmdFetchRoster),
            //            new CardAction(ActionTypes.ImBack, Strings.HelpCaptionPlayGame, value: Strings.cmdPrompt),
            //            new CardAction(ActionTypes.ImBack, Strings.HelpCaptionRosterPayload, value: Strings.cmdRosterPayload),
            //            new CardAction(ActionTypes.ImBack, Strings.HelpCaptionDialogFlow, value: Strings.cmdDialogFlow),
            //            new CardAction(ActionTypes.ImBack, Strings.HelpCaptionHelloDialog, value: Strings.cmdHelloDialog),
            //            new CardAction(ActionTypes.ImBack, Strings.HelpCaptionAtMention, value: Strings.cmdRunAtMentionDialog),
            //            new CardAction(ActionTypes.ImBack, Strings.HelpCaptionMultiDialog1, value: Strings.cmdMultiDialog1),
            //            new CardAction(ActionTypes.ImBack, Strings.HelpCaptionMultiDialog2, value: Strings.cmdMultiDialog2),
            //            new CardAction(ActionTypes.ImBack, Strings.HelpCaptionFetchLastDialog, value: Strings.cmdFetchLastDialog),
            //            new CardAction(ActionTypes.ImBack, Strings.HelpCaptionSetupMessage, value: Strings.cmdSetupMessage),
            //            new CardAction(ActionTypes.ImBack, Strings.HelpCaptionUpdateMessage, value: Strings.cmdUpdateMessage),
            //            new CardAction(ActionTypes.ImBack, Strings.HelpCaptionSend1on1Conversation, value: Strings.cmdSend1on1ConversationDialog),
            //            new CardAction(ActionTypes.ImBack, Strings.HelpCaptionUpdateCard, value: Strings.cmdUpdateCard),
            //            new CardAction(ActionTypes.ImBack, Strings.HelpCaptionDisplayCards, value: Strings.cmdDisplayCards),
            //            new CardAction(ActionTypes.ImBack, Strings.HelpCaptionDeepLink, value: Strings.cmdDeepLink),
            //            new CardAction(ActionTypes.ImBack, Strings.HelpCaptionAuthSample, value: Strings.cmdAuthSampleDialog),
            //            new CardAction(ActionTypes.ImBack, Strings.HelpLocalTimeZone, value: Strings.cmdLocalTime),
            //            new CardAction(ActionTypes.ImBack, Strings.HelpCaptionMessageBack, value: Strings.cmdMessageBack),
            //            new CardAction(ActionTypes.ImBack, Strings.HelpCaptionPopUpSignIn, value: Strings.cmdPopUpSignIn),
            //            new CardAction(ActionTypes.ImBack, Strings.HelpCaptionTeamInfo, value: Strings.cmdGetTeamInfo)
            //        }
            //    }.ToAttachment()
            //};

            //message.Text = "Hi this is an Employee Register and Info Bot";
            
            var attachment = GetAdaptiveCard();

            message.Attachments.Add(attachment);

            await context.PostAsync(message);
            context.Done<object>(null);
        }
        public static Attachment GetAdaptiveCard()
        {
            var WelcomeCard = new AdaptiveCard()
            {
                Body = new List<AdaptiveElement>()
                {
                    new AdaptiveTextBlock()
                    {
                        Text="Hello!!! Welcome to Employee Registration Bot",
                        Size=AdaptiveTextSize.Medium
                    },
                },
                Actions = new List<AdaptiveAction>()
                {
                    new AdaptiveShowCardAction()
                    {
                        Title = "Employee Registration",
                        Card=new AdaptiveCard()
                        {
                          Body=new List<AdaptiveElement>()
                          {
                              new AdaptiveTextBlock(){Text="ID", Weight=AdaptiveTextWeight.Bolder,Size=AdaptiveTextSize.Medium},
                              new AdaptiveTextInput()
                              {
                                Id = "ID",
                                Value = null,
                                IsMultiline = false
                              },
                              new AdaptiveTextBlock(){Text="Name", Weight=AdaptiveTextWeight.Bolder,Size=AdaptiveTextSize.Medium},
                              new AdaptiveTextInput()
                              {
                                Id = "Name",
                                Value = null,
                                IsMultiline = false
                              },
                              new AdaptiveTextBlock(){Text="Gender", Weight=AdaptiveTextWeight.Bolder,Size=AdaptiveTextSize.Medium},
                              new AdaptiveTextInput()
                              {
                                Id = "Gender",
                                Value = null,
                                IsMultiline = false
                              },
                              new AdaptiveTextBlock(){Text="Phone Number", Weight=AdaptiveTextWeight.Bolder,Size=AdaptiveTextSize.Medium},
                              new AdaptiveTextInput()
                              {
                                Id = "PhoneNumber",
                                Value = null,
                                IsMultiline = false,
                                MaxLength = 10
                              },
                              new AdaptiveTextBlock(){Text="Address", Weight=AdaptiveTextWeight.Bolder,Size=AdaptiveTextSize.Medium},
                              new AdaptiveTextInput()
                              {
                                Id = "Address",
                                Value = null,
                                IsMultiline = true
                              }
                          },
                          Actions = new List<AdaptiveAction>()
                          {
                            new AdaptiveSubmitAction()
                            {
                                Type = AdaptiveSubmitAction.TypeName,
                                Title = "OK",
                            }
                          }
                        }
                    },
                    new AdaptiveOpenUrlAction()
                    {
                        Title="Holiday Tab",
                        Url = new Uri($"https://teams.microsoft.com/l/entity/28:" + ConfigurationManager.AppSettings["MicrosoftAppId"] + "/" + TabEntityID + "?conversationType=chat")
                    },
                    new AdaptiveShowCardAction()
                    {
                        Title = "Employee List",
                        Card=new AdaptiveCard()
                        {
                            Body=new List<AdaptiveElement>()
                            {
                                //new AdaptiveTextBlock(){Text="ID", Weight=AdaptiveTextWeight.Bolder,Size=AdaptiveTextSize.Medium},
                                new AdaptiveTextInput()
                                {
                                    Id = "SearchInput",
                                    Placeholder = "Enter the name of the Employee",
                                    Value = null,
                                    IsMultiline = false
                                },
                            },
                            Actions = new List<AdaptiveAction>()
                            {
                                new AdaptiveSubmitAction()
                                {
                                    Type = AdaptiveSubmitAction.TypeName,
                                    Title = "Search",
                                }
                            }
                          
                        }
                    }
                }
            };
            return new Attachment()
            {
                ContentType = AdaptiveCard.ContentType,
                Content = WelcomeCard
            };
        }
    }
}