using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cyrela.Models
{
    [Table("SCHEDULING_STATUS")]
    public class SchedulingStatus
    {
        public static int WAITING = 1;
        public static int FINISHED = 2;
        public static int CANCELED = 3;

        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome obrigatório.")]
        [StringLength(50, ErrorMessage = "O nome deve ter no máximo {1} caracteres.")]
        [Column("NAME")]
        public String Name { get; set; }
    }
}