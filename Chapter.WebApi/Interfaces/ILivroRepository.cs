using Chapter.WebApi.Models;

namespace Chapter.WebApi.Interfaces
{

    //Interface ILivroRepository
    public interface ILivroRepository
    {
        List<Livro> Ler(); //metodo que devera ser implementado pela classe que herdar desta interface

        Livro BuscarPorId(int id);

        void Cadastrar(Livro livro);

        void Atualizar(int id, Livro livro);

        void Deletar(int id);

        Livro BuscarPorTitulo(string id);
    }
}
