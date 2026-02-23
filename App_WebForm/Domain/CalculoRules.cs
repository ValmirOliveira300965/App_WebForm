using System;

namespace App_WebForm.Domain
{
    public static class CalculoRules
    {
        public static decimal CalcularTotal(decimal subtotal, decimal frete, decimal desconto)
        {
            if (subtotal < 0 || frete < 0 || desconto < 0)
                throw new ArgumentException("Valores não podem ser negativos.");

            var total = subtotal + frete - desconto;
            return total < 0 ? 0 : total;
        }
    }
}
