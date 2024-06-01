using System.ComponentModel.DataAnnotations;
namespace BaseLibrary.Entities
{
    public class Vacation:OtherBaseEntity
    {
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public int NumberODays { get; set; }
        public DateTime EndDate => StartDate.AddDays(NumberODays);
        //muchos a uno relacionado con TipoDeVacaciones
        public VacationType? VacationType { get; set; }
        [Required]
        public int VacationTypeId { get; set; }
    }
}
