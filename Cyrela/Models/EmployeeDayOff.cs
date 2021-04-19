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
        [Column("DAY_OFF_DATE")]
        public DateTime DayOffDate { get; set; }

        [Required(ErrorMessage = "Funcionário obrigatório.")]
        [Column("EMPLOYEE_ID")]
        [ForeignKey("EMPLOYEE_ID")]
        public int EmployeeId { get; set; }

        // Navigation properties
        //public Employee Employee { get; set; }

    }
}