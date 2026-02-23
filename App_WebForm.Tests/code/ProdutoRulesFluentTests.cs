using System;
using App_WebForm.Domain;
using FluentAssertions;
using Xunit;

public class ProdutoRulesFluentTests
{
    [Fact]
    public void NormalizarBusca_DeveTrimar()
    {
        ProdutoRules.NormalizarBusca("  arroz  ").Should().Be("arroz");
    }

    [Fact]
    public void NormalizarBusca_ComMenosDe3_DeveFalhar()
    {
        Action act = () => ProdutoRules.NormalizarBusca("ab");
        act.Should().Throw<ArgumentException>();
    }
}