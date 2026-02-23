using System.Data;
using App_WebForm.Application;
using App_WebForm.Contracts;
using Moq;
using Xunit;

/* Mock: Testes de:
   * Comportamento
   * Fluxo
   * Chamadas
   * Interações
*/

namespace App_WebForm.Tests
{
    public class ProdutoAppServiceTests
    {
        [Fact]
        public void Buscar_TermoValido_DeveChamarRepositorioUmaVez()
        {
            var repo = new Mock<IProdutoRepository>();
            repo.Setup(r => r.BuscarPorDescricao("arroz")).Returns(new DataTable());

            var app = new ProdutoAppService(repo.Object);

            var dt = app.Buscar("  arroz  ");

            repo.Verify(r => r.BuscarPorDescricao("arroz"), Times.Once);
        }

        [Fact]
        public void Buscar_TermoInvalido_DeveLancarE_NaoChamarRepositorio()
        {
            var repo = new Mock<IProdutoRepository>();
            var app = new ProdutoAppService(repo.Object);

            Assert.Throws<System.ArgumentException>(() => app.Buscar("ab"));

            repo.Verify(r => r.BuscarPorDescricao(It.IsAny<string>()), Times.Never);
        }
    }
}
