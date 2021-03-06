namespace DAL.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AutoShow : DbContext
    {
        public AutoShow()
            : base("name=Autoshow")
        {
        }

        public virtual DbSet<Automobile> Automobile { get; set; }
        public virtual DbSet<Brand> Brand { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Color> Color { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EmpType> EmpType { get; set; }
        public virtual DbSet<ExtraServ> ExtraServ { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<Human> Human { get; set; }
        public virtual DbSet<Model> Model { get; set; }
        public virtual DbSet<PayType> PayType { get; set; }
        public virtual DbSet<Purchase> Purchase { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Transmission> Transmission { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<VehicleEquip> VehicleEquip { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Automobile>()
                .HasMany(e => e.Purchase)
                .WithRequired(e => e.Automobile)
                .HasForeignKey(e => e.AutoFK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Brand>()
                .HasMany(e => e.Automobile)
                .WithRequired(e => e.Brand)
                .HasForeignKey(e => e.BrandFK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Brand>()
                .HasMany(e => e.Model)
                .WithRequired(e => e.Brand)
                .HasForeignKey(e => e.BrandFK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Purchase)
                .WithRequired(e => e.Client)
                .HasForeignKey(e => e.ClientFK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Color>()
                .HasMany(e => e.Automobile)
                .WithRequired(e => e.Color)
                .HasForeignKey(e => e.ColorFK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Country>()
                .HasMany(e => e.Automobile)
                .WithRequired(e => e.Country)
                .HasForeignKey(e => e.CountryFK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.User)
                .WithOptional(e => e.Employee)
                .HasForeignKey(e => e.EmpIdFK);

            modelBuilder.Entity<EmpType>()
                .HasMany(e => e.Employee)
                .WithRequired(e => e.EmpType)
                .HasForeignKey(e => e.EmpTypeFK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ExtraServ>()
                .HasMany(e => e.Purchase)
                .WithOptional(e => e.ExtraServ)
                .HasForeignKey(e => e.ExtraSevFK);

            modelBuilder.Entity<Gender>()
                .HasMany(e => e.Human)
                .WithRequired(e => e.Gender)
                .HasForeignKey(e => e.GendFK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Human>()
                .HasMany(e => e.Client)
                .WithOptional(e => e.Human)
                .HasForeignKey(e => e.HumFK);

            modelBuilder.Entity<Human>()
                .HasMany(e => e.Employee)
                .WithRequired(e => e.Human)
                .HasForeignKey(e => e.HumFK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Model>()
                .HasMany(e => e.Automobile)
                .WithRequired(e => e.Model)
                .HasForeignKey(e => e.ModelFK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PayType>()
                .HasMany(e => e.Purchase)
                .WithRequired(e => e.PayType)
                .HasForeignKey(e => e.PayTypeFK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Transmission>()
                .HasMany(e => e.Automobile)
                .WithRequired(e => e.Transmission)
                .HasForeignKey(e => e.TransmFK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VehicleEquip>()
                .HasMany(e => e.Model)
                .WithOptional(e => e.VehicleEquip)
                .HasForeignKey(e => e.VechTypeFK);
        }
    }
}
