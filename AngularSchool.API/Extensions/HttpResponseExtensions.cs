using AngularSchool.API.Helpers;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace AngularSchool.API.Extensions
{
    public static class HttpResponseExtensions
    {
        public static void AddPagination(this HttpResponse response, int paginaAtual, int itensPorPagina, int itensTotal, int totalDePaginas) {

            var paginationeader = new PaginationHeader(paginaAtual, itensPorPagina, itensTotal, totalDePaginas);
            
            var camelCaseFormatter = new JsonSerializerSettings();
            camelCaseFormatter.ContractResolver = new CamelCasePropertyNamesContractResolver();

            response.Headers.Add("Pagination", JsonConvert.SerializeObject(paginationeader, camelCaseFormatter));
            response.Headers.Add("Acess-Control-Expose-Header", "Pagination");
        } 
    }
}
