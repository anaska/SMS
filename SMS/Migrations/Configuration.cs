namespace SMS.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
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
    }
}
