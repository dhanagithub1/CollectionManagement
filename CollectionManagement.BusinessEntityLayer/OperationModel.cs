﻿using System;
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
        public string OperationLogId { get; set; }

        //AuditFields
        public DateTime CreatedOn { get; set; }
        public long CreatedBy { get; set; }
        public int IsActive { get; set; }
    }
}
