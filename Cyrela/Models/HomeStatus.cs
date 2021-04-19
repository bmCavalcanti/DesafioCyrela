using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cyrela.Models
{
    [Table("HOME_STATUS")]
    public class HomeStatus
    {
        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome obrigatório.")]
        [StringLength(50, ErrorMessage = "O nome deve ter no máximo {1} caracteres.")]
        [Column("NAME")]
        public String Name { get; set; }

        [Required(ErrorMessage = "Ordem obrigatória.")]
        [Column("STATUS_ORDER")]
        public double StatusOrder { get; set; }
    }
}