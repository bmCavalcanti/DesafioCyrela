using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cyrela.Models
{
    [Table("SCHEDULING_TYPE")]
    public class SchedulingType
    {
        public static int TECHNICAL_ASSISTANCE = 1;
        public static int INSPECTION = 2;

        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome obrigatório.")]
        [StringLength(50, ErrorMessage = "O nome deve ter no máximo 50 caracteres.")]
        [Display(Name = "Nome: ")]
        [Column("NAME")]
        public String Name { get; set; }
    }
}