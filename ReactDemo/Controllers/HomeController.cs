using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using ReactDemo.Models;

namespace ReactDemo.Controllers
{
    public class HomeController : Controller
    {
        private static readonly IList<CommentModel> _comments;

        static HomeController()
        {
            _comments = new List<CommentModel>
            {
                new CommentModel
                {
                    Id = 1,
                    Author = "Daniel Lo Nigro",
                    Text = "Hello World"
                },
                new CommentModel()
                {
                    Id = 2,
                    Author = "Roms",
                    Text = "No comment"
                },
                new CommentModel()
                {
                    Id = 3,
                    Author = "Ej",
                    Text = "This is *Another* comment"
                },
            };
        }

        // GET: Home
        public ActionResult Index()
        {
            return View(_comments);
        }

        [OutputCache(Location = OutputCacheLocation.None)]
        public ActionResult Comments()
        {
            return Json(_comments, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddComment(CommentModel comment)
        {
            _comments.Add(comment);
            return Content("Success :)");
        }


    }
}