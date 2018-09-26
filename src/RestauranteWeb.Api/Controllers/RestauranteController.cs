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
        private readonly IRestauranteAppService _restauranteAppService;

        public RestauranteController(IRestauranteAppService contaAppService)
        {
            _restauranteAppService = contaAppService;
        }

        [HttpPost]
        [Route("Post")]
        public async Task<IActionResult> Post([FromBody] RestauranteViewModel restaurante)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _restauranteAppService.Add(restaurante));
        }

        [HttpGet]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _restauranteAppService.GetById(id));
        }

        [AllowAnonymous]
        [Route("ObterPorId")]
        [HttpGet]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _restauranteAppService.GetById(id));
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add([FromBody] RestauranteViewModel restaurante)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var retorno = await _restauranteAppService.Add(restaurante);
            return Ok(retorno);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] RestauranteViewModel restaurante)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var retorno = await _restauranteAppService.Update(restaurante);
            return Ok(retorno);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _restauranteAppService.GetAll());
        }

        [HttpDelete]
        [AllowAnonymous]
        [Route("Remove")]
        public async Task<IActionResult> Remove(Guid id)
        {
            return Ok(await _restauranteAppService.Remove(id));
        }
    }
}