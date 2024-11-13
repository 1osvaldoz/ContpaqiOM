using ContpaqiOM.Models;
using ContpaqiOM.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ContpaqiOM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConvertController : Controller
    {
        private readonly ILogger<ConvertController> _logger;

        public ConvertController(ILogger<ConvertController> logger)
        {
            _logger = logger;
        }

        [HttpPost("[Action]")]
        public IActionResult ConvertXMLToJson([FromBody] RequestDTO request)
        {
            try
            {
                Comprobante comprobante = new Comprobante();
                comprobante.init(request.xml);
                if (comprobante.Errors.Count > 0)
                {
                    Response.StatusCode = 400;
                    return Json(new { status = 400, title = "Error al leer XML", detail = "Error al leer el XML", errors = comprobante.Errors });
                }
                return Json(comprobante);
            }
            catch (Exception e)
            {
                Response.StatusCode = 400;
                return Json(new { status = 400, title = "Error al leer XML", detail = "Error al leer el XML", errors = new List<string> { e.Message } });
            }
        }
    }
}
