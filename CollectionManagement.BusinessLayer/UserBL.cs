using CollectionManagement.BusinessEntityLayer;
using CollectionManagement.BusinessLayer.Interface;
using CollectionManagement.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionManagement.BusinessLayer
{
    public class UserBL : IUser
    {
        #region IDisposable implementation 

        /// <summary>
        /// overide Dispose method
        /// </summary>
        public void Dispose()
        {

        }

        #endregion IDisposable implementation

        public UserModel ValidateUser(string userName, string passwordString)
        {
            try
            {
                UserModel userModel = new UserModel();
                using (UserDB userDB = new UserDB())
                {
                    if (!String.IsNullOrEmpty(userName) && !String.IsNullOrEmpty(passwordString))
                    {
                        userModel = userDB.ValidateUser(userName, passwordString);                        
                    }
                    else
                    {
                        userModel.OperationStatus = 2;
                        userModel.OperationMessage = "Credentials are required.";
                    }
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
