using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Team2FP4300.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Team2FP4300.Models
{
    public class Employees
    {
        [Required(ErrorMessage = "Required")]
        [Key]
        public int EmployeeId { get; set; } // This column will be the auto-generated primary key.

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Department Code")]
        public int DepartmentCode { get; set; } // in case of database this would be the foreign key

        [Required(ErrorMessage = "Required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }

        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Date required")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime HireDate { get; set; }

        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "Required")]
        public string ImgFileName { get; set; }

        [Display(Name = "Full Name")]
        public string FullName // no setter: read only ptoperty
        {
            get
            {
                return FirstName + ", " + LastName;
            }
        }
        public virtual ICollection<Department> Departments { get; set; }

    }
}