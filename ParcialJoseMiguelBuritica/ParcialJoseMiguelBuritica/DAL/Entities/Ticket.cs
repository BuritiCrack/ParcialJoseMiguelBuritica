using System.ComponentModel.DataAnnotations;

namespace ParcialJoseMiguelBuritica.DAL.Entities
{
    public class Ticket
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime? UseDate { get; set; }
        public bool IsUsed { get; set; }

        [Display(Name = "Localidad")]
        [MaxLength(10, ErrorMessage = "El campo {0} debe tener como maximo {1} caracteres")]
        public String? EntranceGate { get; set; }
    }
}
