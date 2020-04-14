namespace Logic
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class WindowEvents : DbContext
    {
        public WindowEvents()
            : base("name=WindowEvents")
        {
        }

        public virtual DbSet<TrackedAction> TrackedActions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
