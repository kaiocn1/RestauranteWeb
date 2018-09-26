using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestauranteWeb.Application.Contracts;
using RestauranteWeb.Application.ViewModels.Restaurantes;
using System;
using System.Threading.Tasks;

namespace RestauranteWeb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestauranteController : Controller
    {
        private readonly IRestauranteAppService _profissionalAppService;

        public RestauranteController(IRestauranteAppService contaAppService)
        {
            _profissionalAppService = contaAppService;
        }

        [HttpPost]
        [Route("Post")]
        public async Task<IActionResult> Post([FromBody] RestauranteViewModel profissionalViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _profissionalAppService.Add(profissionalViewModel));
        }

        [HttpGet]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _profissionalAppService.GetById(id));
        }

        [AllowAnonymous]
        [Route("ObterPorId")]
        [HttpGet]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _profissionalAppService.GetById(id));
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add([FromBody] RestauranteViewModel conta)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var retorno = await _profissionalAppService.Add(conta);
            return Ok(retorno);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] RestauranteViewModel conta)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var retorno = await _profissionalAppService.Update(conta);
            return Ok(retorno);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(long id)
        {
            return Ok(await _profissionalAppService.GetAll());
        }
    }
}