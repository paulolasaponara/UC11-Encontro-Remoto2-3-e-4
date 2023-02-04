using Chapter.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Chapter.WebApi.Contexts
{

    /// <summary>
    /// Classe responsavel pelo contexto do projeto
    /// Faz comunicação entre API e o banco de dados
    /// </summary>
    public class ChapterContext : DbContext
    {
        /// <summary>
        /// Metodo construtor vazio
        /// </summary>
        public ChapterContext()
        {

        }

        /// <summary>
        /// metodo construtor com parametros a classe DbContextOptions e herdando de base
        /// https://learn.microsoft.com/pt-br/aspnet/core/tutorials/first-web-api?view=aspnetcore-7.0&tabs=visual-studio
        /// </summary>
        /// <param name="options"></param>
        public ChapterContext(DbContextOptions<ChapterContext> options) : base(options)
        {

        }
        // vamos utilizar esse método para configurar o banco de dados
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // cada provedor tem sua sintaxe para especificação
                optionsBuilder.UseSqlServer("Data Source = LAPTOP-UNHD8A18\\SQLEXPRESS; initial catalog = Chapter; User Id= sa; pwd= 310579; TrustServerCertificate=True");
            }
        }
        // dbset representa as entidades que serão utilizadas nas operações de leitura, criação, atualização e deleção
        public DbSet<Livro> Livros { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}

