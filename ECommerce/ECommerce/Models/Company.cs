using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class Company
    {
        [Key]
        [Display(Name = "Company id")]
        public int CompanyId { get; set; }

        [MaxLength(50, ErrorMessage = "O campo nome recebe no maximo 50 caracteres")]
        [Required(ErrorMessage ="O campo nome é requerido!")]
        [Display(Name = "Nome")]
        [Index("Company_Name_Index", IsUnique = true)]
        public string Name { get; set; }

        [MaxLength(50, ErrorMessage = "O campo telefone recebe no maximo 50 caracteres")]
        [Required(ErrorMessage = "O campo telefone é requerido!")]
        [Display(Name = "Telefone")]
        //[Index("Company_Name_Index", IsUnique = true)]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [MaxLength(100, ErrorMessage = "O campo endereço recebe no maximo 100 caracteres")]
        [Required(ErrorMessage = "O campo endereço é requerido!")]
        [Display(Name = "Endereço")]
        public string Address { get; set; }

        [Display(Name ="Imagem" )]
        [DataType(DataType.ImageUrl)]
        public string Logo { get; set; }

        //CAMPO NÃO MAPEADO NO BANCO DE DADOS
        [NotMapped]
        public HttpPostedFileBase LogoFile { get; set; }


        [Required(ErrorMessage = "O campo departamento é requerido!")]
        [Display(Name = "Departamento")]
        public int DepartamentsId { get; set; }

        [Required(ErrorMessage = "O campo cidade é requerido!")]
        [Display(Name = "Cidade")]
        public int CityId { get; set; }

        //Chave estrangeira 
        public virtual Departaments Departaments { get; set; }
        public virtual City Cities { get; set; }
        public virtual ICollection<User> User { get; set; }

    }
}