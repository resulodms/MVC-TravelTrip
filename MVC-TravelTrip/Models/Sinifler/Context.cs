using Microsoft.EntityFrameworkCore;
namespace MVC_TravelTrip.Models.Sinifler
{
    public class Context:DbContext
    {
       
            public Context(DbContextOptions<Context> options)
                : base(options)
            {
            }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<AdresBlog> AdresBlogs { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Hakkimizda> Hakkimizdas { get; set; }
        public DbSet<Iletisim> Iletisims { get; set; }
        public DbSet<Yorumlar> Yorumlars { get; set; }





    }
}
