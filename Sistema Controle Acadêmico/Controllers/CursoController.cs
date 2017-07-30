using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace sca.Controllers
{
    public class CursoController : Controller
    {
        [OutputCache(Duration = (60 * 60 * 24), Location = OutputCacheLocation.Server)]
        public ActionResult Listagem()
        {
            return View();
        }
    }
}