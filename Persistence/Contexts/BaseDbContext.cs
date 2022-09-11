using Core.Security.Entities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<EmailAuthenticator> EmailAuthenticators { get; set; }
        public DbSet<OtpAuthenticator> OtpAuthenticators { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<SocialLink> SocialLinks { get; set; }

        public BaseDbContext(DbContextOptions dbContextOptions ,IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //    base.OnConfiguring(optionsBuilder.UseSqlServer(Configuration.GetConnectionString("KodlamaIoDevsDb")));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgrammingLanguage>(p =>
            {
                p.ToTable("ProgrammingLanguages").HasKey(k => k.Id);
                p.Property(p => p.Id).HasColumnName("Id");
                p.Property(p => p.Name).HasColumnName("Name");

                p.HasMany(p => p.Technologies);
            });

            modelBuilder.Entity<Technology>(t =>
            {
                t.ToTable("Technologies").HasKey(k => k.Id);
                t.Property(k => k.ProgrammingLanguageId).HasColumnName("ProgrammingLanguageId");
                t.Property(k => k.Name).HasColumnName("Name");

                t.HasOne(k => k.ProgrammingLanguage);
            });

            modelBuilder.Entity<User>(u =>
            {
                u.ToTable("Users").HasKey(k => k.Id);
                u.Property(k => k.Id).HasColumnName("Id");
                u.Property(k => k.FirstName).HasColumnName("FirstName");
                u.Property(k => k.LastName).HasColumnName("LastName");
                u.Property(k => k.Email).HasColumnName("Email");
                u.Property(k => k.PasswordSalt).HasColumnName("PasswordSalt");
                u.Property(k => k.PasswordHash).HasColumnName("PasswordHash");
                u.Property(k => k.Status).HasColumnName("Status");
                u.Property(k => k.AuthenticatorType).HasColumnName("AuthenticatorType");

                u.HasMany(k => k.UserOperationClaims);
                u.HasMany(k => k.RefreshTokens);
            });

            modelBuilder.Entity<OperationClaim>(c =>
            {
                c.ToTable("OperationClaims").HasKey(k => k.Id);
                c.Property(k => k.Id).HasColumnName("Id");
                c.Property(k => k.Name).HasColumnName("Name");
            });

            modelBuilder.Entity<UserOperationClaim>(c =>
            {
                c.ToTable("UserOperationClaims").HasKey(k => k.Id);
                c.Property(k => k.Id).HasColumnName("Id");
                c.Property(k => k.UserId).HasColumnName("UserId");
                c.Property(k => k.OperationClaimId).HasColumnName("OperationClaimId");

                c.HasOne(k => k.User);
                c.HasOne(k => k.OperationClaim);
            });

            modelBuilder.Entity<EmailAuthenticator>(e =>
            {
                e.ToTable("EmailAuthenticators").HasKey(k=>k.Id);
                e.Property(k => k.Id).HasColumnName("Id");
                e.Property(k => k.UserId).HasColumnName("UserId");
                e.Property(k => k.ActivationKey).HasColumnName("ActivationKey");
                e.Property(k => k.IsVerified).HasColumnName("IsVerified");

                e.HasOne(k => k.User);
            });

            modelBuilder.Entity<OtpAuthenticator>(o =>
            {
                o.ToTable("OtpAuthenticators").HasKey(k=>k.Id);
                o.Property(k=>k.Id).HasColumnName("Id");
                o.Property(k => k.UserId).HasColumnName("UserId");
                o.Property(k => k.SecretKey).HasColumnName("SecretKey");
                o.Property(k => k.IsVerified).HasColumnName("IsVerified");

                o.HasOne(k => k.User);
            });

            modelBuilder.Entity<RefreshToken>(t =>
            {
                t.ToTable("RefreshTokens").HasKey(k => k.Id);
                t.Property(k => k.UserId).HasColumnName("UserId");
                t.Property(k => k.Token).HasColumnName("Token");
                t.Property(k => k.Expires).HasColumnName("Expires");
                t.Property(k => k.Created).HasColumnName("Created");
                t.Property(k => k.CreatedByIp).HasColumnName("CreatedByIp");
                t.Property(k => k.Revoked).HasColumnName("Revoked");
                t.Property(k => k.RevokedByIp).HasColumnName("RevokedByIp");
                t.Property(k => k.ReplacedByToken).HasColumnName("ReplacedByToken");
                t.Property(k => k.ReasonRevoked).HasColumnName("ReasonRevoked");

                t.HasOne(k => k.User);
            });

            modelBuilder.Entity<SocialLink>(s =>
            {
                s.ToTable("SocialLinks").HasKey(k => k.Id);
                s.Property(k => k.Id).HasColumnName("Id");
                s.Property(k => k.UserId).HasColumnName("UserId");
                s.Property(k => k.Name).HasColumnName("Name");
                s.Property(k => k.Url).HasColumnName("Url");

                s.HasOne(k => k.User);
            });

            ProgrammingLanguage[] programmingLanguageEntitySeeds = { new(1, "C#"), new(2, "Java"), new(3, "Javascript") };
            modelBuilder.Entity<ProgrammingLanguage>().HasData(programmingLanguageEntitySeeds);

            Technology[] technologyEntitySeeds = { new(1, 1, "WPF"), new(2, 1, "ASP.NET"), new(3, 2, "Spring"), new(4, 2, "JSP"), new(5, 3, "Vue"), new(6, 3, "React") };
            modelBuilder.Entity<Technology>().HasData(technologyEntitySeeds);

            OperationClaim[] operationClaimEntitySeeds = { new(1, "Admin"), new(2, "User") };
            modelBuilder.Entity<OperationClaim>().HasData(operationClaimEntitySeeds);

        }
    }
}
