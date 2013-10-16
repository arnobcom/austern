//Makhlaqur Arnob//
using Austern.Model.ClientModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgeCorp.Repository
{
    public class NewsRepository:BaseRepository 
    {
        //Create News//
        public static int Create(News news)
        {
            using (var db = GetDatabase()) 
            {
                var dbNews = new EdgeCorp.Model.New
                {
                    UserId = news.UserId,
                    Title= news.Title,
                    DateCreated = DateTime.Now,
                    Details= news.Details
                    
                };
                db.News.InsertOnSubmit(dbNews);
                db.SubmitChanges();

                return dbNews.NewsId;
            }
        }
        //Get News of provided News ID//
        public static News Get(int newsId)
        {
            using (var db = GetDatabase())
            {
                var news = GetAll();
                return news.FirstOrDefault(n=>n.NewsId==newsId);

            }
        }
        //Get all the News in a News List//
        public static List<News> GetAll()
        {
            using (var db = GetDatabase())
            {
                var news = from n in db.News
                           select new News
                           {
                               NewsId= n.NewsId,
                               DateCreated= n.DateCreated,
                               Title= n.Title,
                               Details= n.Details,
                               UserId= n.UserId
                           };
                return news.ToList();
            }
                
        }

    }
}
