using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class City
    {
        [Key]
        [Display(Name = "Cidade Id")]
        public int CityId { get; set; }
        
        [Required(ErrorMessage = "O campo Cidade é requerido!")]
        [Display(Name = "Cidade")]
        public string Name { get; set; }

        [Display(Name = "Departamento")]
        [Range(1,double.MaxValue, ErrorMessage ="Selecione um departamento")]
        public int DepartamentsId { get; set; }

        //Chave estrangeira 
        public virtual Departaments Departaments { get; set; }
        public virtual ICollection<Company> Company { get; set; }
        public virtual ICollection<User> User { get; set; }


    }
}