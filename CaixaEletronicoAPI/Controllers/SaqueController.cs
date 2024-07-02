using Microsoft.AspNetCore.Mvc;
using CaixaEletronicoAPI.Services;
using CaixaEletronicoAPI.Models;
using System.Linq;

namespace CaixaEletronicoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SaqueController : ControllerBase
    {
        private readonly SaqueService _saqueService;
        private const int MaxSaque = 100000; // Definindo um limite máximo para o saque

        public SaqueController(SaqueService saqueService)
        {
            _saqueService = saqueService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] SaqueRequest request)
        {
            if (request.Valor <= 0)
            {
                return BadRequest("Valor de saque deve ser um número inteiro positivo.");
            }

            if (request.Valor > MaxSaque)
            {
                return BadRequest($"Valor de saque não pode exceder {MaxSaque}.");
            }

            try
            {
                var response = _saqueService.CalcularCedulas(request.Valor);
                var orderedResponse = response.OrderByDescending(c => c.Key).ToDictionary(c => c.Key, c => c.Value);
                return Ok(orderedResponse);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao processar o saque: {ex.Message}");
            }
        }
    }
}
