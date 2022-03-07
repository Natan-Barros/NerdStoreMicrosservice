using MediatR;
using Microsoft.AspNetCore.Mvc;
using NSE.Clientes.API.Application.Commands;
using NSE.WebAPI.Core.Controllers;

namespace NSE.Clientes.API.Controllers
{
    public class ClientesController : MainController
    {
        private readonly IMediator _mediator;

        public ClientesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("clientes")]
        public async Task<IActionResult> Index()
        {
            var resultado = await _mediator.Send(new RegistrarClienteCommand(Guid.NewGuid(), "Natan", "natanbarros133@gmail.com", "29521567007"));

            return CustomResponse(resultado);
        }
    }
}
