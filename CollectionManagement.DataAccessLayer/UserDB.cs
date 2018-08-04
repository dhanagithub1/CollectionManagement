using CollectionManagement.BusinessEntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CollectionManagement.Common.EnumModel;

namespace CollectionManagement.DataAccessLayer
{
    public class UserDB : DBHelper
    {        
        public UserModel ValidateUser(string userName, string passwordString)
        {
            try
            {
                UserModel userModel = new UserModel();
                DBHelperModel dbHelperModel = new DBHelperModel();
                dbHelperModel.StoredProcedureName = "dbo.AuthenticateUser";
                dbHelperModel.StoreProcedureParameters.Add(new KeyValuePair<string, string>("@Username", userName));
                dbHelperModel.StoreProcedureParameters.Add(new KeyValuePair<string, string>("@PasswordString", passwordString));

                var result = ExecuteProcedure(dbHelperModel);
                if (result.Rows.Count > 0)
                {
                    userModel.FirstName = Convert.ToString(result.Rows[0]["FirstName"]);
                    userModel.LastName = Convert.ToString(result.Rows[0]["LastName"]);
                    userModel.MobileNumber = Convert.ToString(result.Rows[0]["MobileNumber"]);
                    userModel.EmailAddress = Convert.ToString(result.Rows[0]["EmailAddress"]);
                    userModel.UserId = Convert.ToInt16(result.Rows[0]["UserId"]);
                    userModel.RoleId = Convert.ToInt16(result.Rows[0]["RoleId"]);
                    //userModel.CreatedBy = Convert.ToInt16(result["CreatedBy"]);
                    userModel.IsActive = Convert.ToInt16(result.Rows[0]["IsActive"]);
                    userModel.RoleName = Convert.ToString(result.Rows[0]["RoleName"]);
                    userModel.DepartmentName = Convert.ToString(result.Rows[0]["DepartmentName"]);
                    userModel.DepartmentId = Convert.ToInt16(result.Rows[0]["DepartmentId"]);
                    userModel.OperationStatus = (int)OperationStatus.Success;
                }
                else
                {
                    userModel.OperationStatus = (int)OperationStatus.Failed ;
                    userModel.OperationMessage = "No valid user found.";
                }
                return userModel;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
