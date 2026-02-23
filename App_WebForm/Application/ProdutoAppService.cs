using System.Data;
using App_WebForm.Contracts;
using App_WebForm.Domain;

namespace App_WebForm.Application
{
    public class ProdutoAppService
    {
        private readonly IProdutoRepository _repo;

        public ProdutoAppService(IProdutoRepository repo)
        {
            _repo = repo;
        }

        public DataTable Buscar(string termo)
        {
            var termoOk = ProdutoRules.NormalizarBusca(termo);
            return _repo.BuscarPorDescricao(termoOk);
        }
    }
}
