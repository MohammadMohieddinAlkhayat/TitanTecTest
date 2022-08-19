using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TitanTecTest.DAL.Models.EntityBase
{
    public class EntityBaseModel : IEntityBaseModel
    {

        [Key]
        public int Id { get; set; }
        public EntityBaseModel()
        {
            CreationTime = DateTime.Now;
        }

        [Required]
        [Column(nameof(CreationTime))]
        public DateTime CreationTime { get; set; }

        [Column(nameof(LastModificationTime))]
        public DateTime? LastModificationTime { get; set; }

        [Column(nameof(DeletionTime))]
        public DateTime? DeletionTime { get; set; }

        public bool IsActive { get; set; }

    }
}
