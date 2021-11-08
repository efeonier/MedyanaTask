using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Medyana.Core.Entity;
using Medyana.Core.Enums;

namespace Medyana.API.Model
{
    public class PatientModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} alanı gereklidir.")]  public string Name { get; set; }
        [Required(ErrorMessage = "{0} alanı gereklidir.")] public string SurName { get; set; }

        [Required(ErrorMessage = "{0} alanı gereklidir.")] 
        [DisplayFormat(DataFormatString = "{0:dd/mm/YYYY}")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "{0} alanı gereklidir.")]  public Gender Gender { get; set; }
        [Required(ErrorMessage = "{0} alanı gereklidir.")]  public int CitizenshipNumber { get; set; }
        [Required(ErrorMessage = "{0} alanı gereklidir.")]  public int Phone { get; set; }

        [Required(ErrorMessage = "{0} alanı gereklidir.")] 
        [DisplayFormat(DataFormatString = "{0:dd/mm/YYYY SS:DD}")]
        public DateTime VisitDate { get; set; }


        [DisplayFormat(DataFormatString = "{0:dd/mm/YYYY SS:DD}")]
        public DateTime NextVisitDate { get; set; }

        public ICollection<PatientNotes> Notes { get; set; }
        public Doctor Doctor { get; set; }
        public Clinic Clinic { get; set; }
    }
}