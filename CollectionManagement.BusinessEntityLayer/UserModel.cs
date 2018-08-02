using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionManagement.BusinessEntityLayer
{
    [Serializable]
    public class UserModel : OperationModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public string EmailAddress { get; set; }
        public long UserId { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
