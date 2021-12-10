using FarmApp.Aplicacao.WebApi.Conversores.Interfaces;
using FarmApp.Aplicacao.WebApi.ViewModel;
using FarmApp.Dominio.Mediator.Mediators.Requests.Comandos;
using FarmApp.Dominio.Mediator.Mediators.Requests.Consultar;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace FarmApp.Aplicacao.WebApi.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IUsuarioContratoConversor usuarioContratoConversor;

        public UsuarioController(
            IMediator mediator,
            IUsuarioContratoConversor usuarioContratoConversor)
        {
            this.mediator = mediator;
            this.usuarioContratoConversor = usuarioContratoConversor;
        }

        [HttpGet("buscar/{id}", Name = "buscar")]
        public async Task<IActionResult> Buscar([FromRoute][Required] Guid id)
        {
            var request = new ObterUsuarioPorIdRequest(id);

            var response = await mediator.Send(request);

            var retorno = usuarioContratoConversor.ConverterContratoParaViewModel(response);

            if (retorno is null)
                return NotFound();
            else
                return Ok(retorno);
        }

        [HttpGet("validar/{telefone}")]
        public async Task<IActionResult> Validar([FromRoute][Required] string telefone)
        {
            var request = new ObterUsuarioPorTelefoneRequest(telefone);

            var response = await mediator.Send(request);

            var retorno = usuarioContratoConversor.ConverterContratoParaViewModel(response);

            if (retorno is null)
                return Accepted();
            else
                return Ok(retorno);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UsuarioViewModel viewModel)
        {
            var contrato = usuarioContratoConversor.ConverterViewModelParaContrato(viewModel);
            var request = new UsuarioAdicionarRequest(contrato);

            var response = await mediator.Send(request);

            return CreatedAtRoute(
                routeName: "buscar",
                routeValues: new { id = response.Usuario.Id },
                value: response.Usuario);
        }
    }
}