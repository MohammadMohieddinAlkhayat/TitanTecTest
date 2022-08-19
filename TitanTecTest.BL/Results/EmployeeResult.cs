using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TitanTecTest.BL.Results
{
    public class EmployeeResult:Result
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Department { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [StringLength(500)]
        public string Address { get; set; }

        public List<string> Files { get; set; }
    }
}
