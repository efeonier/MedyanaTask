using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medyana.Core.Entity
{
    [Table("PatientNotes")]
    public class PatientNotes : BaseEntity
    {
        [Key] public int Id { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }

        [Required] [MaxLength(1000)] public string DoctorNotes { get; set; }

        public virtual Patient Patient { get; set; }
    }
}