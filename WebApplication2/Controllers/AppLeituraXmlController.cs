using Microsoft.AspNetCore.Mvc;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    public class AppLeituraXmlController : Controller
    {
        private readonly AppLeituraXmlService _appLeituraXmlService;
        public AppLeituraXmlController(AppLeituraXmlService appLeituraXmlService) {
            _appLeituraXmlService = appLeituraXmlService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public void InserirDadosDoArquivo(IFormFile arquivoXml)
        {
            var dados = _appLeituraXmlService.LerXml(arquivoXml);

            _appLeituraXmlService.Insert(dados);
        }
    }
}
