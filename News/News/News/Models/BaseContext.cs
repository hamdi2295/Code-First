namespace News.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BaseContext : DbContext
    {
        public BaseContext()
            : base("Day_News")
        {
            

        }

        public DbSet<news_user> news_user { get; set; }
        public DbSet<news_report> news_report { get; set; }
        public DbSet<category> category { get; set; }
        public DbSet<det_cat> det_cat { get; set; }
        public DbSet<tag> tag { get; set; }
        public DbSet<det_tag> det_tag { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
