using System;
using App_WebForm.Domain;
using Xunit;

namespace App_WebForm.Tests
{
    public class CalculoRulesTests
    {
        [Fact]
        public void CalcularTotal_DeveSomarESubtrairCorretamente()
        {
            var total = CalculoRules.CalcularTotal(100m, 20m, 10m);
            Assert.Equal(110m, total);
        }

        [Fact]
        public void CalcularTotal_SeFicarNegativo_DeveRetornarZero()
        {
            var total = CalculoRules.CalcularTotal(10m, 0m, 50m);
            Assert.Equal(0m, total);
        }

        [Theory]
        [InlineData(-1, 0, 0)]
        [InlineData(0, -1, 0)]
        [InlineData(0, 0, -1)]
        public void CalcularTotal_ComValoresNegativos_DeveLancarExcecao(decimal subtotal, decimal frete, decimal desconto)
        {
            Assert.Throws<ArgumentException>(() => CalculoRules.CalcularTotal(subtotal, frete, desconto));
        }
    }
}
