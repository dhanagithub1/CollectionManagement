using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionManagement.BusinessEntityLayer.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="This field is required.")]       
        public string UserName { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
