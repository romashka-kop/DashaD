using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace DashaD.Models
{
    public class EmployeeData
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEmployee { get; set; }
        [Required]
        public string Surname { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Patronymic { get; set; }

        [Required]
        public string Role { get; set; }

        [Required]
        public string Department { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string FullName { get; set; } //AS (Surname + ' ' + Name + ' ' + Patronymic)

        public bool IsValidRole()
        {
            return Role == "Администратор" || Role == "Пользователь";
        }

    }
}
