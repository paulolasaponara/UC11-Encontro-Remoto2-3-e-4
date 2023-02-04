using Chapter.WebApi.Contexts;
using Chapter.WebApi.Interfaces;
using Chapter.WebApi.Models;

namespace Chapter.WebApi.Repositories
{

    /// <summary>
    /// repositorio para classe livro, devera se comunicar com o contexto
    /// vai pegar a solicitaçao do controller e vai acessar as informaçoes no banco de dados via context
    /// herda da interface ILivroRepository
    /// </summary>

    public class LivroRepository : ILivroRepository
    {
        //variavel privada criada para armazenar os dados do context
        private readonly ChapterContext _chapterContext;

        //injeçao de dependencia: o repository depende do context
        public LivroRepository(ChapterContext context)
        {
            _chapterContext = context; //armazenamento das informaçoes do context dentro da variavel privada
        }

        public void Atualizar(int id, Livro livro)
        {
            Livro livroBuscado = _chapterContext.Livros.Find(id);

            if (livroBuscado != null)
            {
                livroBuscado.Titulo = livro.Titulo;
                livroBuscado.QuantidadedePaginas = livro.QuantidadedePaginas;
                livroBuscado.Disponivel = livro.Disponivel;
            }

            _chapterContext.Livros.Update(livroBuscado);
            _chapterContext.SaveChanges();
        }

        public Livro BuscarPorId(int id)
        {
            return _chapterContext.Livros.Find(id);
        }

        public Livro BuscarPorTitulo(string titulo)
        {
            return _chapterContext.Livros.FirstOrDefault(t => t.Titulo == titulo.Trim());
        }

        public void Cadastrar(Livro livro)
        {
            _chapterContext.Livros.Add(livro);
            _chapterContext.SaveChanges();
        }

        public void Deletar(int id)
        {
            Livro livro = _chapterContext.Livros.Find(id);
            _chapterContext.Livros.Remove(livro);
            _chapterContext.SaveChanges();
        }

        //metodo implementado da interface
        public List<Livro> Ler()
        {
            return _chapterContext.Livros.ToList(); //o contexto acessa a tabela livros e lista os itens dentro dela
        }
    }
}
