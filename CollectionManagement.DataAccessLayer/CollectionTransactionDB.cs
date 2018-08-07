using CollectionManagement.BusinessEntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CollectionManagement.Common.EnumModel;

namespace CollectionManagement.DataAccessLayer
{
    public class CollectionTransactionDB : DBHelper
    {
        public List<ServiceModel> GetAllServices(int departmentId)
        {
            try
            {
                List<ServiceModel> serviceList = new List<ServiceModel>();
                DBHelperModel dbHelperModel = new DBHelperModel();
                dbHelperModel.StoredProcedureName = "dbo.GetAllServices";
                dbHelperModel.StoreProcedureParameters.Add(new KeyValuePair<string, string>("@DepartmentId", departmentId.ToString()));

                var result = ExecuteProcedure(dbHelperModel);
                if (result.Rows.Count > 0)
                {
                    for (int i = 0; i < result.Rows.Count; i++)
                    {
                        ServiceModel serviceModel = new ServiceModel();
                        serviceModel.ServiceNameEnglish = Convert.ToString(result.Rows[i]["ServiceNameEnglish"]);
                        serviceModel.ServiceNameMarathi = Convert.ToString(result.Rows[i]["ServiceNameMarathi"]);
                        serviceModel.FunctionCode = Convert.ToString(result.Rows[i]["FunctionCode"]);
                        serviceModel.ObjectCode = Convert.ToString(result.Rows[i]["ObjectCode"]);
                        serviceModel.ServiceId = Convert.ToInt16(result.Rows[i]["ServiceId"]);
                        serviceModel.DepartmentId = Convert.ToInt16(result.Rows[i]["DepartmentId"]);
                        serviceModel.IsActive = Convert.ToInt16(result.Rows[i]["IsActive"]);
                        serviceModel.OperationStatus = 1;
                        serviceList.Add(serviceModel);
                    }
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
                DBHelperModel dbHelperModel = new DBHelperModel();
                dbHelperModel.StoredProcedureName = "dbo.GetAllDepartments";

                var result = ExecuteProcedure(dbHelperModel);
                if (result.Rows.Count > 0)
                {
                    for (int i = 0; i < result.Rows.Count; i++)
                    {
                        DepartmentModel departmentModel = new DepartmentModel();
                        departmentModel.DepartmentNameEnglish = Convert.ToString(result.Rows[i]["DepartmentNameEnglish"]);
                        departmentModel.DepartmentNameMarathi = Convert.ToString(result.Rows[i]["DepartmentNameMarathi"]);
                        departmentModel.DepartmentId = Convert.ToInt16(result.Rows[i]["DepartmentId"]);
                        departmentModel.IsActive = Convert.ToInt16(result.Rows[i]["IsActive"]);
                        departmentModel.OperationStatus = 1;
                        departmentList.Add(departmentModel);
                    }
                }
                return departmentList;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public OperationModel AddTransactionData(CollectionTransactionModel collectionTransactionModel, DataTable dataTable)
        {
            try
            {
                OperationModel operationModel = new OperationModel();
                DBHelperModel dbHelperModel = new DBHelperModel();
                dbHelperModel.StoredProcedureName = "dbo.AddTransactionData";
                dbHelperModel.StoreProcedureParameters.Add(new KeyValuePair<string, string>("@DepartmentId", collectionTransactionModel.DepartmentId.ToString()));
                dbHelperModel.StoreProcedureParameters.Add(new KeyValuePair<string, string>("@TransactionId", collectionTransactionModel.TransactionId));
                dbHelperModel.StoreProcedureParameters.Add(new KeyValuePair<string, string>("@TransactionStatus", collectionTransactionModel.TransactionStatus.ToString()));
                dbHelperModel.StoreProcedureParameters.Add(new KeyValuePair<string, string>("@ApplicantName", collectionTransactionModel.ApplicantName));
                dbHelperModel.StoreProcedureParameters.Add(new KeyValuePair<string, string>("@MobileNumber", collectionTransactionModel.MobileNumber));
                dbHelperModel.StoreProcedureParameters.Add(new KeyValuePair<string, string>("@Address", collectionTransactionModel.Address));
                dbHelperModel.StoreProcedureParameters.Add(new KeyValuePair<string, string>("@AadhaarNumber", collectionTransactionModel.AadhaarNumber));
                dbHelperModel.StoreProcedureParameters.Add(new KeyValuePair<string, string>("@PanNumber", collectionTransactionModel.PanNumber));
                dbHelperModel.StoreProcedureParameters.Add(new KeyValuePair<string, string>("@ApplicantGSTNumber", collectionTransactionModel.ApplicantGSTNumber));
                dbHelperModel.StoreProcedureParameters.Add(new KeyValuePair<string, string>("@TotalAmount", collectionTransactionModel.TotalAmount.ToString()));
                //dbHelperModel.StoreProcedureParameters.Add(new KeyValuePair<string, string>("@CreatedOn", DateTime.Now.ToString()));
                dbHelperModel.StoreProcedureParameters.Add(new KeyValuePair<string, string>("@CreatedBy", collectionTransactionModel.CreatedBy.ToString()));
                dbHelperModel.StoreProcedureParameters.Add(new KeyValuePair<string, string>("@Remarks", collectionTransactionModel.Remarks));

                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@TransactionList";
                parameter.SqlDbType = System.Data.SqlDbType.Structured;
                parameter.Value = dataTable;
                dbHelperModel.SqlParameter = parameter;

                string transactionId = "";

                var result = ExecuteNonQuery(dbHelperModel, out transactionId);
                if (result != 0)
                {
                    operationModel.OperationStatus = (int)OperationStatus.Success;
                    operationModel.OperationMessage = "Success";
                    operationModel.OperationLogId = transactionId.Trim();
                }
                else
                {
                    operationModel.OperationStatus = (int)OperationStatus.Failed;
                    operationModel.OperationMessage = "ERROR";
                }
                return operationModel;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public CollectionTransactionModel GetTransactionData(string txnId)
        {
            try
            {
                CollectionTransactionModel collectionTransactionModel = new CollectionTransactionModel();
                DBHelperModel dbHelperModel = new DBHelperModel();
                dbHelperModel.StoredProcedureName = "dbo.GetTransactionData";
                dbHelperModel.StoreProcedureParameters.Add(new KeyValuePair<string, string>("@TransactionId", txnId));
                var result = ExecuteProcedure(dbHelperModel);

                collectionTransactionModel.TransactionId = Convert.ToString(result.Rows[0]["TransactionId"]);
                collectionTransactionModel.CollectionTransactionId = Convert.ToInt16(result.Rows[0]["CollectionTransactionId"]);
                collectionTransactionModel.TransactionStatus = Convert.ToInt16(result.Rows[0]["TransactionStatus"]);
                collectionTransactionModel.ApplicantName = Convert.ToString(result.Rows[0]["ApplicantName"]);
                collectionTransactionModel.MobileNumber = Convert.ToString(result.Rows[0]["MobileNumber"]);
                collectionTransactionModel.Address = Convert.ToString(result.Rows[0]["Address"]);
                collectionTransactionModel.ApplicantGSTNumber = Convert.ToString(result.Rows[0]["ApplicantGSTNumber"]);
                collectionTransactionModel.TotalAmount = Convert.ToDecimal(result.Rows[0]["TotalAmount"]);
                collectionTransactionModel.Remarks = Convert.ToString(result.Rows[0]["Remarks"]);
                collectionTransactionModel.DepartmentName = Convert.ToString(result.Rows[0]["DepartmentName"]);
                collectionTransactionModel.OperationStatus = (int)OperationStatus.Success;

                return collectionTransactionModel;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<TransationServiceModel> GetTransationServices(int collectionTxnId)
        {
            try
            {
                List<TransationServiceModel> transationServiceModels = new List<TransationServiceModel>();
                DBHelperModel dbHelperModel = new DBHelperModel();
                dbHelperModel.StoredProcedureName = "dbo.GetTransactionServices";
                dbHelperModel.StoreProcedureParameters.Add(new KeyValuePair<string, string>("@TransactionId", collectionTxnId.ToString()));
                var result = ExecuteProcedure(dbHelperModel);

                if (result.Rows.Count > 0)
                {
                    for (int i = 0; i < result.Rows.Count; i++)
                    {
                        TransationServiceModel transationServiceModel = new TransationServiceModel();
                        transationServiceModel.ServiceId = Convert.ToInt16(result.Rows[i]["ServiceId"]);
                        transationServiceModel.TransactionServiceId = Convert.ToInt16(result.Rows[i]["TransactionServiceId"]);
                        transationServiceModel.Rate = Convert.ToDecimal(result.Rows[i]["Rate"]);
                        transationServiceModel.Quantity = Convert.ToInt16(result.Rows[i]["Quantity"]);
                        transationServiceModel.ServiceName = Convert.ToString(result.Rows[i]["ServiceName"]);
                        transationServiceModel.Remarks = Convert.ToString(result.Rows[i]["Remarks"]);
                        transationServiceModel.OperationStatus = (int)OperationStatus.Success;
                        transationServiceModels.Add(transationServiceModel);
                    }
                }
                return transationServiceModels;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public ServiceModel GetServicebyId(int serviceId)
        {
            try
            {
                ServiceModel serviceModel = new ServiceModel();
                DBHelperModel dbHelperModel = new DBHelperModel();
                dbHelperModel.StoredProcedureName = "dbo.GetServicebyId";
                dbHelperModel.StoreProcedureParameters.Add(new KeyValuePair<string, string>("@ServiceId", serviceId.ToString()));

                var result = ExecuteProcedure(dbHelperModel);
                if (result.Rows.Count > 0)
                {
                    serviceModel.ServiceNameEnglish = Convert.ToString(result.Rows[0]["ServiceNameEnglish"]);
                    serviceModel.ServiceNameMarathi = Convert.ToString(result.Rows[0]["ServiceNameMarathi"]);
                    serviceModel.FunctionCode = Convert.ToString(result.Rows[0]["FunctionCode"]);
                    serviceModel.ObjectCode = Convert.ToString(result.Rows[0]["ObjectCode"]);
                    serviceModel.ServiceId = Convert.ToInt16(result.Rows[0]["ServiceId"]);
                    serviceModel.DepartmentId = Convert.ToInt16(result.Rows[0]["DepartmentId"]);
                    serviceModel.IsActive = Convert.ToInt16(result.Rows[0]["IsActive"]);
                    serviceModel.OperationStatus = 1;
                }
                return serviceModel;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
