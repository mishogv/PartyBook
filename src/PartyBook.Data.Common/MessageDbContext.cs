namespace PartyBook.Data.Common
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public abstract class MessageDbContext : DbContext
    {
        protected MessageDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
               .Entity<Message>()
               .HasKey(m => m.Id);

            builder
                .Entity<Message>()
                .Property<string>("serializedData")
                .IsRequired()
                .HasField("serializedData");

            builder
                .Entity<Message>()
                .Property(m => m.Type)
                .IsRequired()
                .HasConversion(
                    t => t.AssemblyQualifiedName,
                    t => Type.GetType(t));

            base.OnModelCreating(builder);
        }
    }
}
