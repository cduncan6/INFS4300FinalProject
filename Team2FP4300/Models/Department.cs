using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Team2FP4300.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Team2FP4300.Models
{
    public class Department
    {
        [Required(ErrorMessage = "Required")]
        [Key]
        public int DepartmentCode { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Department Head")]
        public int DepartmentHead { get; set; }


        public virtual ICollection<Employees> Employees { get; set; }


    }
}