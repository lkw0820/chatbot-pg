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
    public class DeepCourseDialog : IDialog<string>
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

            actions.Add(new CardAction() { Title = "1. 학사학위 안내", Value = "1", Type = ActionTypes.ImBack });
            actions.Add(new CardAction() { Title = "2. 모집인원 & 전형일정", Value = "2", Type = ActionTypes.ImBack });
            actions.Add(new CardAction() { Title = "3. 지원자격 & 제출서류", Value = "3", Type = ActionTypes.ImBack });
            actions.Add(new CardAction() { Title = "4. 선발방법 & 면접고사", Value = "4", Type = ActionTypes.ImBack });
            actions.Add(new CardAction() { Title = "5. 합격자 발표 & 입학포기", Value = "5", Type = ActionTypes.ImBack });
            actions.Add(new CardAction() { Title = "6. 안내사항", Value = "6", Type = ActionTypes.ImBack });
            actions.Add(new CardAction() { Title = "7. 합격자 발표 & 입학포기", Value = "7", Type = ActionTypes.ImBack });
            actions.Add(new CardAction() { Title = "8. 안내사항", Value = "8", Type = ActionTypes.ImBack });
            actions.Add(new CardAction() { Title = "9. 관련학과 기준표", Value = "9", Type = ActionTypes.ImBack });
            actions.Add(new CardAction() { Title = "10. 전공심화 2차 ", Value = "10", Type = ActionTypes.ImBack });

            message.Attachments.Add(                    //Create Hero Card & attachment
               new HeroCard
               {
                   Title = "전공심화과정 탭입니다. 메뉴를 선택해주세요!\n" +
               "전공심화 원서접수 1차 : 2022.01.10 ~ 2022.01.26 \n" +
               "전공심화 원서접수 2차 : 2022.02.21 ~ 2022.02.22"
               ,
                   Buttons = actions
               }.ToAttachment()
           );

            await context.PostAsync(message);
            context.Wait(this.MessageReceivedAsync);
        }
        public async Task JungsiSelect(IDialogContext context,
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
                SQLHelper.PulsQuery("update ChoiceData set count = count+1 Where name = 'person'"); //DB의 열에 +1
                actions.Add(new CardAction()
                {
                    Title = "차트 보기"
,
                    Value = "https://ipsi.inhatc.ac.kr/Web-home/plugin/pdfjs/web/viewer.html?file=%2Fsites%2Fipsi%2Fatchmnfl%2Fviewer%2F15%2F%2Ftemp_1654674907706100.tmp#page=8&zoom=auto,-223,842",
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
                SQLHelper.PulsQuery("update ChoiceData set count = count+1 Where name = 'qualification'"); //DB의 열에 +1
                actions.Add(new CardAction()
                {
                    Title = "차트 보기"
,
                    Value = "https://ipsi.inhatc.ac.kr/Web-home/plugin/pdfjs/web/viewer.html?file=%2Fsites%2Fipsi%2Fatchmnfl%2Fviewer%2F15%2F%2Ftemp_1654674907706100.tmp#page=10&zoom=auto,-15,842",
                    Type = ActionTypes.ShowImage
                }); ;
                actions.Add(new CardAction() { Title = "이전으로", Value = "11", Type = ActionTypes.ImBack });
                //context.Call(new previousDialog(), DialogResumeAfter);
                message.Attachments.Add(                    //Create Hero Card & attachment
                   new HeroCard
                   {
                       Title = "전형일정 & 면접고사 입니다.",
                       Buttons = actions
                   }.ToAttachment()
                   ); ;
            }
            else if (strSelected == "3")
            {
                SQLHelper.PulsQuery("update ChoiceData set count = count+1 Where name = 'schedule'"); //DB의 열에 +1
                actions.Add(new CardAction()
                {
                    Title = "차트 보기"
,
                    Value = "https://ipsi.inhatc.ac.kr/Web-home/plugin/pdfjs/web/viewer.html?file=%2Fsites%2Fipsi%2Fatchmnfl%2Fviewer%2F15%2F%2Ftemp_1654674907706100.tmp#page=11&zoom=auto,-15,842",
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
            else if (strSelected == "4")
            {
                SQLHelper.PulsQuery("update ChoiceData set count = count+1 Where name = 'document'"); //DB의 열에 +1
                actions.Add(new CardAction()
                {
                    Title = "차트 보기"
,
                    Value = "https://ipsi.inhatc.ac.kr/Web-home/plugin/pdfjs/web/viewer.html?file=%2Fsites%2Fipsi%2Fatchmnfl%2Fviewer%2F15%2F%2Ftemp_1654674907706100.tmp#page=13&zoom=auto,-15,842",
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
                SQLHelper.PulsQuery("update ChoiceData set count = count+1 Where name = 'record'"); //DB의 열에 +1
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
                SQLHelper.PulsQuery("update ChoiceData set count = count+1 Where name = 'pass'"); //DB의 열에 +1
                actions.Add(new CardAction()
                {
                    Title = "차트 보기"
,
                    Value = "https://ipsi.inhatc.ac.kr/Web-home/plugin/pdfjs/web/viewer.html?file=%2Fsites%2Fipsi%2Fatchmnfl%2Fviewer%2F15%2F%2Ftemp_1654674907706100.tmp#page=17&zoom=auto,-15,842",
                    Type = ActionTypes.ShowImage
                }); ;
                actions.Add(new CardAction() { Title = "이전으로", Value = "11", Type = ActionTypes.ImBack });
                //context.Call(new previousDialog(), DialogResumeAfter);
                message.Attachments.Add(                    //Create Hero Card & attachment
                   new HeroCard
                   {
                       Title = "합격자 발표 및 충원 입니다.",
                       Buttons = actions
                   }.ToAttachment()
                   ); ;
            }
            else if (strSelected == "7")
            {
                SQLHelper.PulsQuery("update ChoiceData set count = count+1 Where name = 'price'"); //DB의 열에 +1
                actions.Add(new CardAction()
                {
                    Title = "차트 보기"
,
                    Value = "https://ipsi.inhatc.ac.kr/Web-home/plugin/pdfjs/web/viewer.html?file=%2Fsites%2Fipsi%2Fatchmnfl%2Fviewer%2F15%2F%2Ftemp_1654674907706100.tmp#page=18&zoom=auto,-15,842",
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
                SQLHelper.PulsQuery("update ChoiceData set count = count+1 Where name = 'previous'"); //DB의 열에 +1
                actions.Add(new CardAction()
                {
                    Title = "차트 보기"
                ,
                    Value = "https://ipsi.inhatc.ac.kr/Web-home/plugin/pdfjs/web/viewer.html?file=%2Fsites%2Fipsi%2Fatchmnfl%2Fviewer%2F15%2F%2Ftemp_1654674907706100.tmp#page=19&zoom=auto,-15,842",
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
            else if (strSelected == "9")
            {
                SQLHelper.PulsQuery("update ChoiceData set count = count+1 Where name = 'guide'"); //DB의 열에 +1
                actions.Add(new CardAction()
                {
                    Title = "차트 보기"
,
                    Value = "https://ipsi.inhatc.ac.kr/Web-home/plugin/pdfjs/web/viewer.html?file=%2Fsites%2Fipsi%2Fatchmnfl%2Fviewer%2F15%2F%2Ftemp_1654674907706100.tmp#page=21&zoom=auto,-15,768",
                    Type = ActionTypes.ShowImage
                }); ;
                actions.Add(new CardAction() { Title = "이전으로", Value = "11", Type = ActionTypes.ImBack });
                //context.Call(new previousDialog(), DialogResumeAfter);
                message.Attachments.Add(                    //Create Hero Card & attachment
                   new HeroCard
                   {
                       Title = "전년도 입시결과 입니다.",
                       Buttons = actions
                   }.ToAttachment()
                   ); ;
            }
            else if (strSelected == "10")
            {
                SQLHelper.PulsQuery("update ChoiceData set count = count+1 Where name = 'guide'"); //DB의 열에 +1
                actions.Add(new CardAction()
                {
                    Title = "차트 보기"
,
                    Value = "https://ipsi.inhatc.ac.kr/Web-home/plugin/pdfjs/web/viewer.html?file=%2Fsites%2Fipsi%2Fatchmnfl%2Fviewer%2F15%2F%2Ftemp_1654674907706100.tmp#page=25&zoom=auto,-15,842",
                    Type = ActionTypes.ShowImage
                }); ;
                actions.Add(new CardAction() { Title = "이전으로", Value = "11", Type = ActionTypes.ImBack });
                //context.Call(new previousDialog(), DialogResumeAfter);
                message.Attachments.Add(                    //Create Hero Card & attachment
                   new HeroCard
                   {
                       Title = "학과소개 입니다.",
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
