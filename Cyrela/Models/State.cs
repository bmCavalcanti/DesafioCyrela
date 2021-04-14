using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cyrela.Models
{
    [Table("STATE")]
    public class State
    {
        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome obrigatório.")]
        [StringLength(200, ErrorMessage = "O nome deve ter no máximo 200 caracteres.")]
        [Display(Name = "Nome: ")]
        [Column("NAME")]
        public String Name { get; set; }

        [Required(ErrorMessage = "UF obrigatória.")]
        [StringLength(4, ErrorMessage = "A UF deve ter no máximo 4 caracteres.")]
        [Display(Name = "UF: ")]
        [Column("UF")]
        public String Uf { get; set; }
    }
}