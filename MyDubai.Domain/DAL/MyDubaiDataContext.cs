namespace MyDubai.Domain.DAL
{
    using MyDubai.Domain.DAL.Entities;
using System;
using System.Data.Entity;
using System.Linq;

    public class MyDubaiDataContext : DbContext
    {
        // Your context has been configured to use a 'MyDubaiDataContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'MyDubai.Domain.DAL.MyDubaiDataContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'MyDubaiDataContext' 
        // connection string in the application configuration file.
        public MyDubaiDataContext()
            : base("name=MyDubaiDataContext")
        {
        }

        public DbSet<Status> Statuses { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}