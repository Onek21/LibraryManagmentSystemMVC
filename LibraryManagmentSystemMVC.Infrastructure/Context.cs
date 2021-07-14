using LibraryManagmentSystemMVC.Domain.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystemMVC.Infrastructure
{
    public class Context : IdentityDbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookAuthor> BookAuthor { get; set; }
        public DbSet<BookGenre> BookGenre { get; set; }
        public DbSet<BookReservation> BookReservations { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<ReservationState> ReservationStates { get; set; }


        public Context(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ReservationState>()
                .HasOne(a => a.BookReservation).WithOne(b => b.ReservationState)
                .HasForeignKey<BookReservation>(f => f.ReservationStateId);

            builder.Entity<BookAuthor>()
                .HasKey(it => new { it.BookId, it.AuthorId });

            builder.Entity<BookAuthor>()
                .HasOne<Book>(it => it.Book).WithMany(i => i.BookAuthors)
                .HasForeignKey(it => it.BookId);

            builder.Entity<BookAuthor>()
                .HasOne<Author>(it => it.Author).WithMany(i => i.BookAuthors)
                .HasForeignKey(it => it.AuthorId);

            builder.Entity<BookGenre>()
                .HasKey(it => new { it.BookId, it.GenreId });

            builder.Entity<BookGenre>()
                .HasOne<Book>(it => it.Book).WithMany(i => i.BookGeners)
                .HasForeignKey(it => it.BookId);

            builder.Entity<BookGenre>()
                .HasOne<Genre>(it => it.Genre).WithMany(i => i.BookGenres)
                .HasForeignKey(it => it.GenreId);
        }
    }
}
