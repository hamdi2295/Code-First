namespace News.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    

    internal sealed class configuration : DbMigrationsConfiguration<News.Models.BaseContext>
    {
        public configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "BaseContext";
        }

        protected override void Seed(News.Models.BaseContext context)
        {
            
        }
    }
}
