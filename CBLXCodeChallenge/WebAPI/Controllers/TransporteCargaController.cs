using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransporteCargaController : Controller
    {
        #region Attributes

        private readonly BaseDbContext baseDbContext;

        #endregion

        #region Constructor

        public TransporteCargaController(BaseDbContext baseDbContext)
        {
            this.baseDbContext = baseDbContext;
        }

        #endregion

        #region Behaviors

        [HttpGet]
        [Route("/TransporteCarga/Select")]
        public async Task<IActionResult> SelectAll()
        {
            var minerais = await baseDbContext.Transportes.ToListAsync();
            return Ok(minerais);
        }

        [HttpGet]
        [Route("/TransporteCarga/SelectById/{id}")]
        [ActionName("SelectTransporteCarga")]
        public async Task<IActionResult> SelectById([FromRoute] int id)
        {
            var carga = await baseDbContext.Transportes.FirstOrDefaultAsync(x => x.Id == id);
            if (carga != null)
                return Ok(carga);
            return NotFound("Registro não encontrado.");
        }

        [HttpPost]
        [Route("/TransporteCarga/Insert")]
        public async Task<IActionResult> Insert([FromBody] TransporteCarga carga)
        {
            await baseDbContext.Transportes.AddAsync(carga);
            await baseDbContext.SaveChangesAsync();
            return Ok("Registro criado com sucesso.");
        }

        [HttpPut]
        [Route("/TransporteCarga/Update/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] TransporteCarga carga)
        {
            var cargaExistente = baseDbContext.Transportes.FirstOrDefaultAsync(x => x.Id == id).Result;
            if (cargaExistente != null)
            {
                cargaExistente.CargueiroId = carga.CargueiroId;
                cargaExistente.Cargueiro = baseDbContext.Cargueiros.FirstOrDefaultAsync(x => x.Id == carga.CargueiroId).Result;
                cargaExistente.MineralId = carga.MineralId;
                cargaExistente.Mineral = baseDbContext.Minerais.FirstOrDefaultAsync(x => x.Id == carga.MineralId).Result;
                cargaExistente.Quantidade = carga.Quantidade;
                cargaExistente.ValorTotal = carga.ValorTotal;
                await baseDbContext.SaveChangesAsync();
                return Ok("Registro atualizado com sucesso.");
            }
            return NotFound("Registro não encontrado.");
        }

        [HttpDelete]
        [Route("/TransporteCarga/Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var cargaExistente = baseDbContext.Transportes.FirstOrDefaultAsync(x => x.Id == id).Result;
            if (cargaExistente != null)
            {
                baseDbContext.Remove(cargaExistente);
                await baseDbContext.SaveChangesAsync();
                return Ok("Registro excluído com sucesso.");
            }
            return NotFound("Registro não encontrado.");
        }

        #endregion
    }
}
