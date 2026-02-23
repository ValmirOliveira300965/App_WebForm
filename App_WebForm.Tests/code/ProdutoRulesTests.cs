using App_WebForm.Domain;
using System;
using Xunit;

/* Testes unitários */

namespace App_WebForm.Tests
{
    public class ProdutoRulesTests
    {
        [Fact]
        public void NormalizarBusca_ComMenosDe3Caracteres_DeveLancarExcecao()
        {
            Assert.Throws<ArgumentException>(() => ProdutoRules.NormalizarBusca("ab"));
        }

        [Fact]
        public void NormalizarBusca_DeveRemoverEspacos()
        {
            var resultado = ProdutoRules.NormalizarBusca("   arroz   ");
            Assert.Equal("arroz", resultado);
        }
    }
}
