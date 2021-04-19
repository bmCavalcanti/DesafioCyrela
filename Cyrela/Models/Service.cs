using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cyrela.Models
{
    [Table("SERVICE")]
    public class Service
    {
        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome obrigatório.")]
        [StringLength(50, ErrorMessage = "O nome deve ter no máximo {1} caracteres.")]
        [Column("NAME")]
        public String Name { get; set; }

        [Required(ErrorMessage = "Meses de garantia obrigatório.")]
        [Column("MONTHS_WARRANTY")]
        public int MonthsWarranty { get; set; }

        [StringLength(250, ErrorMessage = "O bloco deve ter no máximo {1} caracteres.")]
        [Column("DESCRIPTION")]
        public String Description { get; set; }

        [Required(ErrorMessage = "A duração em horas do serviço é obrigatória.")]
        [Column("SERVICE_DURATION")]
        public int ServiceDuration { get; set; }
    }
}