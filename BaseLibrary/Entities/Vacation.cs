using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace BaseLibrary.Entities
{
    public class Vacation:OtherBaseEntity
    {
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public int NumberOfDays { get; set; }
        public DateTime EndDate { get; set; }

        public void CalculateEndDate()
        {
            EndDate = StartDate.AddDays(NumberOfDays - 1);
        }
        //muchos a uno relacionado con TipoDeVacaciones
        [JsonIgnore]
        public VacationType? VacationType { get; set; }
        [Required]
        public int VacationTypeId { get; set; }
    }
}
