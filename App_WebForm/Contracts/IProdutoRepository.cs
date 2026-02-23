using System.Data;

namespace App_WebForm.Contracts
{
    public interface IProdutoRepository
    {
        DataTable BuscarPorDescricao(string termo);
    }
}
