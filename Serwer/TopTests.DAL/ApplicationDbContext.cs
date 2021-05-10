using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using TopTests.DAL.Entities;

namespace TopTests.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Results> Results { get; set; }
        public DbSet<Subjects> Subjects { get; set; }
        public DbSet<TestQuestions> TestQuestions { get; set; }
        public DbSet<Answers> Answers { get; set; }
        public DbSet<RefreshTokens> RefreshTokens { get; set; }
        public DbSet<FeedBacks> FeedBacks { get; set; }
        public DbSet<Files> Files { get; set; }
        public DbSet<TimeRemainingOfTest> TimeRemainingOfTests { get; set; }

        public static byte[] ReadFile(string sPath)
        {
            byte[] data;
            FileInfo fInfo = new FileInfo(sPath);
            long numBytes = fInfo.Length;
            FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fStream);
            data = br.ReadBytes((int)numBytes);

            return data;
        }
        public HashSalt GenerateSaltedHash(int size, string password)
        {
            var saltBytes = new byte[size];
            var provider = new RNGCryptoServiceProvider();
            provider.GetNonZeroBytes(saltBytes);
            var salt = Convert.ToBase64String(saltBytes);

            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, saltBytes, 10000);
            var hashPassword = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));

            return new HashSalt { Hash = hashPassword, Salt = salt };
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            modelBuilder.Entity<Files>().HasData(
                 new
                 {
                     Id = 4,
                     FileName = "Multiple Choices Test",
                     FileContent = ReadFile("C:\\Users\\kuche\\Desktop\\TopTests\\TypesOfTest\\MultipleChoiseTest.csv"),
                     TypeOfTest = 0
                 },
                 new
                 {
                     Id = 5,
                     FileName = "Single Selection Test",
                     FileContent = ReadFile("C:\\Users\\kuche\\Desktop\\TopTests\\TypesOfTest\\SingleSelectionTest .csv"),
                     TypeOfTest = 1
                 }

                );
            var hash = GenerateSaltedHash(8, "admin");
            modelBuilder.Entity<Users>().HasData(
                new
                {
                    Id=1,
                    FirstName = "Admin",
                    LastName = "",
                    Email = "admin@admin.com",
                    HashPassword = hash.Hash,
                    salt = hash.Salt,
                    DateCreated = DateTime.Now,
                    DateModified=DateTime.Now,
                    RoleOfUser = RoleOfUser.Admin,
                    StatusOfVerification = "Active",
                    IsDeleted=false
                }
                ); ;
        }
}
 
}