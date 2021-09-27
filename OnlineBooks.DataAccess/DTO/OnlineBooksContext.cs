using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace OnlineBooks.DataAccess.DTO
{
    public partial class OnlineBooksContext : DbContext
    {
        public OnlineBooksContext()
        {
        }

        public OnlineBooksContext(DbContextOptions<OnlineBooksContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BookCatalogue> BookCatalogues { get; set; }
        public virtual DbSet<Catalogue> Catalogues { get; set; }
        public virtual DbSet<OnlineUser> OnlineUsers { get; set; }
        public virtual DbSet<OnlineUserType> OnlineUserTypes { get; set; }
        public virtual DbSet<Subscription> Subscriptions { get; set; }
        public virtual DbSet<Unsubscribe> Unsubscribes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("Book");

                entity.Property(e => e.BookId).ValueGeneratedNever();

                entity.Property(e => e.Author).HasMaxLength(50);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<BookCatalogue>(entity =>
            {
                entity.ToTable("BookCatalogue");

                entity.Property(e => e.BookCatalogueId).ValueGeneratedNever();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.BookCatalogues)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BookCatalogue_Book");

                entity.HasOne(d => d.Catalogue)
                    .WithMany(p => p.BookCatalogues)
                    .HasForeignKey(d => d.CatalogueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BookCatalogue_Catalogue");
            });

            modelBuilder.Entity<Catalogue>(entity =>
            {
                entity.ToTable("Catalogue");

                entity.Property(e => e.CatalogueId).ValueGeneratedNever();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<OnlineUser>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("OnlineUser");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.OnlineUserType)
                    .WithMany(p => p.OnlineUsers)
                    .HasForeignKey(d => d.OnlineUserTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OnlineUser_OnlineUserType");
            });

            modelBuilder.Entity<OnlineUserType>(entity =>
            {
                entity.ToTable("OnlineUserType");

                entity.Property(e => e.OnlineUserTypeId).ValueGeneratedNever();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.OnlineUserTypeName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Subscription>(entity =>
            {
                entity.ToTable("Subscription");

                entity.Property(e => e.SubscriptionId).ValueGeneratedNever();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Reference)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Catalogue)
                    .WithMany(p => p.Subscriptions)
                    .HasForeignKey(d => d.CatalogueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Subscription_Catalogue");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Subscriptions)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Subscription_OnlineUser");
            });

            modelBuilder.Entity<Unsubscribe>(entity =>
            {
                entity.ToTable("Unsubscribe");

                entity.Property(e => e.UnsubscribeId).ValueGeneratedNever();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.Unsubscribes)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Unsubscribe_Book");

                entity.HasOne(d => d.Subscription)
                    .WithMany(p => p.Unsubscribes)
                    .HasForeignKey(d => d.SubscriptionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Unsubscribe_Subscription");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Unsubscribes)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Unsubscribe_OnlineUser");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
