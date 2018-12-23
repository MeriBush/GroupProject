using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeManagementSystem.Models
{
    public class Employee
    {
        [DisplayName("ID")]
        public int EmpId { get; set; }
        [DisplayName("Name")]
        [Required]
        public string EmpName { get; set; }
        [DisplayName("Salary($)")]
        public float? EmpSalary { get; set; }

        [DisplayName("Position")]
        public string EmpPosition { get; set; }

        [DisplayName("Department Name")]
        public string EmpDepartment { get; set; }

        [DisplayFormat(DataFormatString ="{0:MM/dd/yyyy}")]
        [DisplayName("Date Of Joining")]
        [Required]
        public DateTime EmpJoinDate { get; set; }
    }
}