using Microsoft.EntityFrameworkCore;

namespace DemoAcmeAp.Data
{
    public class DemoAcmeApContext : DbContext
    {
        public DemoAcmeApContext(DbContextOptions<DemoAcmeApContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Cliente> Cliente { get; set; }

        public DbSet<Models.Endereco> Endereco { get; set; }

        public DbSet<Models.Fatura> Fatura { get; set; }

        public DbSet<Models.Instalacao> Instalacao { get; set; }
    }
}
