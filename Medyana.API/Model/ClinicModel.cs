using System.ComponentModel.DataAnnotations;

namespace Medyana.API.Model
{
    public class ClinicModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} alanı gereklidir.")] public string Name { get; set; }
    }
}