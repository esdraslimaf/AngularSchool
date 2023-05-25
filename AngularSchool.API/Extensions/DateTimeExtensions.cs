using System;

namespace AngularSchool.API.Extensions
{
    public static class DateTimeExtensions
    {
        public static int PegarIdadeAtual(this DateTime data)
        {
            var dataAtual = DateTime.UtcNow;
            int idade = dataAtual.Year - data.Year;
            if (dataAtual < data.AddYears(idade)) idade--;
            return idade;
        }
    }
}
