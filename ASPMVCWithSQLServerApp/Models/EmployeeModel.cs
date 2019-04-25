using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ASPMVCWithSQLServerApp.Models
{
    public class EmployeeModel
    {
        [Display(Name = "ID")]
        public int EmpID { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
    }
}