using CollectionManagement.BusinessEntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionManagement.BusinessLayer.Interface
{
    public interface IUser : IDisposable
    {
        UserModel ValidateUser(string userName, string passwordString);
    }
}
