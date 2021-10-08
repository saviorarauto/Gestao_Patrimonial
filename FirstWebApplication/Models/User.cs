using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Gestao_Patrimonial.Models
{
    //[Table("User")]
    public class User
    {
        [Display(Name = "Id")]
        [Column("Id")]
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Column("Name")]
        public string Name { get; set; }

        [Display(Name = "Phone")]
        [Column("Phone")]
        public string Phone { get; set; }

        [Display(Name = "Email")]
        [Column("Email")]
        public string Email { get; set; }

        public User()
        {
        }

        public User(int id, string name, string phone, string email)
        {
            Id = id;
            Name = name;
            Phone = phone;
            Email = email;
        }

    }
}
