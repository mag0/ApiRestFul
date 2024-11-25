using MiApiRestFul.api.Models;
using Microsoft.EntityFrameworkCore;

namespace MiApiRestFul.api.Data;

public class ApiDbContext : DbContext
{
    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) {}

    public DbSet<Usuario> Usuarios { get; set; }
}
