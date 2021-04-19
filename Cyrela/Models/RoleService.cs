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
        [Column("ROLE_ID")]
        [ForeignKey("ROLE_ID")]
        public int RoleId { get; set; }

        [Required(ErrorMessage = "Serviço obrigatório.")]
        [Column("SERVICE_ID")]
        [ForeignKey("SERVICE_ID")]
        public int ServiceId { get; set; }

        // Navigation properties
        public Service Service { get; set; }
    }
}