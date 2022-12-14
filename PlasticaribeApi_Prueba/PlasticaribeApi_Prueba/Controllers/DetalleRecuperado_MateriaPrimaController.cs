using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlasticaribeApi_Prueba.Data;
using PlasticaribeApi_Prueba.Models;

namespace PlasticaribeApi_Prueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleRecuperado_MateriaPrimaController : ControllerBase
    {
        private readonly dataContext _context;

        public DetalleRecuperado_MateriaPrimaController(dataContext context)
        {
            _context = context;
        }

        // GET: api/DetalleRecuperado_MateriaPrima
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalleRecuperado_MateriaPrima>>> GetDetallesRecuperados_MateriasPrimas()
        {
          if (_context.DetallesRecuperados_MateriasPrimas == null)
          {
              return NotFound();
          }
            return await _context.DetallesRecuperados_MateriasPrimas.ToListAsync();
        }

        // GET: api/DetalleRecuperado_MateriaPrima/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetalleRecuperado_MateriaPrima>> GetDetalleRecuperado_MateriaPrima(long RecMp_Id, long MatPri_Id)
        {
          if (_context.DetallesRecuperados_MateriasPrimas == null)
          {
              return NotFound();
          }
            var detalleRecuperado_MateriaPrima = await _context.DetallesRecuperados_MateriasPrimas.FindAsync(RecMp_Id, MatPri_Id);

            if (detalleRecuperado_MateriaPrima == null)
            {
                return NotFound();
            }

            return detalleRecuperado_MateriaPrima;
        }

        [HttpGet("materiaPrima/{MatPri_Id}")]
        public ActionResult<DetalleRecuperado_MateriaPrima> GetIdMateriaPrima(long MatPri_Id)
        {
            var detalleRecuperado_MateriaPrima = _context.DetallesRecuperados_MateriasPrimas.Where(dtR => dtR.MatPri_Id == MatPri_Id).ToList();

            if (detalleRecuperado_MateriaPrima == null)
            {
                return  BadRequest();
            }
            else
            {
                return Ok(detalleRecuperado_MateriaPrima);
            }

        }

        [HttpGet("materiaPrimaFechaActual/{MatPri_Id}")]
        public ActionResult<DetalleRecuperado_MateriaPrima> GetIdMateriaPrimaFechaActual(long MatPri_Id, DateTime RecMp_FechaIngreso)
        {
#pragma warning disable CS8602 // Desreferencia de una referencia posiblemente NULL.
            var detalleRecuperado_MateriaPrima = _context.DetallesRecuperados_MateriasPrimas
                .Where(dtR => dtR.MatPri_Id == MatPri_Id && dtR.RecMp.RecMp_FechaIngreso == RecMp_FechaIngreso).ToList();

            if (detalleRecuperado_MateriaPrima == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(detalleRecuperado_MateriaPrima);
            }

        }

        [HttpGet("recuperado/{RecMp_Id}")]
        public ActionResult<DetalleRecuperado_MateriaPrima> GetRecuperado(long RecMp_Id)
        {
            var detalleRecuperado_MateriaPrima = _context.DetallesRecuperados_MateriasPrimas.Where(dtR => dtR.RecMp_Id == RecMp_Id).ToList();

            if (detalleRecuperado_MateriaPrima == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(detalleRecuperado_MateriaPrima);
            }

        }

        [HttpGet("consultaMovimientos0/{FechaInicial}")]
        public ActionResult Get (DateTime FechaInicial)
        {
            var con = _context.DetallesRecuperados_MateriasPrimas
                .Where(rec => rec.RecMp.RecMp_FechaIngreso == FechaInicial)
                .Include(rec => rec.RecMp)
                .Select(rec => new
                {
                    rec.RecMp_Id,
                    rec.RecMp.RecMp_FechaIngreso,
                    rec.RecMp.Usua_Id,
                    rec.RecMp.Usua.Usua_Nombre,
                    rec.MatPri_Id,
                    rec.MatPri.MatPri_Nombre,
                    rec.RecMatPri_Cantidad
                })
                .ToList();
            return Ok(con);
        }

        [HttpGet("consultaMovimiento1/{MatPri}/{fecha}")]
        public ActionResult Get(int MatPri, DateTime Fecha)
        {
            var con = _context.DetallesRecuperados_MateriasPrimas
                .Where(rec => rec.RecMp.RecMp_FechaIngreso == Fecha
                       && rec.MatPri_Id == MatPri)
                .Include(rec => rec.RecMp)
                .Select(rec => new
                {
                    rec.RecMp_Id,
                    rec.RecMp.RecMp_FechaIngreso,
                    rec.RecMp.Usua_Id,
                    rec.RecMp.Usua.Usua_Nombre,
                    rec.MatPri_Id,
                    rec.MatPri.MatPri_Nombre,
                    rec.RecMatPri_Cantidad
                })
                .ToList();
            return Ok(con);
        }

        [HttpGet("consultaMovimientos2/{ot}")]
        public ActionResult GetOT(int ot)
        {
            var con = _context.DetallesRecuperados_MateriasPrimas
                .Where(rec => rec.RecMp_Id == ot)
                .Include(rec => rec.RecMp)
                .Select(rec => new
                {
                    rec.RecMp_Id,
                    rec.RecMp.RecMp_FechaIngreso,
                    rec.RecMp.Usua_Id,
                    rec.RecMp.Usua.Usua_Nombre,
                    rec.MatPri_Id,
                    rec.MatPri.MatPri_Nombre,
                    rec.RecMatPri_Cantidad
                })
                .ToList();
            return Ok(con);
        }

        [HttpGet("consultaMovimientos3/{FechaInicial}/{FechaFinal}")]
        public ActionResult Get(DateTime FechaInicial, DateTime FechaFinal)
        {
            var con = _context.DetallesRecuperados_MateriasPrimas
                .Where(rec => rec.RecMp.RecMp_FechaIngreso >= FechaInicial
                       && rec.RecMp.RecMp_FechaIngreso <= FechaFinal)
                .Include(rec => rec.RecMp)
                .Select(rec => new
                {
                    rec.RecMp_Id,
                    rec.RecMp.RecMp_FechaIngreso,
                    rec.RecMp.Usua_Id,
                    rec.RecMp.Usua.Usua_Nombre,
                    rec.MatPri_Id,
                    rec.MatPri.MatPri_Nombre,
                    rec.RecMatPri_Cantidad
                })
                .ToList();
            return Ok(con);
        }

        [HttpGet("consultaMovimientos4/{FechaInicial}/{MatPri}")]
        public ActionResult Get(DateTime FechaInicial, int MatPri)
        {
            var con = _context.DetallesRecuperados_MateriasPrimas
                .Where(rec => rec.RecMp.RecMp_FechaIngreso == FechaInicial
                       && rec.MatPri_Id == MatPri)
                .Include(rec => rec.RecMp)
                .Select(rec => new
                {
                    rec.RecMp_Id,
                    rec.RecMp.RecMp_FechaIngreso,
                    rec.RecMp.Usua_Id,
                    rec.RecMp.Usua.Usua_Nombre,
                    rec.MatPri_Id,
                    rec.MatPri.MatPri_Nombre,
                    rec.RecMatPri_Cantidad
                })
                .ToList();
            return Ok(con);
        }

        [HttpGet("consultaMovimientos5/{Ot}/{FechaInicial}/{FechaFinal}")]
        public ActionResult Get(long Ot, DateTime FechaInicial, DateTime FechaFinal)
        {
            var con = _context.DetallesRecuperados_MateriasPrimas
                .Where(rec => rec.RecMp_Id == Ot
                       && rec.RecMp.RecMp_FechaIngreso >= FechaInicial
                       && rec.RecMp.RecMp_FechaIngreso <= FechaFinal)
                .Include(rec => rec.RecMp)
                .Select(rec => new
                {
                    rec.RecMp_Id,
                    rec.RecMp.RecMp_FechaIngreso,
                    rec.RecMp.Usua_Id,
                    rec.RecMp.Usua.Usua_Nombre,
                    rec.MatPri_Id,
                    rec.MatPri.MatPri_Nombre,
                    rec.RecMatPri_Cantidad
                })
                .ToList();
            return Ok(con);
        }

        [HttpGet("consultaMovimientos6/{FechaInicial}/{FechaFinal}/{MatPri}")]
        public ActionResult Get9(DateTime FechaInicial, DateTime FechaFinal, int MatPri)
        {
            var con = _context.DetallesRecuperados_MateriasPrimas
                .Where(rec => rec.RecMp.RecMp_FechaIngreso >= FechaInicial
                        && rec.RecMp.RecMp_FechaIngreso <= FechaFinal
                        && rec.MatPri_Id == MatPri)
                .Include(rec => rec.RecMp)
                .Select(rec => new
                {
                    rec.RecMp_Id,
                    rec.RecMp.RecMp_FechaIngreso,
                    rec.RecMp.Usua_Id,
                    rec.RecMp.Usua.Usua_Nombre,
                    rec.MatPri_Id,
                    rec.MatPri.MatPri_Nombre,
                    rec.RecMatPri_Cantidad
                }).ToList();
            return Ok(con);
        }

        [HttpGet("pdfMovimientos/{id}")]
        public ActionResult Get(int id)
        {
            var con = _context.DetallesRecuperados_MateriasPrimas
                .Where(rec => rec.RecMp_Id == id)
                .Include(rec => rec.RecMp)
                .Select(rec => new
                {
                    rec.RecMp.RecMp_Id,
                    rec.RecMp.RecMp_FechaIngreso,
                    rec.RecMp.RecMp_Observacion,
                    rec.RecMp.Usua_Id,
                    rec.RecMp.Usua.Usua_Nombre,
                    rec.MatPri_Id,
                    rec.MatPri.MatPri_Nombre,
                    rec.UndMed_Id,
                    rec.RecMatPri_Cantidad,
                    rec.RecMp.Proc_Id,
                    rec.RecMp.Proceso.Proceso_Nombre
                })
                .ToList();
            return Ok(con);
        }

        // PUT: api/DetalleRecuperado_MateriaPrima/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalleRecuperado_MateriaPrima(long id, DetalleRecuperado_MateriaPrima detalleRecuperado_MateriaPrima)
        {
            if (id != detalleRecuperado_MateriaPrima.RecMp_Id)
            {
                return BadRequest();
            }

            _context.Entry(detalleRecuperado_MateriaPrima).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetalleRecuperado_MateriaPrimaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/DetalleRecuperado_MateriaPrima
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DetalleRecuperado_MateriaPrima>> PostDetalleRecuperado_MateriaPrima(DetalleRecuperado_MateriaPrima detalleRecuperado_MateriaPrima)
        {
          if (_context.DetallesRecuperados_MateriasPrimas == null)
          {
              return Problem("Entity set 'dataContext.DetallesRecuperados_MateriasPrimas'  is null.");
          }
            _context.DetallesRecuperados_MateriasPrimas.Add(detalleRecuperado_MateriaPrima);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DetalleRecuperado_MateriaPrimaExists(detalleRecuperado_MateriaPrima.RecMp_Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDetalleRecuperado_MateriaPrima", new { id = detalleRecuperado_MateriaPrima.RecMp_Id }, detalleRecuperado_MateriaPrima);
        }

        // DELETE: api/DetalleRecuperado_MateriaPrima/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetalleRecuperado_MateriaPrima(long id)
        {
            if (_context.DetallesRecuperados_MateriasPrimas == null)
            {
                return NotFound();
            }
            var detalleRecuperado_MateriaPrima = await _context.DetallesRecuperados_MateriasPrimas.FindAsync(id);
            if (detalleRecuperado_MateriaPrima == null)
            {
                return NotFound();
            }

            _context.DetallesRecuperados_MateriasPrimas.Remove(detalleRecuperado_MateriaPrima);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetalleRecuperado_MateriaPrimaExists(long id)
        {
            return (_context.DetallesRecuperados_MateriasPrimas?.Any(e => e.RecMp_Id == id)).GetValueOrDefault();
        }
    }
}
