using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppG2.Model
{
    public class Contact
    {
        [Key]
        public string ID { get; set; }       
        public string NameContact { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Character
        {
            get
            {
                 return NameContact[0].ToString().ToUpper();
            }
        }
        
        public string UserName { get; set; }
        [ForeignKey("UserName")]
        public User user { get; set; }
    }
}
