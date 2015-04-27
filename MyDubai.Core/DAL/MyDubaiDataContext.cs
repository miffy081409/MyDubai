namespace MyDubai.Core.DAL
{
    using MyDubai.Core.DAL.Entities;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MyDubaiDataContext : DbContext
    {
        //fuck this one why i cant have this on app config
        public MyDubaiDataContext()
            : base(@"data source=.\SQLExpress;initial catalog=MyDubai;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework")
        {
        }
        public DbSet<User> Users { get; set; }
    }
}