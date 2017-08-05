using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace sca.Controllers
{
    public class MatriculaController : Controller
    {
        [OutputCache(Duration = (60*60*24), Location = OutputCacheLocation.Server)]
        public ActionResult Cadastro()
        {
            return View();
        }
    }
}