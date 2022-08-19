using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TitanTecTest.BL.Services.Employees.Dtos
{
    public class UpdateEmployeeDto:CreateEmployeeDto
    {
        [Required]
        public int Id { get; set; }
    }
}
