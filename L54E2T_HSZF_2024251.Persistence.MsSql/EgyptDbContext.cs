using L54E2T_HSZF_2024251.Model;
using Microsoft.EntityFrameworkCore;

namespace L54E2T_HSZF_2024251.Persistence.MsSql
{
    //database
    public class EgyptDb : DbContext
    {
        
        public DbSet<Pharaohs> Pharaohs { get; set; }
        public DbSet<Workers> Workers { get; set; }
        public DbSet<Projects> Projects { get; set; }
        public DbSet<WorkerRelationShip> WorkerRelations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pharaohs>()
                .HasMany(x => x.Projects)
                .WithOne()
                .HasForeignKey(x => x.PharaoId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Projects>()
                .HasMany(x => x.Workers)
                .WithOne()
                .HasForeignKey(x => x.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Workers>()
                .HasMany(x => x.subWorkers)
                .WithMany()
                .UsingEntity<WorkerRelationShip>(x => x.HasOne<Workers>().WithMany().HasForeignKey(y => y.WorkerId),
                                                  z => z.HasOne<Workers>().WithMany().HasForeignKey(q => q.ManagerId));
                

        }
        public EgyptDb()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EgyptDb;Trusted_Connection=True;");
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }
        
        
        


    }
}
