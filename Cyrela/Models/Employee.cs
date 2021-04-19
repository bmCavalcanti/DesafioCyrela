using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cyrela.Models
{
    [Table("EMPLOYEE")]
    public class Employee
    {
        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome obrigatório.")]
        [StringLength(50, ErrorMessage = "O nome deve ter no máximo {1} caracteres.")]
        [Column("FIRST_NAME")]
        public String FirstName { get; set; }

        [Required(ErrorMessage = "Sobrenome obrigatório.")]
        [StringLength(80, ErrorMessage = "O sobrenome deve ter no máximo {1} caracteres.")]
        [Column("LAST_NAME")]
        public String LastName { get; set; }

        [Required(ErrorMessage = "Início expediente obrigatório.")]
        [Range(1, 24, ErrorMessage = "O início do expediente deve estar entre {1} e {2}")]
        [Column("WORK_STARTS_AT")]
        public int WorkStartsAt { get; set; }

        [Required(ErrorMessage = "Fim expediente obrigatório.")]
        [Range(1, 24, ErrorMessage = "O fim do expediente deve estar entre {1} e {2}")]
        [Column("WORK_ENDS_AT")]
        public int WorkEndsAt { get; set; }

        [Required(ErrorMessage = "Status obrigatório.")]
        [Column("IS_ACTIVE")]
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "Função obrigatória")]
        [Column("ROLE_ID")]
        [ForeignKey("ROLE_ID")]
        public int RoleId { get; set; }

        // Navigation properties
        public Role Role { get; set; }

        public IList<EmployeeDayOff> EmployeeDaysOff { get; set; }

        public IList<Scheduling> Schedules { get; set; }
    }
}