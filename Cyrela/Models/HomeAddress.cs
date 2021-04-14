using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cyrela.Models
{
    [Table("HOME_ADDRESS")]
    public class HomeAddress
    {
        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Rua obrigatória.")]
        [StringLength(150, ErrorMessage = "O nome da rua deve ter no máximo 150 caracteres.")]
        [Display(Name = "Rua: ")]
        [Column("STREET")]
        public String Street { get; set; }

        [Required(ErrorMessage = "Bairro obrigatório.")]
        [StringLength(100, ErrorMessage = "O bairro deve ter no máximo 100 caracteres.")]
        [Display(Name = "Bairro: ")]
        [Column("DISTRICT")]
        public String District { get; set; }

        [Required(ErrorMessage = "Número obrigatório.")]
        [StringLength(6, ErrorMessage = "O número deve ter no máximo 6 caracteres.")]
        [Display(Name = "Número: ")]
        [Column("HOME_NUMBER")]
        public String HomeNumber { get; set; }

        [StringLength(160, ErrorMessage = "O complemento deve ter no máximo 160 caracteres.")]
        [Display(Name = "Complemento: ")]
        [Column("COMPLEMENT")]
        public String Complement { get; set; }

        [Required(ErrorMessage = "Cidade obrigatória.")]
        [Display(Name = "Cidade: ")]
        [Column("CITY_ID")]
        public int CityId { get; set; }

        // Navigation properties
        public City City { get; set; }
    }
}