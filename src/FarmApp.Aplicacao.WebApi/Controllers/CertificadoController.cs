using FarmApp.Aplicacao.WebApi.Conversores.Interfaces;
using FarmApp.Dominio.Mediator.Mediators.Requests.Consultar;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace FarmApp.Aplicacao.WebApi.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class CertificadoController : Controller
    {
        private readonly IMediator mediator;
        private readonly ICertificadoContratoConversor certificadoContratoConversor;

        public CertificadoController(
            IMediator mediator,
            ICertificadoContratoConversor certificadoContratoConversor)
        {
            this.mediator = mediator;
            this.certificadoContratoConversor = certificadoContratoConversor;
        }

        [HttpGet("validar/{token}")]
        public async Task<IActionResult> Get([FromRoute][Required] string token)
        {
            var request = new VerificarCertificadoRequest(token);

            var response = await mediator.Send(request);

            var retorno = certificadoContratoConversor.ConverterContratoParaViewModel(response);

            if (retorno == null)
                return NotFound();
            else
                return Ok(retorno);
        }
    }
}