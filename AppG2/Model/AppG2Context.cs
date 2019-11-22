using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppG2.Model
{
    public class AppG2Context : DbContext
    {
        public AppG2Context() : 
            base("Data Source=.;Initial Catalog=DB_G2;Integrated Security=True") //chỉ ra kết nối tới DB nào
            //base("Data Source=.;Initial Catalog=DB_G2;Integrated Security=True;User ID=sa; Password=123") //chỉ ra kết nối tới DB nào
        {
                      
        }
        public DbSet<Student> StudentDbset { get; set; }
        public DbSet<HistoryLearning> HistoryLearningDbset { get; set; }
        public DbSet<Contact> ContactDbset { get; set; }
        public DbSet<User> UserDbset { get; set; }
    }
}
