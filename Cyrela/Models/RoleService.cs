using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cyrela.Models
{
    [Table("ROLE_SERVICE")]
    public class RoleService
    {
        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Função obrigatória.")]
        [Display(Name = "Função: ")]
        [Column("ROLE_ID")]
        public int RoleId { get; set; }

        [Required(ErrorMessage = "Serviço obrigatório.")]
        [Display(Name = "Serviço: ")]
        [Column("SERVICE_ID")]
        public int ServiceId { get; set; }

        // Navigation properties
        public Role Role { get; set; }

        public Service Service { get; set; }
    }
}