using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppG2.Model
{
    public class User
    {
        [Key]
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string PassWord { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
    }
}
