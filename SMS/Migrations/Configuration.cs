namespace SMS.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using SMS.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<SMS.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SMS.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            AddUserRole(context);

            context.Messages.AddOrUpdate(p => p.MessageId,
                new Message
                {
                    MessageId = 1,
                    Sender = "User1",
                    Receiver = "User2",
                    SentDate = new DateTime(2014, 11, 20),
                    ReadStatus = false,
                    Subject = "Test Message",
                    Body = "1 2 3, test..."
                },
                new Message
                {
                    MessageId = 2,
                    Sender = "User1",
                    Receiver = "User2",
                    SentDate = new DateTime(2014, 11, 20),
                    ReadStatus = false,
                    Subject = "Test Message",
                    Body = "1 2 3, test..."
                },
                new Message
                {
                    MessageId = 3,
                    Sender = "User1",
                    Receiver = "User2",
                    SentDate = new DateTime(2014, 11, 20),
                    ReadStatus = false,
                    Subject = "Test Message",
                    Body = "1 2 3, test..."
                }
                );

            
        }

        bool AddUserRole(SMS.Models.ApplicationDbContext context)
        {
            IdentityResult ir;

            var rm = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            ir = rm.Create(new IdentityRole("admin"));

            var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            var user = new ApplicationUser()
            {
                UserName = "admin@sms.com"
            };
            ir = um.Create(user, "Parolamea123#");
            if (ir.Succeeded == false)
            {
                return ir.Succeeded;
            }

            ir = um.AddToRole(user.Id, "admin");


            return ir.Succeeded;
        }
    }
}
