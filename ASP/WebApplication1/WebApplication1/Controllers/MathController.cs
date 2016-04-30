using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers {
   public class MathController : Controller {
      // GET: Math
      public ActionResult Index() {
         return View();
      }

      public ActionResult Calculate() {
         return View();
      }

      [HttpPost]
      public ActionResult Calculate(int x, int y) {
         ViewBag.summa = x+y;
         return View();
      }
   }
}