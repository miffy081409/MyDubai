using MyDubai.Core.DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDubai.Core.DAL.Entities
{
    public class User
    {
        [Key]
        public String Username { get; set; }
        public String Password { get; set; }
        public String DisplayName { get; set; }
        public EntityStatus Status { get; set; }
    }
}
