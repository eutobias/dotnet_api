using Microsoft.EntityFrameworkCore;
using ClientesApi.Models;

namespace ClientesApi.Data
{
    public class ClientesApiContext : DbContext
    {
        public ClientesApiContext (DbContextOptions<ClientesApiContext> options)
            : base(options)
        {
        }

        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Enderecos> Enderecos { get; set; }
    }
}