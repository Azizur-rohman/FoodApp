using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SSEcommerceWebApp.Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace SSEcommerceWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SliderImage> SliderImages { get; set; }

        public DbSet<SubCategory> SubCategories { get; set; }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Division> Divisions { get; set; }

        public DbSet<District> Districts { get; set; }

        public DbSet<Area> Areas { get; set; }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Outlat> Outlets { get; set; }
        public DbSet<DoctorWorkingDetail> DoctorWorkingDetails { get; set; }

        public DbSet<Hospital> Hospitals { get; set; }

        public DbSet<DoctorPersonalDetail> DoctorPersonalDetails { get; set; }

        public DbSet<DoctorSpecialist> DoctorSpecialists { get; set; }

        public DbSet<DoctorCertification> DoctorCertifications { get; set; }

        public DbSet<DoctorServiceCharge> DoctorServiceCharges { get; set; }

        public DbSet<DoctorWorkingTime> DoctorWorkingTimes { get; set; }

        public DbSet<HospitalWithDoctorsId> HospitalWithDoctorsIds { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .HasOne(c => c.SubCategory)
                .WithMany(c=>c.Products)
                .HasForeignKey(s => s.SubCategoryId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Hospital>()
                .HasMany(c => c.DoctorPersonalDetails);

            modelBuilder.Entity<DoctorPersonalDetail>()
                .HasMany(h => h.Hospitals);
            //modelBuilder.Entity<SubCategory>()
            //    .HasMany(c => c.Products)
            //    .WithOne(sc=>sc.SubCategory)
            //    .HasForeignKey(s => s.SubCategoryId)
            //    .OnDelete(DeleteBehavior.NoAction);


            //modelBuilder.Entity<IdentityRole>()
            //             .HasData(new IdentityRole
            //             {
            //                 Id = "2c5e174e-3b0e-446f-86af-483d56fd7210",
            //                 Name = "Administrator",
            //                 NormalizedName = "ADMINISTRATOR"
            //                .ToUpper()
            //             });
            //modelBuilder.Entity<IdentityRole>()
            //             .HasData(new IdentityRole
            //             {
            //                 Id = "2c5e174e-3b0e-446f-86af-483d56fd7211",
            //                 Name = "Vendor",
            //                 NormalizedName = "VENDOR"
            //                 .ToUpper()
            //             }); 
            //modelBuilder.Entity<IdentityRole>()
            //             .HasData(new IdentityRole
            //             {
            //                 Id = "2c5e174e-3b0e-446f-86af-483d56fd7212",
            //                 Name = "Customer",
            //                 NormalizedName = "CUSTOMER"
            //                 .ToUpper()
            //             }); 
            //modelBuilder.Entity<IdentityRole>()
            //             .HasData(new IdentityRole
            //             {
            //                 Id = "2c5e174e-3b0e-446f-86af-483d56fd7213",
            //                 Name = "Delivery Men",
            //                 NormalizedName = "DELIVERY MEN"
            //                 .ToUpper()
            //             }); 

            //modelBuilder.Entity<IdentityRole>()
            //             .HasData(new IdentityRole
            //             {
            //                 Id = "2c5e174e-3b0e-446f-86af-483d56fd7223",
            //                 Name = "Delivery Men",
            //                 NormalizedName = "Doctor"
            //                 .ToUpper()
            //             });




            //var hasher = new PasswordHasher<IdentityUser>();

            //modelBuilder.Entity<ApplicationUser>().HasData(
            //    new ApplicationUser
            //    {
            //        Id = "8e445865-a24d-4543-a6c6-9443d048cdb9", // primary key
            //        UserName = "01715637290",
            //        NormalizedUserName = "01715637290",
            //        FirstName = "Hasan",
            //        LastName = "Mahmud",
            //        PhoneNumber = "01715637290",
            //        PhoneNumberConfirmed = true,
            //        Email = "hmuzzal@mail.com",
            //        NormalizedEmail = "HMUZZAL@MAIL.COM",
            //        EmailConfirmed = true,
            //        IsActive = true,
            //        CreatedDate = DateTime.Now,
            //        //CreatedBy = 
            //        PasswordHash = hasher.HashPassword(null, "Dc$1234")
            //    }
            //);



            //modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            //    new IdentityUserRole<string>
            //    {
            //        RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210", 
            //        UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9"
            //    }
            //);

        }

    }

}
