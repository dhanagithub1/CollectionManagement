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
    }
}


