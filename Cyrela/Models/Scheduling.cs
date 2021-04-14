using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cyrela.Models
{
    [Table("SCHEDULING")]
    public class Scheduling
    {
        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Data do agendamento obrigatório.")]
        [Display(Name = "Data: ")]
        [Column("SCHEDULING_DATE")]
        public DateTime SchedulingDate { get; set; }

        [Required(ErrorMessage = "Funcionário obrigatório.")]
        [Display(Name = "Funcionário: ")]
        [Column("EMPLOYEE_ID")]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Empreendimento obrigatório.")]
        [Display(Name = "Empreendimento: ")]
        [Column("HOME_ID")]
        public int HomeId { get; set; }

        [Required(ErrorMessage = "Status obrigatório.")]
        [Display(Name = "Status: ")]
        [Column("SCHEDULING_STATUS_ID")]
        public int SchedulingStatusId { get; set; }

        [Required(ErrorMessage = "Tipo obrigatório.")]
        [Display(Name = "Tipo: ")]
        [Column("SCHEDULING_TYPE_ID")]
        public int SchedulingTypeId { get; set; }

        [Required(ErrorMessage = "Serviço obrigatório.")]
        [Display(Name = "Serviço: ")]
        [Column("SERVICE_ID")]
        public int ServiceId { get; set; }

        // Navigation properties
        public Employee Employee { get; set; }

        public Home Home { get; set; }

        public SchedulingStatus SchedulingStatus { get; set; }

        public SchedulingType SchedulingType { get; set; }

        public Service Service { get; set; }
    }
}