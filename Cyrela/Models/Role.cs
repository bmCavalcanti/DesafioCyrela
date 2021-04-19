using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cyrela.Models
{
    [Table("ROLE")]
    public class Role
    {
        public static int INSPECTION = 3;

        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome obrigatório.")]
        [StringLength(50, ErrorMessage = "O nome deve ter no máximo {1} caracteres.")]
        [Column("NAME")]
        public String Name { get; set; }

        // Navigation properties
        public IList<RoleService> RoleServices { get; set; }
    }
}