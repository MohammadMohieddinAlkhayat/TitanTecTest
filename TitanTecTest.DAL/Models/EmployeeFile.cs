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
    public class EmployeeFile: EntityBaseModel, ISoftDelete
    {
        [StringLength(500)]
        public string Name { get; set; }
        public long FileSize { get; set; }
        public bool IsDeleted { get; set; }

        public int EmployeeId { get; set; }
    }
}
