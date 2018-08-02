using CollectionManagement.BusinessEntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CollectionManagement.WebProject.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            UserModel userModel = new UserModel();
            userModel = (UserModel)Session["UserModel"];
            return View();
        }
    }
}