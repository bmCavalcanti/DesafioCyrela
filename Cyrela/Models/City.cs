using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cyrela.Models
{
    [Table("city")]
    public class City
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome obrigatório.")]
        [StringLength(200, ErrorMessage = "O nome deve ter no máximo 200 caracteres.")]
        [Display(Name = "Nome: ")]
        [Column("name")]
        public String Name { get; set; }

        [Required(ErrorMessage = "Estado obrigatório.")]
        [Display(Name = "Estado: ")]
        [Column("state_id")]
        public State State { get; set; }
    }
}