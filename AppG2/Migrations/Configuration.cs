namespace AppG2.Migrations
{
    using AppG2.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AppG2.Model.AppG2Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AppG2.Model.AppG2Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.StudentDbset.AddOrUpdate(
                new Student
                {
                    IDStudent = "16T1021104",
                    FirstName = "Nghĩaaaaaa",
                    LastName = "Nguyễn",
                    DOB = new DateTime(1998, 5, 17),
                    Gender = Gender.Male,
                    POB = "Thừa Thiên Huế"
                },
                new Student
                {
                    IDStudent = "16T1021100",
                    FirstName = "Đức",
                    LastName = "Ngkja",
                    DOB = new DateTime(1998, 6, 9),
                    Gender = Gender.FeMale,
                    POB = "Quảng Ngãi"
                });
           
            context.SaveChanges();

            for(int i = 1; i <= 12; i++)
            {
                context.HistoryLearningDbset.AddOrUpdate(
                    new HistoryLearning
                    {
                        IDHistoryLearning = i.ToString(),
                        Address = "THPT Nguyễn Trường Tộ",
                        IDStudent = "16T1021104",
                        YearFrom = 2004 + i,
                        YearEnd = 2005 + i
                    }
                );
            };
            for (int i = 1; i <= 12; i++)
            {
                context.HistoryLearningDbset.AddOrUpdate(
                    new HistoryLearning
                    {
                        IDHistoryLearning = (i+12).ToString(),
                        Address = "ĐHKH",
                        IDStudent = "16T1021100",
                        YearFrom = 2008 + i,
                        YearEnd = 2009 + i
                    }
                );
            };
            context.UserDbset.AddOrUpdate(
                new User
                {
                    UserName = "a",
                    FullName = "Nguyen Duc Nghia",
                    PassWord = "1"
                },
                new User
                {
                    UserName = "b",
                    FullName = "Le van dung",
                    PassWord = "1"
                }
                );
            context.SaveChanges();
            context.ContactDbset.AddOrUpdate(
               new Contact
               {
                   ID = "1",
                   NameContact = "Ada Loveface",
                   Email = "ducnghia@gmail.com",
                   Phone = "0123123123",
                   UserName = "a"
               },
               new Contact
               {
                   ID = "2",
                   NameContact = "Grace Hopper",
                   Email = "ankut@gmail.com",
                   Phone = "01283813221",
                   UserName = "b"
               },
               new Contact
               {
                   ID = "3",
                   NameContact = "Margaret Hamiton",
                   Email = "anheo@gmail.com",
                   Phone = "04891231233",
                   UserName = "a"
               },
               new Contact
               {
                   ID = "4",
                   NameContact = "Joan Clarke",
                   Email = "lniancol@gmail.com",
                   Phone = "0123912312",
                   UserName = "b"
               }
               );

            context.SaveChanges();

            
        }
    }
}
