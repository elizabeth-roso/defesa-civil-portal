using Microsoft.AspNetCore.Mvc;
using portal_defesa_civil.Models;
using System.Diagnostics;
using System.Net.Http.Json;
using portal_defesa_civil.DTOs;

namespace portal_defesa_civil.Controllers
{
    public class HomeController : Controller
    {
        private async Task<List<NoticiaDTO>> GetNoticiasMaisRecentes(int pageSize)
        {
            HttpClient client = new HttpClient();
            string baseUrl = "https://d-api.praiagrande.sp.gov.br/api/noticias";
            var items = await BuscarEExibirPaginadoAsync(client, $"{baseUrl}/publicadas?pageSize={pageSize}");
            return items;
        }

        async private Task<List<NoticiaDTO>> BuscarEExibirPaginadoAsync(HttpClient cliente, string urlBaseDaBusca)
        {
            NoticiaPagedResultDTO? resultado = null;
            int nextPage = 1;
            do
            {
                string urlCompleta = urlBaseDaBusca.Contains("?")
                    ? $"{urlBaseDaBusca}&page={nextPage}"
                    : $"{urlBaseDaBusca}?page={nextPage}";

                var resposta = await cliente.GetAsync(urlCompleta);
                resposta.EnsureSuccessStatusCode();

                resultado = await resposta.Content.ReadFromJsonAsync<NoticiaPagedResultDTO>();

                if (resultado != null)
                {
                    return resultado.Items;
                }

                nextPage++;

            } while (resultado != null && resultado.HasNextPage);
            return new List<NoticiaDTO>();
        }

        public IActionResult Index()
        {
            HomeViewModel model = new HomeViewModel();
            model.ListaNoticiasPrincipais = await GetNoticiasMaisRecentes(5);
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
