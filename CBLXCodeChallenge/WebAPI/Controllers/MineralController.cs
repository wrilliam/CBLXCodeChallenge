using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MineralController : Controller
    {
        #region Attributes

        private readonly BaseDbContext baseDbContext;

        #endregion

        #region Constructor

        public MineralController(BaseDbContext baseDbContext)
        {
            this.baseDbContext = baseDbContext;
        }

        #endregion

        #region Behaviors

        [HttpGet]
        [Route("/Mineral/Select")]
        public async Task<IActionResult> SelectAll()
        {
            var minerais = await baseDbContext.Minerais.ToListAsync();
            return Ok(minerais);
        }

        [HttpGet]
        [Route("/Mineral/SelectById/{id}")]
        [ActionName("SelectMineral")]
        public async Task<IActionResult> SelectById([FromRoute] int id)
        {
            var mineral = await baseDbContext.Minerais.FirstOrDefaultAsync(x => x.Id == id);
            if(mineral != null)
                return Ok(mineral);
            return NotFound("Mineral não encontrado.");
        }

        [HttpPost]
        [Route("/Mineral/Insert")]
        public async Task<IActionResult> Insert([FromBody] Mineral mineral)
        {
            await baseDbContext.Minerais.AddAsync(mineral);
            await baseDbContext.SaveChangesAsync();
            return Ok("Registro criado com sucesso.");
        }

        [HttpPut]
        [Route("/Mineral/Update/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Mineral mineral)
        {
            var mineralExistente = baseDbContext.Minerais.FirstOrDefaultAsync(x => x.Id == id).Result;
            if (mineralExistente != null)
            {
                mineralExistente.Tipo = mineral.Tipo;
                mineralExistente.Caracteristica = mineral.Caracteristica;
                mineralExistente.PrecoPorKg = mineral.PrecoPorKg;
                await baseDbContext.SaveChangesAsync();
                return Ok("Registro atualizado com sucesso.");
            }
            return NotFound("Mineral não encontrado.");
        }

        [HttpDelete]
        [Route("/Mineral/Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var mineralExistente = baseDbContext.Minerais.FirstOrDefaultAsync(x => x.Id == id).Result;
            if (mineralExistente != null)
            {
                baseDbContext.Remove(mineralExistente);
                await baseDbContext.SaveChangesAsync();
                return Ok("Registro excluído com sucesso.");
            }
            return NotFound("Mineral não encontrado.");
        }

        #endregion
    }
}
