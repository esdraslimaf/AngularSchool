namespace AngularSchool.API.Helpers
{
    public class PaginationHeader
    {
        public int PaginaAtual { get; set; }
        public int ItensPorPagina { get; set; }
        public int ItensTotal { get; set; }
        public int TotalDePaginas { get; set; }

        public PaginationHeader(int paginaAtual, int itensPorPagina, int itensTotal, int totalDePaginas)
        {
            PaginaAtual = paginaAtual;
            ItensPorPagina = itensPorPagina;
            ItensTotal = itensTotal;
            TotalDePaginas = totalDePaginas;
        }
    }
}
