using CollectionManagement.BusinessEntityLayer.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CollectionManagement.WebProject.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            try
            {

            }
            catch (Exception e)
            {
                throw e;
            }
            return null;
        }
    }
}