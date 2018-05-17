using ExampleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExampleApp.Controllers
{
    public class HomeController : Controller
    {
        Repository repo;

        public HomeController()
        {
            repo = Repository.Current;
        }

        public ActionResult Index()
        {
            return View(repo.Products);
        }
    }
}