using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TitanTecTest.BL.Services.Employees.Dtos
{
    public class CreateEmployeeDto
    {
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Department { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [StringLength(500)]
        public string Address { get; set; }
        public List<string> EmployeeFiles { get; set; }
    }
}
