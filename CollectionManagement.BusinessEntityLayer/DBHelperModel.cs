using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionManagement.BusinessEntityLayer
{
   public class DBHelperModel
    {
        public List<KeyValuePair<string, string>> StoreProcedureParameters { get; set; }

        public string StoredProcedureName { get; set; }

        public DBHelperModel()
        {
            StoredProcedureName = "";
            StoreProcedureParameters = new List<KeyValuePair<string, string>>();
        }
    }
}
