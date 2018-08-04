using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionManagement.BusinessEntityLayer.ViewModel
{
    public class CollectionTransactionViewModel
    {
        public int CollectionTransactionId { get; set; }
        public string TransactionId { get; set; }
        public int TransactionStatus { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string ApplicantName { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string MobileNumber { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string Address { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string AadhaarNumber { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string PanNumber { get; set; }
        public string ApplicantGSTNumber { get; set; }
        public decimal TotalAmount { get; set; }
        public string ChequeNumber { get; set; }
        public string DDNumber { get; set; }
        public string BankName { get; set; }
        public string BankAddress { get; set; }
        public List<ServiceModel> ServiceModelList { get; set; }
        public List<DepartmentModel> DepartmentModelList { get; set; }
        public List<TransationServiceModel> TransactionServiceModelList { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public int DepartmentId { get; set; }
        public long CreatedBy { get; set; }
        public string Remarks { get; set; }
        public string DepartmentName { get; set; }
    }
}
