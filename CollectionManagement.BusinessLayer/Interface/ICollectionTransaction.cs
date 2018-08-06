using CollectionManagement.BusinessEntityLayer;
using CollectionManagement.BusinessEntityLayer.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionManagement.BusinessLayer.Interface
{
    public interface ICollectionTransaction : IDisposable
    {
        List<ServiceModel> GetAllServices(int departmentId);
        List<DepartmentModel> GetAllDepartments();
        OperationModel AddTransactionData(CollectionTransactionViewModel collectionTransactionViewModel);
        CollectionTransactionViewModel GetCollectionTransactionDetails(string txnId);
        ServiceModel GetServicebyId(int serviceId);
    }
}
