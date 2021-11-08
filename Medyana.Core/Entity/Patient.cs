using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Medyana.Core.Enums;

namespace Medyana.Core.Entity
{
    [Table("Patient")]
    public class Patient : BaseEntity
    {
        [Key] public int Id { get; set; }

        [Required] public string Name { get; set; }
        [Required] public string SurName { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        [DisplayFormat(DataFormatString = "{0:dd/mm/YYYY}")]
        public DateTime BirthDate { get; set; }

        [Required]  [Column(TypeName = "int")] public Gender Gender { get; set; }
        [Required] public int CitizenshipNumber { get; set; }
        [Required] public int Phone { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        [DisplayFormat(DataFormatString = "{0:dd/mm/YYYY SS:DD}")]
        public DateTime VisitDate { get; set; }

        [Column(TypeName = "Date")]
        [DisplayFormat(DataFormatString = "{0:dd/mm/YYYY SS:DD}")]
        public DateTime NextVisitDate { get; set; }

        public ICollection<PatientNotes> Notes { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Clinic Clinic { get; set; }
    }
}