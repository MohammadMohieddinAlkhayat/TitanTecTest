using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitanTecTest.BL.Helpers;
using TitanTecTest.DAL.Models;

namespace TitanTecTest.BL.Services.Employees.Dtos
{
    public class EmployeeDto: EntityBaseDto
    {
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Department { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [StringLength(500)]
        public string Address { get; set; }

        public List<EmployeeFile> Files { get; set; }
    }
}
