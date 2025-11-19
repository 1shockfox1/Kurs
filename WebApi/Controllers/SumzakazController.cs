using KursProjectISP31.Model;
using WebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{

    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class SumzakazController : ControllerBase
    {
        private readonly SumzakazService sumzakazService;

        public SumzakazController(SumzakazService sumzakazService)
        {
            this.sumzakazService = sumzakazService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sumzakaz>>> GetAllSumzakaz()
        {
            return Ok(await sumzakazService.GetAll());
        }
    
    [HttpGet("{id}")]
        public async Task<ActionResult<Sumzakaz>> GetSumzakazById(int id)
        {
            var chit = await sumzakazService.GetByid(id);
            if (chit == null)
            {
                return NotFound();
            }
            return Ok(chit);
        }


        [HttpPost]
        public async Task<ActionResult<Sumzakaz>> CreateSumzakaz([FromBody] Sumzakaz chit)
        {
            await sumzakazService.Create(chit);
            return CreatedAtAction(nameof(GetSumzakazById), new {Id = chit.Idzakaza}, chit);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Sumzakaz>> UpdateSumzakaz (int id, [FromBody] Sumzakaz chit)
        {
            if (chit.Idzakaza != id) return BadRequest();
            await sumzakazService.Update(chit);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await sumzakazService.Delete(id);
            return NoContent();
        }
    }
}
