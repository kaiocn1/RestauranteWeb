using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestauranteWeb.Application.Contracts;
using RestauranteWeb.Application.ViewModels.Pratos;
using System;
using System.Threading.Tasks;

namespace RestauranteWeb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PratoController : Controller
    {
        private readonly IPratoAppService _pratoAppServiceprato;

        public PratoController(IPratoAppService contaAppService)
        {
            _pratoAppServiceprato = contaAppService;
        }

        [HttpPost]
        [Route("Post")]
        public async Task<IActionResult> Post([FromBody] PratoViewModel prato)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _pratoAppServiceprato.Add(prato));
        }

        [HttpGet]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _pratoAppServiceprato.GetById(id));
        }

        [AllowAnonymous]
        [Route("ObterPorId")]
        [HttpGet]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _pratoAppServiceprato.GetById(id));
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add([FromBody] PratoViewModel prato)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var retorno = await _pratoAppServiceprato.Add(prato);
            return Ok(retorno);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] PratoViewModel prato)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var retorno = await _pratoAppServiceprato.Update(prato);
            return Ok(retorno);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _pratoAppServiceprato.GetAll());
        }

        [HttpDelete]
        [AllowAnonymous]
        [Route("Remove")]
        public async Task<IActionResult> Remove(Guid id)
        {
            return Ok(await _pratoAppServiceprato.Remove(id));
        }
    }
}
