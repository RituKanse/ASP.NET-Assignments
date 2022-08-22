using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EntityFramework.Models
{
    public class mvcCustomerModel
    {
        public int CustomerID { get; set; }
        [Required(ErrorMessage="This Field is Required")]
        public string CustomerName { get; set; }
        public string City { get; set; }
        public Nullable<int> Age { get; set; }
        public Nullable<int> Phone { get; set; }
        public Nullable<int> Pincode { get; set; }
    }
}