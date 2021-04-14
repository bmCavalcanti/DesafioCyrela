using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cyrela.Models
{
    [Table("CLIENT")]
    public class Client
    {
        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome obrigatório.")]
        [StringLength(50, ErrorMessage = "O nome deve ter no máximo 50 caracteres.")]
        [Display(Name = "Nome: ")]
        [Column("FIRST_NAME")]
        public String FirstName { get; set; }

        [Required(ErrorMessage = "Sobrenome obrigatório.")]
        [StringLength(80, ErrorMessage = "O sobrenome deve ter no máximo 80 caracteres.")]
        [Display(Name = "Sobrenome: ")]
        [Column("LAST_NAME")]
        public String LastName { get; set; }
    }
}