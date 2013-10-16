//Created by Arnob//
using Austern.Model.ClientModel;
using Austern.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EdgeCorp.Controllers
{
    public class NewsController : Controller
    {
        //Display all News//
        public ActionResult Index()
        {
            var news = NewsService.GetAll();
            return View(news);
        }

        //Get Add News form//
        [Authorize]
        [HttpGet]
        public ActionResult AddNew()
        {
            if (this.User.IsInRole("Administrators"))
            {
            var news = new News { UserId= -1 };
            return View(news);
            }
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddNew(News news)
        {
            if(this.ControllerContext.HttpContext.User.Identity.IsAuthenticated )
            {
                news.UserId = WebMatrix.WebData.WebSecurity.CurrentUserId;
            }
            if (ModelState.IsValid)
            {
                NewsService.Create(news);
                return RedirectToAction("Index");
            }
            return View(news);
        }

        //Get Details News//
        [HttpGet]
        public ActionResult Details(int newsId)
        {
            var news = NewsService.Get(newsId);
            return View(news);
        }
    }
}
