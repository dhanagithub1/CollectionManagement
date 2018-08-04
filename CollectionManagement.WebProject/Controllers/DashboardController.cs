using CollectionManagement.BusinessEntityLayer;
using CollectionManagement.BusinessEntityLayer.ViewModel;
using CollectionManagement.BusinessLayer;
using CollectionManagement.BusinessLayer.Interface;
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
            if (userModel.RoleId == 2)
            { return RedirectToAction("ApplicationForm"); }
            if (userModel.RoleId == 3)
            { return RedirectToAction("CollectionCenter"); }
            return View();
        }

        public ActionResult ApplicationForm()
        {
            try
            {
                CollectionTransactionViewModel collectionTransactionViewModel = new CollectionTransactionViewModel();
                using (ICollectionTransaction collectionTransactionBL = new CollectionTransactionBL())
                {
                    collectionTransactionViewModel.DepartmentModelList = collectionTransactionBL.GetAllDepartments();
                    collectionTransactionViewModel.ServiceModelList = new List<ServiceModel>();
                }
                return View(collectionTransactionViewModel);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public ActionResult GetServiceByDept(int deptId)
        {
            try
            {
                List<ServiceModel> serviceModelList = new List<ServiceModel>();
                using (ICollectionTransaction collectionTransactionBL = new CollectionTransactionBL())
                {
                    serviceModelList = collectionTransactionBL.GetAllServices(deptId);
                }
                return Json(serviceModelList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public ActionResult AddApplicationForm(CollectionTransactionViewModel collectionTransactionViewModel)
        {
            try
            {
                UserModel userModel = new UserModel();
                userModel = (UserModel)Session["UserModel"];
                collectionTransactionViewModel.CreatedBy = userModel.UserId;
                using (ICollectionTransaction collectionTransactionBL = new CollectionTransactionBL())
                {
                    OperationModel operationModel = collectionTransactionBL.AddTransactionData(collectionTransactionViewModel);
                    return Json(new { result = operationModel.OperationMessage }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public ActionResult CollectionCenter()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetTransactionData(string txnid)
        {
            try
            {
                using (ICollectionTransaction collectionTransactionBL = new CollectionTransactionBL())
                {
                    CollectionTransactionViewModel collectionTransactionViewModel = collectionTransactionBL.GetCollectionTransactionDetails(txnid);
                    return View("_TransactionData", collectionTransactionViewModel);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}