using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionManagement.BusinessEntityLayer
{
    public class TransationServiceModel : OperationModel
    {
        public int TransactionServiceId { get; set; }
        public int CollectionTransactionId { get; set; }
        public int ServiceId { get; set; }
        public decimal Rate { get; set; }
        public int Quantity { get; set; }
        public string Remarks { get; set; }
        public string ServiceName { get; set; }
    }
}
