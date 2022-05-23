using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Threading.Tasks;           //Add to process Async Task
using Microsoft.Bot.Connector;          //Add for Activity Class
using Microsoft.Bot.Builder.Dialogs;    //Add for Dialog Class
using System.Net.Http;                  //Add for internet
using GreatWall.Helpers;                //Add for CardHelper

using System.Data;                      //Add for DB Connection
using System.Data.SqlClient;            //Add for DB Connection
using GreatWall.Model;                  //Add for Model

namespace GreatWall.Dialogs
{
    [Serializable]
    public class SusiDialog : IDialog<string>
    {
        string strMessage;
        public async Task StartAsync(IDialogContext context)
        {
            await this.MessageReceivedAsync(context, null);
        }

        private async Task MessageReceivedAsync(IDialogContext context,
                                               IAwaitable<object> result)
        {
            var message = context.MakeMessage();
            var actions = new List<CardAction>();

            actions.Add(new CardAction() { Title = "1. 모집인원", Value = "1", Type = ActionTypes.ImBack });
            actions.Add(new CardAction() { Title = "2. 지원자격", Value = "2", Type = ActionTypes.ImBack });
            actions.Add(new CardAction() { Title = "3. 전형일정", Value = "3", Type = ActionTypes.ImBack });
            actions.Add(new CardAction() { Title = "4. 제출서류", Value = "4", Type = ActionTypes.ImBack });
            actions.Add(new CardAction() { Title = "5. 성적 반영 방법", Value = "5", Type = ActionTypes.ImBack });
            actions.Add(new CardAction() { Title = "6. 합격자 선발 및 발표", Value = "6", Type = ActionTypes.ImBack });
            actions.Add(new CardAction() { Title = "7. 원서 접수 비용", Value = "7", Type = ActionTypes.ImBack });
            actions.Add(new CardAction() { Title = "8. 전년도 입시결과 ", Value = "8", Type = ActionTypes.ImBack });
            actions.Add(new CardAction() { Title = "9. 안내 사항", Value = "9", Type = ActionTypes.ImBack });
            actions.Add(new CardAction() { Title = "이전으로", Value = "0", Type = ActionTypes.ImBack });


            message.Attachments.Add(                    //Create Hero Card & attachment
               new HeroCard { Title = "수시전형 탭입니다. 메뉴를 선택해주세요!\n"+
               "수시 1차 원서 접수 : 2022.09.13 ~ 2022.10.06\n" +
               "수시 2차 원서 접수 : 2022.11.07 ~ 2022.11.21" 
               , Buttons = actions }.ToAttachment()
           );

            await context.PostAsync(message);
            //context.Wait(SusiSelect);
        }

        //public async Task SusiSelect(IDialogContext context,
        //                                      IAwaitable<object> result)
        //{
        //    Activity activity = await result as Activity;
        //    string strSelected = activity.Text.Trim();

        //    if (strSelected == "1")
        //    {
                
        //    }
        //    else if (strSelected == "2")
        //    {
        //        strMessage = "[FAQ Service] Please enter a question.>";
        //        await context.PostAsync(strMessage);
        //        context.Call(new FAQDialog(), DialogResumeAfter);
        //    }
        //    else if (strSelected == "3")
        //    {
        //        context.Call(new SusiDialog(), DialogResumeAfter);
        //    }
        //    else
        //    {
        //        strMessage = "You have made a mistake. Please select again...";
        //        await context.PostAsync(strMessage);
        //        context.Wait(SendWelcomeMessageAsync);
        //    }
        //}

    }
}