using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDubai.Domain.DAL.Entities
{
    public class Status
    {
        [Key]
        public String StatusID { get; set; }
        public String ProfileID { get; set; }
        public String StatusPosted { get; set; }
        public String[] Hashtags { get; set; }
        public Int32 LastLikesCount { get; set; }
        public Int32 LastShareCount { get; set; }
        
        //navigational property
        public UserProfile UserProfile { get; set; }
    }
}
