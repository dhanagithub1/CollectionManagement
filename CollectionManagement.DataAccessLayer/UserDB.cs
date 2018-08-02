using CollectionManagement.BusinessEntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionManagement.DataAccessLayer
{
    public class UserDB : DBHelper, IDisposable
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
            UserModel userModel = new UserModel();

            return userModel;
        }
    }
}
