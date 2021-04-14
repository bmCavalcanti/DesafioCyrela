using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cyrela.Models
{
    [Table("EMPLOYEE_DAY_OFF")]
    public class EmployeeDayOff
    {
        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Data da folga obrigatória.")]
        [Display(Name = "Data da folga: ")]
        [Column("DAY_OFF_DATE")]
        public DateTime DayOffDate { get; set; }

        [Required(ErrorMessage = "Funcionário obrigatório.")]
        [Display(Name = "Funcionário: ")]
        [Column("EMPLOYEE_ID")]
        public int EmployeeId { get; set; }

        // Navigation properties
        public Employee Employee { get; set; }

    }
}