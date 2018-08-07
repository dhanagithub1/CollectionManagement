using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionManagement.BusinessEntityLayer
{
    public class EmailMessageModel
    {
        public string SenderEmailAddress { get; set; }
        public string EmailSubject { get; set; }
        public string ReceiverEmailAddress { get; set; }
        public string TemplatePath { get; set; }
        public string ApplicantName { get; set; }
        public string TransactionId { get; set; }
    }
}
