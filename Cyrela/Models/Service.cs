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
        [StringLength(50, ErrorMessage = "O nome deve ter no máximo 50 caracteres.")]
        [Display(Name = "Nome: ")]
        [Column("NAME")]
        public String Name { get; set; }

        [Required(ErrorMessage = "Meses de garantia obrigatório.")]
        [Display(Name = "Meses de garantia: ")]
        [Column("MONTHS_WARRANTY")]
        public int MonthsWarranty { get; set; }

        [StringLength(250, ErrorMessage = "O bloco deve ter no máximo 250 caracteres.")]
        [Display(Name = "Descrição: ")]
        [Column("DESCRIPTION")]
        public String Description { get; set; }
    }
}