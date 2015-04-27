namespace MyDubai.Core.Migrations
{
    using MyDubai.Core.DAL.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MyDubai.Core.DAL.MyDubaiDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MyDubai.Core.DAL.MyDubaiDataContext context)
        {
            context.Users.AddOrUpdate(u => u.Username, new User() { Username = "admin", Password = "admin123", DisplayName = "Programmer", Status = DAL.Enums.EntityStatus.Active });
        }
    }
}
