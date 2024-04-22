using Microsoft.EntityFrameworkCore;

namespace RestoManager_X.Models.RestosModel
{
    public class RestosDbContext:DbContext
    {
        // DbSet pour chaque classe de modèle
        public DbSet<Proprietaire> Proprietaires { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }

        public RestosDbContext(DbContextOptions<RestosDbContext> options) : base(options)
        {
            // Constructeur faisant appel à celui de la super-classe (DbContext)
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Proprietaire>()
                 .ToTable("TProprietaire", schema: "resto") // Nom de la table et schéma
                 .HasKey(p => p.Numero); // Clé primaire

            modelBuilder.Entity<Proprietaire>()
                .Property(p => p.Nom)
                .HasColumnName("NomProp")
                .HasMaxLength(20)
                .IsRequired();

            modelBuilder.Entity<Proprietaire>()
                .Property(p => p.Email)
                .HasColumnName("EmailProp")
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Proprietaire>()
                .Property(p => p.Gsm)
                .HasColumnName("GsmProp")
                .HasMaxLength(8)
                .IsRequired();

            // Configuration de l'entité Restaurant
            modelBuilder.Entity<Restaurant>()
                .ToTable("TRestaurant", schema: "resto") // Nom de la table et schéma
                .HasKey(r => r.CodeResto); // Clé primaire

            modelBuilder.Entity<Restaurant>()
                .Property(r => r.NomResto)
                .HasMaxLength(20)
                .IsRequired();

            modelBuilder.Entity<Restaurant>()
                .Property(r => r.Specialite)
                .HasColumnName("SpecResto")
                .HasMaxLength(20)
                .IsRequired()
                .HasDefaultValue("Tunisienne");

            modelBuilder.Entity<Restaurant>()
                .Property(r => r.Ville)
                .HasColumnName("VilleResto")
                .HasMaxLength(20)
                .IsRequired();

            modelBuilder.Entity<Restaurant>()
                .Property(r => r.Tel)
                .HasColumnName("TelResto")
                .HasMaxLength(8)
                .IsRequired();
            // Configuration de l'association 1 à *
            modelBuilder.Entity<Restaurant>()
                .HasOne(r => r.LeProprio) // Propriété de navigation chez le restaurant
                .WithMany(p => p.LesRestos) // Propriété de navigation chez le propriétaire
                .IsRequired() // Association obligatoire
                .HasForeignKey(r => r.NumProp); // Clé étrangère chez le restaurant
        }
    }
}
