using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TitanTecTest.DAL.Models.EntityBase
{
    public interface IEntityBaseModel
    {
        [Required]
        [Column(nameof(EntityBaseModel.CreationTime))]
        DateTime CreationTime { get; set; }


        [Column(nameof(EntityBaseModel.LastModificationTime))]
        DateTime? LastModificationTime { get; set; }

        [Column(nameof(EntityBaseModel.DeletionTime))]
        DateTime? DeletionTime { get; set; }
        bool IsActive { get; set; }




    }
}
