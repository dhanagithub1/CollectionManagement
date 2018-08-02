using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionManagement.BusinessEntityLayer
{
    [Serializable]
    public class OperationModel
    {
        public int OperationStatus { get; set; }
        public string OperationMessage { get; set; }

        //AuditFields
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public int IsActive { get; set; }
    }
}
