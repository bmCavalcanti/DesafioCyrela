using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cyrela.Models
{
    [Table("CITY")]
    public class City
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

        [Required(ErrorMessage = "Estado obrigatório.")]
        [Display(Name = "Estado: ")]
        [Column("STATE_ID")]
        public int StateId { get; set; }

        // Navigation properties
        public State State { get; set; }
    }
}