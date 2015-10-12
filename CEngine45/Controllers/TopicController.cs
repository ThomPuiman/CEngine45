using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CEngine45.Common.Services;
using CEngine45.Models.Community;

namespace CEngine45.Controllers
{
    public class TopicController : Controller
    {
        private readonly ITopic _topicInstance;

        public TopicController(ITopic topicInstance)
        {
            _topicInstance = topicInstance;
        }

        // GET: Topic
        public ActionResult Index(int topicId)
        {
            Topic model = _topicInstance.Get(topicId);
            if (model != null)
            {
                return View();
            }
            return HttpNotFound();
        }

        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult New(Post firstPost)
        {
            _topicInstance.Create(firstPost);
            return View();
        }
    }
}