using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medyana.Core.Entity
{
    [Table("Clinic")]
    public class Clinic : BaseEntity
    {
        [Key] public int Id { get; set; }

        [Required]
        [MaxLength(4), MinLength(1)]
        public string Name { get; set; }

        public ICollection<Patient> Patient { get; set; }
    }
}