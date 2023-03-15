using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebsiteDuLich.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    
    public class ApplicationUser : IdentityUser
    {
      

        [MaxLength(256)]
        public string FullName { set; get; }
        [MaxLength(256)]
        public string Address { set; get; }
        public DateTime? BirthDay { set; get; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationRole: IdentityRole
    {
        public ApplicationRole() : base() { }
        public ApplicationRole(string roleName) : base(roleName) { }
    }


    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Footer> Footers { get; set; }
        public DbSet<headerBanner> headerBanners { get; set; }
        public DbSet<DanhMuc> DanhMucs { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<DatTour> DatTours { get; set; }
        public DbSet<GioiThieu> GioiThieus { get; set; }
        public DbSet<TinTuc> TinTucs { get; set; }
        public DbSet<DonTour> DonTours { get; set; }
        public DbSet<CTDonTour> CTDonTours { get; set; }
        public DbSet<LienHe> LienHes { get; set; }

        public DbSet<PhanQuyen> PhanQuyens { get; set; }
        public DbSet<Nguoidung> Nguoidungs { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<WebsiteDuLich.Models.RoleViewModel> RoleViewModels { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DonTour>()
                .HasRequired(c => c.Customer)
                .WithMany()
                .WillCascadeOnDelete(false);
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<CTDonTour>()
                 .Property(e => e.Dongia)
                 .HasPrecision(18, 0);

            modelBuilder.Entity<DonTour>()
                .HasMany(e => e.CTDonTours)
                .WithRequired(e => e.DonTour)
                .WillCascadeOnDelete(false);


            modelBuilder.Entity<Nguoidung>()
                .Property(e => e.Dienthoai)
                .IsFixedLength();

            modelBuilder.Entity<Nguoidung>()
                .Property(e => e.Matkhau)
                .IsUnicode(false);



            //modelBuilder.Entity<Tour>()
            //    .HasMany(e => e.CTDonTours)
            //    .WithRequired(e => e.Tour)
            //    .WillCascadeOnDelete(false);
        }


      
    }
}