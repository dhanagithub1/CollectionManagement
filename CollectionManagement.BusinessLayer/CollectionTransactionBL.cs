using CollectionManagement.BusinessEntityLayer;
using CollectionManagement.BusinessEntityLayer.ViewModel;
using CollectionManagement.BusinessLayer.Interface;
using CollectionManagement.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CollectionManagement.Common.EnumModel;

namespace CollectionManagement.BusinessLayer
{
    public class CollectionTransactionBL : ICollectionTransaction
    {
        #region IDisposable implementation 

        /// <summary>
        /// overide Dispose method
        /// </summary>
        public void Dispose()
        {

        }

        #endregion IDisposable implementation

        public List<ServiceModel> GetAllServices(int departmentId)
        {
            try
            {
                List<ServiceModel> serviceList = new List<ServiceModel>();
                using (CollectionTransactionDB collectionTransactionDB = new CollectionTransactionDB())
                {
                    serviceList = collectionTransactionDB.GetAllServices(departmentId);
                }
                return serviceList;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<DepartmentModel> GetAllDepartments()
        {
            try
            {
                List<DepartmentModel> departmentList = new List<DepartmentModel>();
                using (CollectionTransactionDB collectionTransactionDB = new CollectionTransactionDB())
                {
                    departmentList = collectionTransactionDB.GetAllDepartments();
                }
                return departmentList;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public OperationModel AddTransactionData(CollectionTransactionViewModel collectionTransactionViewModel)
        {
            try
            {
                OperationModel operationModel = new OperationModel();
                CollectionTransactionModel collectionTransactionModel = new CollectionTransactionModel();

                collectionTransactionModel.ApplicantName = collectionTransactionViewModel.ApplicantName;
                collectionTransactionModel.MobileNumber = collectionTransactionViewModel.MobileNumber;
                collectionTransactionModel.Address = collectionTransactionViewModel.Address;
                collectionTransactionModel.AadhaarNumber = collectionTransactionViewModel.AadhaarNumber;
                collectionTransactionModel.PanNumber = collectionTransactionViewModel.PanNumber;
                collectionTransactionModel.ApplicantGSTNumber = collectionTransactionViewModel.ApplicantGSTNumber;
                collectionTransactionModel.TotalAmount = collectionTransactionViewModel.TotalAmount;
                collectionTransactionModel.CreatedBy = collectionTransactionViewModel.CreatedBy;
                collectionTransactionModel.TransactionId = Guid.NewGuid().ToString();
                collectionTransactionModel.TransactionStatus = (int)TransactionStatus.Pending;
                collectionTransactionModel.Remarks = collectionTransactionViewModel.Remarks;
                collectionTransactionModel.DepartmentId = collectionTransactionViewModel.DepartmentId;

                DataTable dataTable = new DataTable("dbo.TransactionServiceList");

                dataTable.Columns.Add("ServiceId", typeof(Int16));
                dataTable.Columns.Add("Rate", typeof(decimal));
                dataTable.Columns.Add("Quantity", typeof(Int16));
                dataTable.Columns.Add("Remarks", typeof(string));

                for (int i = 0; i < collectionTransactionViewModel.TransactionServiceModelList.Count; i++)
                {
                    DataRow dr = dataTable.NewRow();
                    dr["ServiceId"] = collectionTransactionViewModel.TransactionServiceModelList[i].ServiceId;
                    dr["Rate"] = collectionTransactionViewModel.TransactionServiceModelList[i].Rate;
                    dr["Quantity"] = collectionTransactionViewModel.TransactionServiceModelList[i].Quantity;
                    dr["Remarks"] = collectionTransactionViewModel.TransactionServiceModelList[i].Remarks;
                    dataTable.Rows.Add(dr);
                }

                using (CollectionTransactionDB collectionTransactionDB = new CollectionTransactionDB())
                {
                    operationModel = collectionTransactionDB.AddTransactionData(collectionTransactionModel, dataTable);
                }
                return operationModel;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public CollectionTransactionViewModel GetCollectionTransactionDetails(string txnId)
        {
            try
            {
                CollectionTransactionViewModel collectionTransactionViewModel = new CollectionTransactionViewModel();
                CollectionTransactionModel collectionTransactionModel = new CollectionTransactionModel();
                using (CollectionTransactionDB collectionTransactionDB = new CollectionTransactionDB())
                {
                    collectionTransactionModel = collectionTransactionDB.GetTransactionData(txnId);
                    collectionTransactionViewModel.TransactionServiceModelList= collectionTransactionDB.GetTransationServices(collectionTransactionModel.CollectionTransactionId);
                    collectionTransactionViewModel.ApplicantName = collectionTransactionModel.ApplicantName;
                    collectionTransactionViewModel.MobileNumber = collectionTransactionModel.MobileNumber;
                    collectionTransactionViewModel.Address = collectionTransactionModel.Address;
                    collectionTransactionViewModel.AadhaarNumber = collectionTransactionModel.AadhaarNumber;
                    collectionTransactionViewModel.PanNumber = collectionTransactionModel.PanNumber;
                    collectionTransactionViewModel.ApplicantGSTNumber = collectionTransactionModel.ApplicantGSTNumber;
                    collectionTransactionViewModel.TotalAmount = collectionTransactionModel.TotalAmount;
                    collectionTransactionViewModel.CreatedBy = collectionTransactionModel.CreatedBy;
                    collectionTransactionViewModel.TransactionId = collectionTransactionModel.TransactionId;
                    collectionTransactionViewModel.TransactionStatus = collectionTransactionModel.TransactionStatus;
                    collectionTransactionViewModel.Remarks = collectionTransactionModel.Remarks;
                    collectionTransactionViewModel.DepartmentName = collectionTransactionModel.DepartmentName;
                }
                return collectionTransactionViewModel;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}


