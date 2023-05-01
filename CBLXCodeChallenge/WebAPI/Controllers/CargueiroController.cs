using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CargueiroController : Controller
    {
        #region Attributes

        private readonly BaseDbContext baseDbContext;

        #endregion

        #region Constructor

        public CargueiroController(BaseDbContext baseDbContext)
        {
            this.baseDbContext = baseDbContext;
        }

        #endregion

        #region Behaviors

        [HttpGet]
        [Route("/Cargueiro/Select")]
        public async Task<IActionResult> SelectAll()
        {
            var cargueiros = await baseDbContext.Cargueiros.ToListAsync();
            return Ok(cargueiros);
        }

        [HttpGet]
        [Route("/Cargueiro/SelectById/{id}")]
        [ActionName("SelectCargueiro")]
        public async Task<IActionResult> SelectById([FromRoute] int id)
        {
            var cargueiro = await baseDbContext.Cargueiros.FirstOrDefaultAsync(x => x.Id == id);
            if (cargueiro == null)
                return Ok(cargueiro);
            return NotFound("Cargueiro não encontrado.");
        }

        [HttpPost]
        [Route("/Cargueiro/Insert")]
        public async Task<IActionResult> Insert([FromBody] Cargueiro cargueiro)
        {
            await baseDbContext.Cargueiros.AddAsync(cargueiro);
            await baseDbContext.SaveChangesAsync();
            return Ok("Registro criado com sucesso");
        }

        [HttpPut]
        [Route("/Cargueiro/Update/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Cargueiro cargueiro)
        {
            var cargueiroExistente = baseDbContext.Cargueiros.FirstOrDefaultAsync(x => x.Id == id).Result;
            if (cargueiroExistente != null)
            {
                cargueiroExistente.Quantidade = cargueiro.Quantidade;
                cargueiroExistente.Classe = cargueiro.Classe;
                cargueiroExistente.CapacidadeEmToneladas = cargueiro.CapacidadeEmToneladas;
                await baseDbContext.SaveChangesAsync();
                return Ok("Registro atualizado com sucesso");
            }
            return NotFound("Cargueiro não encontrado.");
        }

        [HttpDelete]
        [Route("/Cargueiro/Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var cargueiroExistente = baseDbContext.Cargueiros.FirstOrDefaultAsync(x => x.Id == id).Result;
            if (cargueiroExistente != null)
            {
                baseDbContext.Remove(cargueiroExistente);
                await baseDbContext.SaveChangesAsync();
                return Ok("Registro excluído com sucesso");
            }
            return NotFound("Cargueiro não encontrado.");
        }

        #endregion
    }
}
