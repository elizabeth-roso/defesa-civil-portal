using Microsoft.AspNetCore.Mvc;
using portal_defesa_civil.DTOs;
using portal_defesa_civil.Models;
using portal_defesa_civil.Services;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Text.Json;

namespace portal_defesa_civil.Controllers
{
    public class HomeController : Controller
    {
        private readonly NoticiaService _noticiaService;
        public HomeController(NoticiaService noticiaService)
        {
            _noticiaService = noticiaService;
        }

        public async Task<IActionResult> Index()
        {
            HomeViewModel model = new HomeViewModel();
            model.ListaNoticiasPrincipais = await _noticiaService.GetNoticias(4, 1);
            if (model.ListaNoticiasPrincipais.Items == null || !model.ListaNoticiasPrincipais.Items.Any())
            {
                model.ListaNoticiasPrincipais = new NoticiaPagedResultDTO
                {
                    Items = new List<NoticiaDTO>()
                };
            }
            return View(model);
        }

        public async Task<IActionResult> Noticia(int id)
        {
            var noticia = await _noticiaService.GetNoticiaById(id);
            if (noticia == null)
            {
                return NotFound();
            }
            return View(noticia);
        }

        public async Task<IActionResult> TodasNoticias(int pagina = 1)
        {
            var noticias = await _noticiaService.GetNoticias(10, pagina);
            return View(noticias);
        }

        public async Task<IActionResult> CarregarMaisNoticias(int pagina)
        {
            var noticias = await _noticiaService.GetNoticias(10, pagina);
            return Json(noticias);
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
