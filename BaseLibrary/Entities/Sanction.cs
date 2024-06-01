using System.ComponentModel.DataAnnotations;
namespace BaseLibrary.Entities
{
    public class Sanction : OtherBaseEntity
    {
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Punishment { get; set; } = string.Empty;
        [Required]
        public DateTime PunishmentDate { get; set; }
        
        //Muchos a uno relasionado con Tipo de vacaiones
        public SanctionType? SanctionType { get; set; }
    }
}