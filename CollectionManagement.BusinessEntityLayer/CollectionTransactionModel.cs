using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionManagement.BusinessEntityLayer
{
    public class CollectionTransactionModel : OperationModel
    {
        public int CollectionTransactionId { get; set; }
        public string TransactionId { get; set; }
        public int TransactionStatus { get; set; }
        public string ApplicantName { get; set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; }
        public string AadhaarNumber { get; set; }
        public string PanNumber { get; set; }
        public string ApplicantGSTNumber { get; set; }
        public decimal TotalAmount { get; set; }
        public string ChequeNumber { get; set; }
        public string DDNumber { get; set; }
        public string BankName { get; set; }
        public string BankAddress { get; set; }
        public string Remarks { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int Denomination2K { get; set; }
        public int Denomination5H { get; set; }
        public int Denomination2H { get; set; }
        public int Denomination1H { get; set; }
        public int ModeOfPayment { get; set; }
        public long UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
