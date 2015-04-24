using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDubai.Domain.DAL.Entities
{
    public class UserProfile
    {
        [Key]
        public String Username { get; set; }
    }
}
