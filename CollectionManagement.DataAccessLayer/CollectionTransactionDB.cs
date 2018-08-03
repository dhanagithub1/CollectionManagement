using CollectionManagement.BusinessEntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
