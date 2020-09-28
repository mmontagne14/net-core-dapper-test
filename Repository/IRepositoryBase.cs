using BlogPostApi.Model;
using System.Collections.Generic;

namespace BlogPostApi.Repository
{
    public interface IRepositoryBase
    {
        List<Cidade> SearchCidades(string nome);

        List<Uf> SearchUfs(string nome);

        List<Pais> SearchPaises(string nome);

        void Dispose();




    }
}