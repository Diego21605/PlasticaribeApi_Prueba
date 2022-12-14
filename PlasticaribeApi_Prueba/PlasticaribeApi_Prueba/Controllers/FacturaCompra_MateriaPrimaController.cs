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
    public class FacturaCompra_MateriaPrimaController : ControllerBase
    {
        private readonly dataContext _context;

        public FacturaCompra_MateriaPrimaController(dataContext context)
        {
            _context = context;
        }

        // GET: api/FacturaCompra_MateriaPrima
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FacturaCompra_MateriaPrima>>> GetFacturasCompras_MateriaPrimas()
        {
          if (_context.FacturasCompras_MateriaPrimas == null)
          {
              return NotFound();
          }
            return await _context.FacturasCompras_MateriaPrimas.ToListAsync();
        }

        // GET: api/FacturaCompra_MateriaPrima/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FacturaCompra_MateriaPrima>> GetFacturaCompra_MateriaPrima(long Facco_Id, long MatPri_Id)
        {
            if (_context.FacturasCompras_MateriaPrimas == null)
            {
                return NotFound();
            }
            var facturaCompra_MateriaPrima = await _context.FacturasCompras_MateriaPrimas.FindAsync(Facco_Id, MatPri_Id);

            if (facturaCompra_MateriaPrima == null)
            {
                return NotFound();
            }

            return facturaCompra_MateriaPrima;
        }

        //Consulta por el Id de la factura
        [HttpGet("facturaCompra/{Facco_Id}")]
        public ActionResult FacturaId(long Facco_Id)
        {
            var factCompra = _context.FacturasCompras_MateriaPrimas.Where(f => f.Facco_Id == Facco_Id).ToList();

            return Ok(factCompra);
        }

        //Consulta por el id de la materia prima
        [HttpGet("MP/{MatPri_Id}")]
        public ActionResult materiaPrimaId(long MatPri_Id)
        {
            var factCompra = _context.FacturasCompras_MateriaPrimas.Where(f => f.MatPri_Id == MatPri_Id).ToList();

            return Ok(factCompra);
        }

        [HttpGet("MPFechaActual/{MatPri_Id}")]
        public ActionResult materiaPrimaIdFechaActual(long MatPri_Id, DateTime Facco_FechaFactura)
        {
#pragma warning disable CS8602 // Desreferencia de una referencia posiblemente NULL.
            var factCompra = _context.FacturasCompras_MateriaPrimas
                .Where(f => f.MatPri_Id == MatPri_Id && f.Facco.Facco_FechaFactura == Facco_FechaFactura).ToList();

            return Ok(factCompra);
        }

        [HttpGet("consultaMovimiento0/{fecha}")]
        public ActionResult Get (DateTime Fecha)
        {
            var con = _context.FacturasCompras_MateriaPrimas
                .Where(fac => fac.Facco.Facco_FechaFactura == Fecha)
                .Include(fac => fac.Facco)
                .Select(fac => new
                {
                    fac.Facco.Facco_Id,
                    fac.Facco.Facco_Codigo,
                    fac.Facco.Facco_FechaFactura,
                    fac.Facco.Usua_Id,
                    fac.Facco.Usua.Usua_Nombre,
                    fac.MatPri_Id,
                    fac.MatPri.MatPri_Nombre,
                    fac.FaccoMatPri_Cantidad
                })
                .ToList();
            return Ok(con);
        }

        [HttpGet("consultaMovimiento1/{MatPri}/{fecha}")]
        public ActionResult Get(int MatPri, DateTime Fecha)
        {
            var con = _context.FacturasCompras_MateriaPrimas
                .Where(fac => fac.Facco.Facco_FechaFactura == Fecha
                       && fac.MatPri_Id == MatPri)
                .Include(fac => fac.Facco)
                .Select(fac => new
                {
                    fac.Facco.Facco_Id,
                    fac.Facco.Facco_Codigo,
                    fac.Facco.Facco_FechaFactura,
                    fac.Facco.Usua_Id,
                    fac.Facco.Usua.Usua_Nombre,
                    fac.MatPri_Id,
                    fac.MatPri.MatPri_Nombre,
                    fac.FaccoMatPri_Cantidad
                })
                .ToList();
            return Ok(con);
        }

        [HttpGet("consultaMovimientos2/{ot}")]
        public ActionResult GetOT(string ot)
        {
            var con = _context.FacturasCompras_MateriaPrimas
                .Where(fac => fac.Facco.Facco_Codigo == ot)
                .Include(fac => fac.Facco)
                .Select(fac => new
                {
                    fac.Facco.Facco_Id,
                    fac.Facco.Facco_Codigo,
                    fac.Facco.Facco_FechaFactura,
                    fac.Facco.Usua_Id,
                    fac.Facco.Usua.Usua_Nombre,
                    fac.MatPri_Id,
                    fac.MatPri.MatPri_Nombre,
                    fac.FaccoMatPri_Cantidad
                })
                .ToList();
            return Ok(con);
        }

        [HttpGet("consultaMovimientos3/{FechaInicial}/{FechaFinal}")]
        public ActionResult Get(DateTime FechaInicial, DateTime FechaFinal)
        {
            var con = _context.FacturasCompras_MateriaPrimas
                .Where(fac => fac.Facco.Facco_FechaFactura >= FechaInicial
                       && fac.Facco.Facco_FechaFactura <= FechaFinal)
                .Include(fac => fac.Facco)
                .Select(fac => new
                {
                    fac.Facco.Facco_Id,
                    fac.Facco.Facco_Codigo,
                    fac.Facco.Facco_FechaFactura,
                    fac.Facco.Usua_Id,
                    fac.Facco.Usua.Usua_Nombre,
                    fac.MatPri_Id,
                    fac.MatPri.MatPri_Nombre,
                    fac.FaccoMatPri_Cantidad
                })
                .ToList();
            return Ok(con);
        }

        [HttpGet("consultaMovimientos4/{FechaInicial}/{MatPri}")]
        public ActionResult Get(DateTime FechaInicial, int MatPri)
        {
            var con = _context.FacturasCompras_MateriaPrimas
                .Where(fac => fac.Facco.Facco_FechaFactura == FechaInicial
                       && fac.MatPri_Id == MatPri)
                .Include(fac => fac.Facco)
                .Select(fac => new
                {
                    fac.Facco.Facco_Id,
                    fac.Facco.Facco_Codigo,
                    fac.Facco.Facco_FechaFactura,
                    fac.Facco.Usua_Id,
                    fac.Facco.Usua.Usua_Nombre,
                    fac.MatPri_Id,
                    fac.MatPri.MatPri_Nombre,
                    fac.FaccoMatPri_Cantidad
                })
                .ToList();
            return Ok(con);
        }

        [HttpGet("consultaMovimientos5/{Ot}/{FechaInicial}/{FechaFinal}")]
        public ActionResult Get(string Ot, DateTime FechaInicial, DateTime FechaFinal)
        {
            var con = _context.FacturasCompras_MateriaPrimas
                .Where(fac => fac.Facco.Facco_Codigo == Ot
                       && fac.Facco.Facco_FechaFactura >= FechaInicial
                       && fac.Facco.Facco_FechaFactura <= FechaFinal)
                .Include(fac => fac.Facco)
                .Select(fac => new
                {
                    fac.Facco.Facco_Id,
                    fac.Facco.Facco_Codigo,
                    fac.Facco.Facco_FechaFactura,
                    fac.Facco.Usua_Id,
                    fac.Facco.Usua.Usua_Nombre,
                    fac.MatPri_Id,
                    fac.MatPri.MatPri_Nombre,
                    fac.FaccoMatPri_Cantidad
                })
                .ToList();
            return Ok(con);
        }

        [HttpGet("consultaMovimientos6/{FechaInicial}/{FechaFinal}/{MatPri}")]
        public ActionResult Get8(DateTime FechaInicial, DateTime FechaFinal, int MatPri)
        {
            var con = _context.FacturasCompras_MateriaPrimas
                .Where(fac => fac.Facco.Facco_FechaFactura >= FechaInicial
                       && fac.Facco.Facco_FechaFactura <= FechaFinal
                       && fac.MatPri_Id == MatPri)
                .Include(fac => fac.Facco)
                .Select(fac => new
                {
                    fac.Facco.Facco_Id,
                    fac.Facco.Facco_Codigo,
                    fac.Facco.Facco_FechaFactura,
                    fac.Facco.Usua_Id,
                    fac.Facco.Usua.Usua_Nombre,
                    fac.MatPri_Id,
                    fac.MatPri.MatPri_Nombre,
                    fac.FaccoMatPri_Cantidad
                })
                .ToList();
            return Ok(con);
        }

        [HttpGet("pdfMovimientos/{codigo}")]
        public ActionResult Get (string codigo)
        {
            var con = _context.FacturasCompras_MateriaPrimas
                .Where(fac => fac.Facco.Facco_Codigo == codigo)
                .Include(fac => fac.Facco)
                .Select(fac => new
                {
                    fac.Facco.Facco_Id,
                    fac.Facco.Facco_FechaFactura,
                    fac.Facco.Facco_Observacion,
                    fac.Facco.Facco_ValorTotal,
                    fac.Facco.Prov_Id,
                    fac.Facco.Prov.TipoIdentificacion_Id,
                    fac.Facco.Prov.Prov_Nombre,
                    fac.Facco.Prov.TpProv.TpProv_Nombre,
                    fac.Facco.Prov.Prov_Telefono,
                    fac.Facco.Prov.Prov_Email,
                    fac.Facco.Prov.Prov_Ciudad,
                    fac.Facco.Usua_Id,
                    fac.Facco.Usua.Usua_Nombre,
                    fac.MatPri_Id,
                    fac.MatPri.MatPri_Nombre,
                    fac.UndMed_Id,
                    fac.FaccoMatPri_Cantidad,
                    fac.FaccoMatPri_ValorUnitario
                })
                .ToList();
            return Ok(con);
        }

        // PUT: api/FacturaCompra_MateriaPrima/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFacturaCompra_MateriaPrima(long id, FacturaCompra_MateriaPrima facturaCompra_MateriaPrima)
        {
            if (id != facturaCompra_MateriaPrima.Facco_Id)
            {
                return BadRequest();
            }

            _context.Entry(facturaCompra_MateriaPrima).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacturaCompra_MateriaPrimaExists(id))
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

        // POST: api/FacturaCompra_MateriaPrima
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FacturaCompra_MateriaPrima>> PostFacturaCompra_MateriaPrima(FacturaCompra_MateriaPrima facturaCompra_MateriaPrima)
        {
          if (_context.FacturasCompras_MateriaPrimas == null)
          {
              return Problem("Entity set 'dataContext.FacturasCompras_MateriaPrimas'  is null.");
          }
            _context.FacturasCompras_MateriaPrimas.Add(facturaCompra_MateriaPrima);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FacturaCompra_MateriaPrimaExists(facturaCompra_MateriaPrima.Facco_Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFacturaCompra_MateriaPrima", new { id = facturaCompra_MateriaPrima.Facco_Id }, facturaCompra_MateriaPrima);
        }

        // DELETE: api/FacturaCompra_MateriaPrima/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFacturaCompra_MateriaPrima(long id)
        {
            if (_context.FacturasCompras_MateriaPrimas == null)
            {
                return NotFound();
            }
            var facturaCompra_MateriaPrima = await _context.FacturasCompras_MateriaPrimas.FindAsync(id);
            if (facturaCompra_MateriaPrima == null)
            {
                return NotFound();
            }

            _context.FacturasCompras_MateriaPrimas.Remove(facturaCompra_MateriaPrima);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FacturaCompra_MateriaPrimaExists(long id)
        {
            return (_context.FacturasCompras_MateriaPrimas?.Any(e => e.Facco_Id == id)).GetValueOrDefault();
        }
    }
}
