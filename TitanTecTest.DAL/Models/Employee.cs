using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitanTecTest.DAL.Helpers;
using TitanTecTest.DAL.Helpers.Interfaces;
using TitanTecTest.DAL.Models.EntityBase;

namespace TitanTecTest.DAL.Models
{
    public class Employee : EntityBaseModel, ISoftDelete
    {
        public Employee()
        {
            Files = new HashSet<EmployeeFile>();
        }
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Department { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [StringLength(500)]
        public string Address { get; set; }

        public ICollection<EmployeeFile> Files { get; set; }
        public bool IsDeleted { get ; set ; }
   
    }
}
