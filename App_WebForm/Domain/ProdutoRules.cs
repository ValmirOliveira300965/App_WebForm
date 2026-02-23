using System;

namespace App_WebForm.Domain
{
    public static class ProdutoRules
    {
        // Regra simples (exemplo): normalizar termo de busca
        public static string NormalizarBusca(string texto)
        {
            texto = (texto ?? "").Trim();

            if (texto.Length < 3)
                throw new ArgumentException("Digite ao menos 3 caracteres para pesquisar.");

            return texto;
        }
    }
}
