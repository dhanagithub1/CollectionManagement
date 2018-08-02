using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionManagement.BusinessEntityLayer
{
    public class UserModel : OperationModel
    {
        public string FirstName { get; set; }
        public string LatName { get; set; }
        public long UserId { get; set; }
        public int RoleId { get; set; }
    }
}
