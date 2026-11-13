using portal_defesa_civil.DTOs;
using System.Net.Http.Json;
using System.Text.Json;

namespace portal_defesa_civil.Services
{
    public class NoticiaService
    {
        private readonly HttpClient _httpClient;
        public NoticiaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<NoticiaPagedResultDTO> GetNoticias(int pageSize, int page)
        {
            // https://t-api.praiagrande.sp.gov.br/index.html
            string baseUrl = "https://t-api.praiagrande.sp.gov.br/api/noticias";
            string urlBusca = $"{baseUrl}?page={page}&pageSize={pageSize}&orderBy=data&descending=true";
            // string urlBusca = $"{baseUrl}/categoria/58?page={page}&pageSize={pageSize}&orderBy=data&descending=true";
            var resposta = await _httpClient.GetAsync(urlBusca);
            resposta.EnsureSuccessStatusCode();
            NoticiaPagedResultDTO? resultado = await resposta.Content.ReadFromJsonAsync<NoticiaPagedResultDTO>();
            return resultado;
        }

        public async Task<NoticiaDTO> GetNoticiaById(int id)
        {
            string baseUrl = "https://t-api.praiagrande.sp.gov.br/api/noticias";
            var resposta = await _httpClient.GetAsync($"{baseUrl}/{id}");
            resposta.EnsureSuccessStatusCode();
            var noticia = await resposta.Content.ReadFromJsonAsync<NoticiaDTO>();
            return noticia;
        }  
    }
}
