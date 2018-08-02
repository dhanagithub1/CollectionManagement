using CollectionManagement.BusinessEntityLayer.ViewModel;
using CollectionManagement.BusinessLayer.Interface;
using CollectionManagement.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CollectionManagement.BusinessEntityLayer;

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
                using (IUser userBL = new UserBL())
                {
                    UserModel userModel = new UserModel();
                    userModel = userBL.ValidateUser(loginViewModel.UserName, loginViewModel.Password);
                    return RedirectToAction("Dashboard");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return null;
        }
    }
}