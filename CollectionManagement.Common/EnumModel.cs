using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionManagement.Common
{
    public class EnumModel
    {
        public enum TransactionStatus
        {
            Pending = 1,
            Success = 2
        }
        public enum OperationStatus
        {
            Success = 1,
            Failed = 2
        }

        public enum ModeofPayment
        {
            Cash = 1,
            Cheque = 2,
            DD = 3
        }
    }
}
