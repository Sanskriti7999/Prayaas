using Microsoft.EntityFrameworkCore;
using Prayaas_Website.Models;
using Prayaas_Website.Models;

namespace Prayaas_Website.Models
{
    public class PrayaasDbContext : DbContext
    {
        public PrayaasDbContext(DbContextOptions<PrayaasDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Seed();
            modelBuilder.Entity<BloodGroups>().HasData(
                new BloodGroups { BloodGroupID = 1, BloodGroup = "AB+" },
                new BloodGroups { BloodGroupID = 2, BloodGroup = "B+" },
                new BloodGroups { BloodGroupID = 3, BloodGroup = "O+" },
                new BloodGroups { BloodGroupID = 4, BloodGroup = "A-" },
                new BloodGroups { BloodGroupID = 5, BloodGroup = "B-" },
                new BloodGroups { BloodGroupID = 6, BloodGroup = "A+" });

       
        
            modelBuilder.Entity<CityT>().HasData(
                new CityT { CityID = 1, City = "Pune" },
                new CityT { CityID = 2, City = "Mumbai" },
                new CityT { CityID = 3, City = "Nashik" },
                new CityT { CityID = 4, City = "Bhopal" },
                new CityT { CityID = 5, City = "Ahmedabad" },
                new CityT { CityID = 6, City = "Nagpur" },
                new CityT { CityID = 7, City = "Indore" });

        
            modelBuilder.Entity<UserTypeT>().HasData(
                new UserTypeT { UserTypeID = 1, UserType = "Donor" },
                new UserTypeT { UserTypeID = 2, UserType = "Seeker" },
                new UserTypeT { UserTypeID = 3, UserType = "Admin" });
           
            modelBuilder.Entity<GenderT>().HasData(
                    new GenderT { GenderID = 1, Gender = "Male" },
                    new GenderT { GenderID = 2, Gender = "Female" },
                    new GenderT { GenderID = 3, Gender = "Others" });
                              
            modelBuilder.Entity<AccountStatusT>().HasData(
                new AccountStatusT { accountStatusID = 1, accountStatus = "Pending" },
                new AccountStatusT { accountStatusID = 2, accountStatus = "Approved" },
                new AccountStatusT { accountStatusID = 3, accountStatus = "Denied" },
                new AccountStatusT { accountStatusID = 4, accountStatus = "Open" },
                new AccountStatusT { accountStatusID = 5, accountStatus = "Closed" });

            modelBuilder.Entity<RequestTypeT>().HasData(
                new RequestTypeT { RequestTypeID = 1, RequestType = "Seeker" },
                new RequestTypeT { RequestTypeID = 2, RequestType = "Institution" } );

            /*modelBuilder.Entity<User>().HasData(
                new User { UserID = 1, UserName = "admin", Password = "admin@123", EmailAddress = "admin@gmail.com", AccountStatusID = 2, UserTypeID = 3 });*/

        }

        public DbSet<AccountStatusT> AccountStatus { get; set; }
        public DbSet<BloodStock> BloodStocks { get; set; }
        public DbSet<BloodGroups> BloodGroups { get; set; }
        public DbSet<CityT> Citys { get; set; }
        public DbSet<Donor> Donors { get; set; }
        public DbSet<GenderT> Genders { get; set; }
        public DbSet<Institution> Instituions { get; set; }
        public DbSet<InstitutionTypeT> InstitutionTypes { get; set; }
       
        public DbSet<Request> Requests { get; set; }
        public DbSet<RequestTypeT> RequestTypes { get; set; }
        public DbSet<Seeker> Seekers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserTypeT> UserTypes { get; set; }


    }
}