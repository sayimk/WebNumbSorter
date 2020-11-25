namespace NumberSorter.Models.NumberModels
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Sorts : DbContext
    {
        public Sorts()
            : base("name=Sorts")
        {
        }

        public virtual DbSet<Sort> SortedNumbers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sort>()
                .Property(e => e.sortedNumbers)
                .IsUnicode(false);

            modelBuilder.Entity<Sort>()
                .Property(e => e.sortTimeMillisec)
                .HasPrecision(8, 4);

            modelBuilder.Entity<Sort>()
                .Property(e => e.sortDirection)
                .IsUnicode(false);
        }
    }
}
