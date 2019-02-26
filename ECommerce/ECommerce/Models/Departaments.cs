using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class Departaments
    {
        [Key]
        [Display(Name = "Departamento id")]
        public int DepartamentsId { get; set; }

        [Required(ErrorMessage = "campo Nome é requerido!")]
        [MaxLength(50,ErrorMessage ="O campo nome recebe no maximo 50 caracteres")]
        [Display(Name ="Nome")]
        //nome unico, é obrigatorio o limite de de max_length, exemplo 50
        [Index("Departament_Name_Index", IsUnique = true)]
        public string Name { get; set; }

        
        public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<Company> Company { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}