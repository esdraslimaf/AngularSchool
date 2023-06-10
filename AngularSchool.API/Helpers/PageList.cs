using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularSchool.API.Helpers
{
    public class PageList<T> : List<T>
    {
        public int PaginaAtual { get; set; }
        public int TotalDePaginas { get; set; }
        public int TamanhoDasPaginas { get; set; }
        public int ItensTotal { get; set; }

        public PageList(List<T> items, int quantidade, int numeroDaPagina, int tamanhoDasPaginas)
        {
            ItensTotal = quantidade;
            TamanhoDasPaginas = tamanhoDasPaginas;
            PaginaAtual = numeroDaPagina;
            TotalDePaginas = (int)Math.Ceiling(quantidade / (double)tamanhoDasPaginas);
            this.AddRange(items);
        }

        public static async Task<PageList<T>> CreateAsync(IQueryable<T> source, int numeroDaPagina, int tamanhoDasPaginas)
        {
            var quantidade = await source.CountAsync();
            var items = await source.Skip((numeroDaPagina - 1) * tamanhoDasPaginas).Take(tamanhoDasPaginas).ToListAsync();
            return new PageList<T>(items, quantidade, numeroDaPagina, tamanhoDasPaginas);
        }

    }
}
