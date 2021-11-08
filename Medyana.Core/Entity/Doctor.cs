using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medyana.Core.Entity
{
    [Table("Doctor")]
    public class Doctor : BaseEntity
    {
        [Key] public int Id { get; set; }

        [Required] [MaxLength(200)] public string Name { get; set; }

        [Required] public int RegistirationCode { get; set; }

        public ICollection<Patient> Patient { get; set; }
    }
}