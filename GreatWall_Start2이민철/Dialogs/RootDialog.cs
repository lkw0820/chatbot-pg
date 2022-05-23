using System;
using System.Threading.Tasks;

using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.Dialogs;
using System.Collections.Generic;
using GreatWall.Dialogs;
//Add for List<>

namespace GreatWall
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        protected int count = 1;
        string strMessage;
        private string strWelcomeMessage = "메뉴를 선택해주세요";

        public Task StartAsync(IDialogContext context)
        {

            context.Wait(MessageReceivedAsync);
            return Task.CompletedTask;
        }   
        
        public async Task MessageReceivedAsync(IDialogContext context, 
                                               IAwaitable<object> result)
        {
            await context.PostAsync(strWelcomeMessage);    //return our reply to the user
            

            var message = context.MakeMessage();        //Create message
            var actions = new List<CardAction>();       //Create List

            actions.Add(new CardAction() {Title = "1. 공지사항", Value = "1", Type = ActionTypes.ImBack});
            actions.Add(new CardAction() {Title = "2. 모집일정", Value = "2", Type = ActionTypes.ImBack});
            actions.Add(new CardAction() { Title = "3. 수시전형", Value = "3", Type = ActionTypes.ImBack });
            actions.Add(new CardAction() { Title = "4. 정시전형", Value = "4", Type = ActionTypes.ImBack });
            actions.Add(new CardAction() { Title = "5. 산업체위탁", Value = "5", Type = ActionTypes.ImBack });
            actions.Add(new CardAction() { Title = "6. 편입학", Value = "6", Type = ActionTypes.ImBack });
            actions.Add(new CardAction() { Title = "7. 전공심화", Value = "7", Type = ActionTypes.ImBack });
            actions.Add(new CardAction() { Title = "8. 외국인", Value = "8", Type = ActionTypes.ImBack });
            actions.Add(new CardAction() { Title = "9. e-MU", Value = "9", Type = ActionTypes.ImBack });
            actions.Add(new CardAction() { Title = "10. 재외국민", Value = "10", Type = ActionTypes.ImBack });

            message.Attachments.Add(                    //Create Hero Card & attachment
                new HeroCard { Title = "입학처에 오신 여러분을 환영합니다.", Buttons = actions}.ToAttachment()
            );

            await context.PostAsync(message);           //return our reply to the user

            context.Wait(SendWelcomeMessageAsync);            
        }

        public async Task SendWelcomeMessageAsync(IDialogContext context,
                                               IAwaitable<object> result)
        {
            Activity activity = await result as Activity;
            string strSelected = activity.Text.Trim();
            
            if(strSelected == "1")
            {
                context.Call(new JoinDialog(), DialogResumeAfter);
            }
            else if(strSelected == "2")
            {
                strMessage = "[FAQ Service] Please enter a question.>";
                await context.PostAsync(strMessage);
                context.Call(new FAQDialog(), DialogResumeAfter);
            }
            else if(strSelected == "3")
            {
                context.Call(new SusiDialog(), DialogResumeAfter);
            }
            else
            {
                strMessage = "You have made a mistake. Please select again...";
                await context.PostAsync(strMessage);
                context.Wait(SendWelcomeMessageAsync);
            }     
        }

        public async Task DialogResumeAfter(IDialogContext context, IAwaitable<string> result)
        {
            try
            {
                strMessage = await result;

                //await context.PostAsync(WelcomeMessage); ;
                await this.MessageReceivedAsync(context, result);
            }
            catch (TooManyAttemptsException)
            {
                await context.PostAsync("Error occurred....");
            }
        }

        public async Task AfterResetAsync(IDialogContext context, IAwaitable<bool> argument)
        {
            var confirm = await argument;
            if (confirm)
            {
                this.count = 1;
                await context.PostAsync("Reset count.");
            }
            else
            {
                await context.PostAsync("Did not reset count.");
            }
            context.Wait(MessageReceivedAsync);
        }
    }
}

