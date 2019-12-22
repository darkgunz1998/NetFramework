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
                    POB = "Thừa Thiên Huế",
                    IDKhoa = "3"
                },
                new Student
                {
                    IDStudent = "16T1021100",
                    FirstName = "Đức",
                    LastName = "Ngkja",
                    DOB = new DateTime(1998, 6, 9),
                    Gender = Gender.FeMale,
                    POB = "Quảng Ngãi",
                    IDKhoa = "2"
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

            context.KhoaDbset.AddOrUpdate(
                new Khoa
                {
                    IDKhoa = "1",
                    TenKhoa = "Văn"
                },
                new Khoa
                {
                    IDKhoa = "2",
                    TenKhoa = "Vật lý"
                },
                new Khoa
                {
                    IDKhoa = "3",
                    TenKhoa = "CNTT"
                }
                );
            context.SaveChanges();
            context.MonHocDbset.AddOrUpdate(
                new MonHoc
                {
                    IDMonHoc = "1",
                    TenMonHoc = "Văn học CĐ",
                    IDKhoa = "1"
                },
                new MonHoc
                {
                    IDMonHoc = "2",
                    TenMonHoc = "Văn học HĐ",
                    IDKhoa = "1"
                },
                new MonHoc
                {
                    IDMonHoc = "3",
                    TenMonHoc = "Vật lý trị liệu",
                    IDKhoa = "2"
                },
                new MonHoc
                {
                    IDMonHoc = "4",
                    TenMonHoc = "Định lý newton 4",
                    IDKhoa = "2"
                },
                new MonHoc
                {
                    IDMonHoc = "5",
                    TenMonHoc = "Nghỉ ngơi",
                    IDKhoa = "3"
                },
                new MonHoc
                {
                    IDMonHoc = "6",
                    TenMonHoc = "Kĩ thuật lập trình",
                    IDKhoa = "3"
                }
                );
            context.SaveChanges();
            context.DiemDbset.AddOrUpdate(
                new Diem
                {
                    IDStudent = "16T1021104",
                    IDMonHoc = "5",
                    DiemMonHoc = 10
                },
                new Diem
                {
                    IDStudent = "16T1021104",
                    IDMonHoc = "6",
                    DiemMonHoc = 9.3
                },
                new Diem
                {
                    IDStudent = "16T1021100",
                    IDMonHoc = "3",
                    DiemMonHoc = 5
                },
                new Diem
                {
                    IDStudent = "16T1021100",
                    IDMonHoc = "4",
                    DiemMonHoc = 7.5
                }
                );
        }
    }
}
