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
            context.Wait(SusiSelect);
        }

        public async Task SusiSelect(IDialogContext context,
                                              IAwaitable<object> result)
        {
            Activity activity = await result as Activity;
            string strSelected = activity.Text.Trim();
            var message = context.MakeMessage();
            var actions = new List<CardAction>();

            if (strSelected == "0")
            {
                context.Done("");
                
            }
            else if (strSelected == "11")
            {
                context.Call(this, DialogResumeAfter);
                context.Done("");
            }
            else if (strSelected == "1")
            {
                actions.Add(new CardAction()
                {
                    Title = "차트 보기"
,
                    Value = "https://ipsi.inhatc.ac.kr/Web-home/plugin/pdfjs/web/viewer.html?file=%2Fsites%2Fipsi%2Fatchmnfl%2Fviewer%2F13%2F%2Ftemp_1635721183237100.tmp#page=9&zoom=auto,-15,842",
                    Type = ActionTypes.ShowImage
                }); ;
                actions.Add(new CardAction() { Title = "이전으로", Value = "11", Type = ActionTypes.ImBack });
                //context.Call(new previousDialog(), DialogResumeAfter);
                message.Attachments.Add(                    //Create Hero Card & attachment
                    new HeroCard
                    {
                        Title = "모집인원 입니다.",
                        Buttons = actions
                    }.ToAttachment()
                    ); ;
            }
            else if (strSelected == "2")
            {
                actions.Add(new CardAction()
                {
                    Title = "차트 보기"
,
                    Value = "https://ipsi.inhatc.ac.kr/Web-home/plugin/pdfjs/web/viewer.html?file=%2Fsites%2Fipsi%2Fatchmnfl%2Fviewer%2F13%2F%2Ftemp_1635721183237100.tmp#page=12&zoom=auto,-15,802",
                    Type = ActionTypes.ShowImage
                }); ;
                actions.Add(new CardAction() { Title = "이전으로", Value = "11", Type = ActionTypes.ImBack });
                //context.Call(new previousDialog(), DialogResumeAfter);
                message.Attachments.Add(                    //Create Hero Card & attachment
                   new HeroCard
                   {
                       Title = "지원자격 입니다.",
                       Buttons = actions
                   }.ToAttachment()
                   ); ;
            }
            else if (strSelected == "3")
            {
                actions.Add(new CardAction()
                {
                    Title = "차트 보기"
,
                    Value = "https://ipsi.inhatc.ac.kr/Web-home/plugin/pdfjs/web/viewer.html?file=%2Fsites%2Fipsi%2Fatchmnfl%2Fviewer%2F13%2F%2Ftemp_1635721183237100.tmp#page=11&zoom=auto,-15,842",
                    Type = ActionTypes.ShowImage
                }); ;
                actions.Add(new CardAction() { Title = "이전으로", Value = "11", Type = ActionTypes.ImBack });
                //context.Call(new previousDialog(), DialogResumeAfter);
                message.Attachments.Add(                    //Create Hero Card & attachment
                   new HeroCard
                   {
                       Title = "전형일정 입니다.",
                       Buttons = actions
                   }.ToAttachment()
                   ); ;
            }
            else if (strSelected == "4")
            {
                actions.Add(new CardAction()
                {
                    Title = "차트 보기"
,
                    Value = "https://ipsi.inhatc.ac.kr/Web-home/plugin/pdfjs/web/viewer.html?file=%2Fsites%2Fipsi%2Fatchmnfl%2Fviewer%2F13%2F%2Ftemp_1635721183237100.tmp#page=14&zoom=auto,-15,630",
                    Type = ActionTypes.ShowImage
                }); ;
                actions.Add(new CardAction() { Title = "이전으로", Value = "11", Type = ActionTypes.ImBack });
                //context.Call(new previousDialog(), DialogResumeAfter);
                message.Attachments.Add(                    //Create Hero Card & attachment
                   new HeroCard
                   {
                       Title = "제출서류 입니다.",
                       Buttons = actions
                   }.ToAttachment()
                   ); ;
            }
            else if (strSelected == "5")
            {
                actions.Add(new CardAction()
                {
                    Title = "차트 보기"
,
                    Value = "https://ipsi.inhatc.ac.kr/Web-home/plugin/pdfjs/web/viewer.html?file=%2Fsites%2Fipsi%2Fatchmnfl%2Fviewer%2F13%2F%2Ftemp_1635721183237100.tmp#page=15&zoom=auto,-15,842",
                    Type = ActionTypes.ShowImage
                }); ;
                actions.Add(new CardAction() { Title = "이전으로", Value = "11", Type = ActionTypes.ImBack });
                //context.Call(new previousDialog(), DialogResumeAfter);
                message.Attachments.Add(                    //Create Hero Card & attachment
                   new HeroCard
                   {
                       Title = "성적반영 방법 입니다.",
                       Buttons = actions
                   }.ToAttachment()
                   ); ;
            }
            else if (strSelected == "6")
            {
                actions.Add(new CardAction()
                {
                    Title = "차트 보기"
,
                    Value = "https://ipsi.inhatc.ac.kr/Web-home/plugin/pdfjs/web/viewer.html?file=%2Fsites%2Fipsi%2Fatchmnfl%2Fviewer%2F13%2F%2Ftemp_1635721183237100.tmp#page=18&zoom=auto,-15,842",
                    Type = ActionTypes.ShowImage
                }); ;
                actions.Add(new CardAction() { Title = "이전으로", Value = "11", Type = ActionTypes.ImBack });
                //context.Call(new previousDialog(), DialogResumeAfter);
                message.Attachments.Add(                    //Create Hero Card & attachment
                   new HeroCard
                   {
                       Title = "합격자 선발 및 발표 입니다.",
                       Buttons = actions
                   }.ToAttachment()
                   ); ;
            }
            else if (strSelected == "7")
            {
                actions.Add(new CardAction()
                {
                    Title = "차트 보기"
,
                    Value = "https://ipsi.inhatc.ac.kr/Web-home/plugin/pdfjs/web/viewer.html?file=%2Fsites%2Fipsi%2Fatchmnfl%2Fviewer%2F13%2F%2Ftemp_1635721183237100.tmp#page=19&zoom=auto,-15,842",
                    Type = ActionTypes.ShowImage
                }); ;
                actions.Add(new CardAction() { Title = "이전으로", Value = "11", Type = ActionTypes.ImBack });
                //context.Call(new previousDialog(), DialogResumeAfter);
                message.Attachments.Add(                    //Create Hero Card & attachment
                   new HeroCard
                   {
                       Title = "원서접수 비용 입니다.",
                       Buttons = actions
                   }.ToAttachment()
                   ); ;
            }
            else if (strSelected == "8")
            {
                actions.Add(new CardAction()
                {
                    Title = "차트 보기"
                ,
                    Value = "https://ipsi.inhatc.ac.kr/Web-home/plugin/pdfjs/web/viewer.html?file=%2Fsites%2Fipsi%2Fatchmnfl%2Fviewer%2F13%2F%2Ftemp_1635721183237100.tmp#page=22&zoom=auto,-15,766",
                    Type = ActionTypes.ShowImage
                }); ;
                actions.Add(new CardAction() { Title = "이전으로", Value = "11", Type = ActionTypes.ImBack });
                //context.Call(new previousDialog(), DialogResumeAfter);
                message.Attachments.Add(                    //Create Hero Card & attachment
                    new HeroCard
                    {
                        Title = "전년도 입시 결과 입니다.",
                        Buttons = actions
                    }.ToAttachment()
                    ); ;
            }
            else if (strSelected == "9")
            {
                actions.Add(new CardAction()
                {
                    Title = "차트 보기"
,
                    Value = "https://ipsi.inhatc.ac.kr/Web-home/plugin/pdfjs/web/viewer.html?file=%2Fsites%2Fipsi%2Fatchmnfl%2Fviewer%2F13%2F%2Ftemp_1635721183237100.tmp#page=20&zoom=auto,-15,842",
                    Type = ActionTypes.ShowImage
                }); ;
                actions.Add(new CardAction() { Title = "이전으로", Value = "11", Type = ActionTypes.ImBack });
                //context.Call(new previousDialog(), DialogResumeAfter);
                message.Attachments.Add(                    //Create Hero Card & attachment
                   new HeroCard
                   {
                       Title = "안내사항 입니다.",
                       Buttons = actions
                   }.ToAttachment()
                   ); ;
            }
            await context.PostAsync(message);
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


    }
}