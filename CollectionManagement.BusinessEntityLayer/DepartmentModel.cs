using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionManagement.BusinessEntityLayer
{
    public class DepartmentModel : OperationModel
    {
        public int DepartmentId { get; set; }
        public string DepartmentNameEnglish { get; set; }
        public string DepartmentNameMarathi { get; set; }        
    }
}
