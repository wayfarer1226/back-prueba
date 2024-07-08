using LocalPost.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace LocalPost.Infraestructure
{
    public class LocalPostDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public LocalPostDbContext(DbContextOptions<LocalPostDbContext> options, IConfiguration configuration)
    : base(options)
        {
            _configuration = configuration;
        }



        public DbSet<Posts> Posts { get; set; }

        public IDbConnection Connect() => new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection"));
    }
}
