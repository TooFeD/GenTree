using System.Data.Entity;
using GenTree.SharedEntities.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GenTree.DAL.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Tree> Trees { get; set; }
        public DbSet<Friendship> Friendships { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<GenDiseases> GenDiseaseses { get; set; }
        public DbSet<HaveDiseases> HaveDiseaseses { get; set; }
        public DbSet<Parents> Parents { get; set; }
        public DbSet<Childs> Childs { get; set; }
        public DbSet<Marriage> Marriages { get; set; }
       
        
        //public DbSet<RecognizeImage> RecognizeImages { get; set; }


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(x => x.Friendships)
                .WithRequired(x=>x.User)
                .HasForeignKey(x=>x.UserId);
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(x => x.Friendships)
                .WithRequired(x => x.Friend)
                .HasForeignKey(x => x.FriendId);
            modelBuilder.Entity<Member>()
                .HasMany(x => x.Parents)
                .WithRequired(x => x.Member)
                .HasForeignKey(x => x.MemberId);
            modelBuilder.Entity<Member>()
                .HasMany(x => x.Parents)
                .WithRequired(x => x.Parent)
                .HasForeignKey(x => x.ParentId);
            modelBuilder.Entity<Member>()
              .HasMany(x => x.Childs)
              .WithRequired(x => x.Member)
              .HasForeignKey(x => x.MemberId);
            modelBuilder.Entity<Member>()
                .HasMany(x => x.Childs)
                .WithRequired(x => x.Child)
                .HasForeignKey(x => x.ChildId);
            modelBuilder.Entity<Member>()
             .HasMany(x => x.Marriages)
             .WithRequired(x => x.Member)
             .HasForeignKey(x => x.MemberId);
            modelBuilder.Entity<Member>()
                .HasMany(x => x.Marriages)
                .WithRequired(x => x.Marriag)
                .HasForeignKey(x => x.MarriagId);



            base.OnModelCreating(modelBuilder);
        }

        static ApplicationDbContext()
        {
            DbConfiguration.SetConfiguration(new MySql.Data.Entity.MySqlEFConfiguration());
        }
    }
}