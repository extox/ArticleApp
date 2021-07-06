using System;
using Microsoft.Extensions.Configuration;
using ArticleApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ArticleApp.API.Data
{
    public class BaseDbContext : DbContext
    {
        // private readonly IConfiguration _configuration;

        // public BaseDbContext(IConfiguration configuration, DbContextOptions<BaseDbContext> options) : base(options)
        // {
        //     _configuration = configuration;
        // }

        public BaseDbContext(DbContextOptions<BaseDbContext> options) : base(options)
        {

        }

        public DbSet<Article> Articles { get; set; }
    }
}
