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
            Session.Clear();
            Session.Abandon();
            return View("Login");
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
                    if (userModel.OperationStatus == 1)
                    {
                        Session["UserModel"] = userModel;
                        return RedirectToAction("Index", "Dashboard");
                    }
                    else if (userModel.OperationStatus == 2)
                    {
                        ModelState.AddModelError("", userModel.OperationMessage);
                    }
                    return View("Login");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public ActionResult LogOut()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index");
        }
    }
}