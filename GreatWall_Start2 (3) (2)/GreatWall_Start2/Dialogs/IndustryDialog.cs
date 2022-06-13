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
    public class IndustryDialog : IDialog<string>
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

            actions.Add(new CardAction() { Title = "1. 모집학과", Value = "1", Type = ActionTypes.ImBack });
            actions.Add(new CardAction() { Title = "2. 전형일정", Value = "2", Type = ActionTypes.ImBack });
            actions.Add(new CardAction() { Title = "3. 지원자격", Value = "3", Type = ActionTypes.ImBack });
            actions.Add(new CardAction() { Title = "4. 선발방법", Value = "4", Type = ActionTypes.ImBack });
            actions.Add(new CardAction() { Title = "5. 합격발표", Value = "5", Type = ActionTypes.ImBack });
            actions.Add(new CardAction() { Title = "6. 입학포기 및 등록금 반환", Value = "6", Type = ActionTypes.ImBack });
            actions.Add(new CardAction() { Title = "7. 문의사항 연락처", Value = "7", Type = ActionTypes.ImBack });


            message.Attachments.Add(                    //Create Hero Card & attachment
               new HeroCard
               {
                   Title = "산업체위탁전형 탭입니다. 메뉴를 선택해주세요!\n" +
               "산업체 위탁 원서 접수 : 2022.01.05 ~ 2022.01.26 오후 3시" 
               
               ,
                   Buttons = actions
               }.ToAttachment()
           );

            await context.PostAsync(message);
            context.Wait(this.MessageReceivedAsync);
        }
    }
}