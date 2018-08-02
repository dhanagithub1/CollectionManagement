using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionManagement.BusinessEntityLayer
{
    public class ServiceModel : OperationModel
    {

        public int ServiceId { get; set; }
        public string ServiceNameEnglish { get; set; }
        public string ServiceNameMarathi { get; set; }
        public string FunctionCode { get; set; }
        public string ObjectCode { get; set; }
        public string DepartmentId { get; set; }
        public string Remarks { get; set; }
    }
}
