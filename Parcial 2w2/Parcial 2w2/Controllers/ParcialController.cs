using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parcial_2w2.Dominio;
using Parcial_2w2.Services.Interfaces;

namespace Parcial_2w2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParcialController : ControllerBase
    {
        private readonly IParcialService _parcialService;

        public ParcialController(IParcialService parcialService)
        {
            _parcialService = parcialService;
        }

        [HttpGet("ObtenerTodasLasObras")]
        public async Task<IActionResult> ObtenerTodasLasObras()
        {
            var response = await _parcialService.ObtenerObrasAsync();

            if (response.Success)
            {
                return Ok(response);
            }

            return StatusCode(StatusCodes.Status500InternalServerError, response);
        }

        [HttpPost("PostAlbanilXObra")]
        public async Task<IActionResult> PostAlbanilXObra(PostAlbanilXObraDto albXObra)
        {
            var response = await _parcialService.PostAlbanilXObraAsync(albXObra);

            if (response.Success)
            {
                return Ok(response);
            }

            return StatusCode(StatusCodes.Status500InternalServerError, response);
        }

        [HttpPost("PostAlbanil")]
        public async Task<IActionResult> PostAlbanil(PostAlbanilDto albanil)
        {
            var response = await _parcialService.PostAlbanilAsync(albanil);

            if (response.Success)
            {
                return Ok(response);
            }

            return StatusCode(StatusCodes.Status500InternalServerError, response);
        }

        [HttpGet("ObtenerAlbanilesNoParteObra/{idObra}")]
        public async Task<IActionResult> ObtenerAlbanilesNoParteObra(Guid idObra)
        {
            var response = await _parcialService.ObtenerAlbanilesNoParteObraAsync(idObra);

            if (response.Success)
            {
                return Ok(response);
            }

            return StatusCode(StatusCodes.Status500InternalServerError, response);
        }

        [HttpGet("ObtenerTodosLosAlbaniles")]
        public async Task<IActionResult> ObtenerAlbaniles()
        {
            var response = await _parcialService.ObtenerAlbanilesAsync();

            if (response.Success)
            {
                return Ok(response);
            }

            return StatusCode(StatusCodes.Status500InternalServerError, response);
        }
    }
}
