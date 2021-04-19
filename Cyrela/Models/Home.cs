using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cyrela.Models
{
    [Table("HOME")]
    public class Home
    {
        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Bloco obrigatório.")]
        [StringLength(6, ErrorMessage = "O bloco deve ter no máximo 6 caracteres.")]
        [Display(Name = "Bloco: ")]
        [Column("BLOCK")]
        public String Block { get; set; }

        [Required(ErrorMessage = "Apartamento obrigatório.")]
        [StringLength(6, ErrorMessage = "O Apartamento deve ter no máximo 6 caracteres.")]
        [Display(Name = "Nº Apartamento: ")]
        [Column("APARTMENT")]
        public String Apartment { get; set; }

        [Required(ErrorMessage = "Data da venda obrigatória.")]
        [Display(Name = "Data da venda: ")]
        [Column("SALE_DATE")]
        public DateTime SaleDate { get; set; }

        [Display(Name = "Data da entrega: ")]
        [Column("DELIVERY_DATE")]
        public DateTime DeliveryDate { get; set; }

        [Display(Name = "Endereço: ")]
        [Required(ErrorMessage = "Endereço obrigatório.")]
        [Column("HOME_ADDRESS_ID")]
        public int HomeAddressId { get; set; }

        [Display(Name = "Cliente: ")]
        [Required(ErrorMessage = "Cliente obrigatório.")]
        [Column("CLIENT_ID")]
        public int ClientId { get; set; }

        [Display(Name = "Status: ")]
        [Required(ErrorMessage = "Status obrigatório.")]
        [Column("HOME_STATUS_ID")]
        public int HomeStatusId { get; set; }

        // Navigation properties
        public HomeAddress HomeAddress { get; set; }

        public Client Client { get; set; }

        public HomeStatus HomeStatus { get; set; }
    }
}