using WebApiefcoremigrationautomatic.Entity;

namespace WebApiefcoremigrationautomatic.Data
{
    public static class DBInitializerSeedData
    {
        public static void InitializeDatabase(BLobDbContext bLobDbContext)
        {
            if (bLobDbContext.Blogs.Any())
                return;

            var blogOne = new Blog
            {
                Name = "c#",
                Author = "kartik",
                Description = "C sharp is a good langauge",

            };
            var blogTwo = new Blog
            {
                Name = "web api",
                Author = "kartik",
                Description = "web apiis a good langauge",

            };
            var blogThree = new Blog
            {
                Name = "Blazor",
                Author = "kartik",
                Description = "Blazor is a good langauge",

            };

            bLobDbContext.Blogs.Add(blogOne);
            bLobDbContext.Blogs.Add(blogTwo);
            bLobDbContext.Blogs.Add(blogThree);

            bLobDbContext.SaveChanges();
        }
    }
}
