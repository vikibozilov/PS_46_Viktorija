using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Model;
using Welcome.Others;

namespace DataLayers.Model
{
    public class DatabaseUser : User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        public DatabaseUser(string name, string password, UserRolesEnum role, string fnum, string email, int id, DateTime expires) 
            : base(name, password, role, fnum, email, id, expires)
        {
        }
    }
}
