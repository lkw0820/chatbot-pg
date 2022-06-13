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
using System.Web.Helpers;
using AdaptiveCards;
using System.Configuration;

namespace GreatWall
{
    [Serializable]
    public class DataBaseDialog : IDialog<string>
    {
        List<OrderItem> ranklist = new List<OrderItem>();   //Create list object
        public async Task StartAsync(IDialogContext context)
        {
            await this.MessageReceivedAsync(context, null);
        }

        private async Task MessageReceivedAsync(IDialogContext context,
                                               IAwaitable<object> result)
        {
           // Activity activity = await result as Activity;
            var actions = new List<CardAction>();
            var message = context.MakeMessage();

            //DB Connection using SQLHelper
            //string Rank1 = SQLHelper.RankQuery("SELECT name FROM choicedata where count = (select max(count) from choicedata)");
            string Rank2 ="SELECT name FROM choicedata order by count DESC offset 0 rows fetch next 5 rows only";
           // string Rank3 = SQLHelper.RankQuery("SELECT name FROM(SELECT choicedata.*, ROW_NUMBER() OVER(ORDER BY count ASC) RN FROM choicedata)WHERE RN = 3;");
           // string Rank4 = SQLHelper.RankQuery("SELECT name FROM(SELECT choicedata.*, ROW_NUMBER() OVER(ORDER BY count ASC) RN FROM choicedata)WHERE RN = 4;");
           // string Rank5 = SQLHelper.RankQuery("SELECT name FROM(SELECT choicedata.*, ROW_NUMBER() OVER(ORDER BY count ASC) RN FROM choicedata)WHERE RN = 5;");

            actions.Add(new CardAction() { Title = "이전으로", Value = "11", Type = ActionTypes.ImBack });
            //context.Call(new previousDialog(), DialogResumeAfter);
            DataSet DB_DS = SQLHelper.RunSQL(Rank2);

            //Menu
            
            foreach (DataRow row in DB_DS.Tables[0].Rows)
            {
                //Hero Card-01~04 attachment 
                message.Attachments.Add(new HeroCard(){ Title = row["name"].ToString()}.ToAttachment());
            }
            await context.PostAsync(message);
        }
    }
}