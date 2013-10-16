//Makhlaqur Arnob//
using Austern.Model.ClientModel;
using Austern.Model.Enumerations;
using Austern.Repository;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Austern.Services
{
    public class NewsService
    {
        //Create News and store news related images and returen the NewsId//
        public static int Create(News news)
        {
            if (news != null)
            {
                var newsId = NewsRepository.Create(news);
                if (news.Medias != null && news.Medias.Any() )
                {
                    foreach (var media in news.Medias)
                    {
                        if (media.MediaFile != null)
                        {
                            media.ReferenceId = newsId;
                            media.MediaFor = MediaType.ForNews;
                            MediaService.Create(media);
 
                        }
                    }
                }
                return newsId;
            } 
            return 0;
        }
        //Get the Single news details accroding to the newsId provided//
        public static News Get(int newsId)
        {
            var news = NewsRepository.Get(newsId);
            if(news !=null)
            {
                news.Medias = MediaRepository.Get(MediaType.ForNews, newsId);
                news.CreatedBy = UserRepository.Get(news.UserId);

            }
            return news;
        }
        //Get all the News in a news list//
        public static List<News> GetAll()
        {
            var news = NewsRepository.GetAll();
            if(news.Any())
            {
                foreach (var newsOne in news )
                {
                    newsOne.Medias = MediaRepository.Get(MediaType.ForNews, newsOne.NewsId);
                    newsOne.CreatedBy = UserRepository.Get(newsOne.UserId);
                }
            }
            return news;

        }

    }
}
