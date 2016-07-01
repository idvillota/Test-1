namespace SuperZapatos.Migrations
{
    using Models;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<SuperZapatos.Models.SuperZapatosContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SuperZapatosContext context)
        {
            context.Stores.AddOrUpdate(
                s => s.id,
                new Store { id = 1, Name = "Store 1", Address = "Street 1" },
                new Store { id = 2, Name = "Store 3", Address = "Street 3" },
                new Store { id = 3, Name = "Store 2", Address = "Street 2" });

            context.Articles.AddOrUpdate(a => a.id,
                new Article { id = 1, Name = "Article 1", Description = "Article 1 description", Price = 100, Total_in_shelf = 10, Total_in_vault = 10, StoreId = 2 },
                new Article { id = 2, Name = "Article 4", Description = "Article 4 description", Price = 400, Total_in_shelf = 40, Total_in_vault = 40, StoreId = 1 },
                new Article { id = 3, Name = "Article 2", Description = "Article 2 description", Price = 200, Total_in_shelf = 20, Total_in_vault = 20, StoreId = 3 },
                new Article { id = 4, Name = "Article 3", Description = "Article 3 description", Price = 300, Total_in_shelf = 30, Total_in_vault = 30, StoreId = 3 });
        }
    }
}
