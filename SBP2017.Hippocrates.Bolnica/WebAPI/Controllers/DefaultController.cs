using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAPI.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index() // Samo za prikaz osnovne stranice (cisto radi reda)
        {
            return View();
        }
    }
}