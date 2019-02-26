using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class User
    {
        [Key]
        [Display(Name = "User id")]
        public int UserId { get; set; }

        [MaxLength(250, ErrorMessage = "O campo E-Mail recebe no maximo 250 caracteres")]
        [Required(ErrorMessage = "O campo E-Mail é requerido!")]
        [Display(Name = "E-Mail")]
        [DataType(DataType.EmailAddress)]
        [Index("User_UserName_Index", IsUnique = true)]
        public string UserName { get; set; }

        [MaxLength(50, ErrorMessage = "O campo nome recebe no maximo 50 caracteres")]
        [Required(ErrorMessage = "O campo nome é requerido!")]
        [Display(Name = "Nome")]
        public string FirtName { get; set; }

        [MaxLength(50, ErrorMessage = "O campo sobreNome recebe no maximo 50 caracteres")]
        [Required(ErrorMessage = "O campo sobreNome é requerido!")]
        [Display(Name = "SobreNome")]
        public string LastName { get; set; }

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

        [Display(Name = "Imagem")]
        [DataType(DataType.ImageUrl)]
        public string Photo { get; set; }

        //CAMPO NÃO MAPEADO NO BANCO DE DADOS
        [NotMapped]
        public HttpPostedFileBase PhotoFile { get; set; }


        [Required(ErrorMessage = "O campo departamento é requerido!")]
        [Display(Name = "Departamento")]
        public int DepartamentsId { get; set; }

        [Required(ErrorMessage = "O campo cidade é requerido!")]
        [Display(Name = "Cidade")]
        public int CityId { get; set; }

        [Required(ErrorMessage = "O campo companhia é requerido!")]
        [Display(Name = "Companhia")]
        public int CompanyId { get; set; }

        //formatação de string com FORMAT
        //CAMPO NÃO CRIADO NO BANCO DE DADOS POR TER APENAS PROPRIEDADE 'GET'
        [Display(Name ="Usuário")]
        public string FullName { get { return string.Format("{0} {1}", FirtName, LastName);}}


        //Chave estrangeira 
        public virtual Departaments Departaments { get; set; }
        public virtual City Cities { get; set; }
        public virtual Company Company { get; set; }
    }
}