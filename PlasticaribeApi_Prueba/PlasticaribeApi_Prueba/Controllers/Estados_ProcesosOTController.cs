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
    public class Estados_ProcesosOTController : ControllerBase
    {
        private readonly dataContext _context;

        public Estados_ProcesosOTController(dataContext context)
        {
            _context = context;
        }

        // GET: api/Estados_ProcesosOT
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estados_ProcesosOT>>> GetEstados_ProcesosOT()
        {
          if (_context.Estados_ProcesosOT == null)
          {
              return NotFound();
          }
            return await _context.Estados_ProcesosOT.ToListAsync();
        }

        // GET: api/Estados_ProcesosOT/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Estados_ProcesosOT>> GetEstados_ProcesosOT(long id)
        {
          if (_context.Estados_ProcesosOT == null)
          {
              return NotFound();
          }
            var estados_ProcesosOT = await _context.Estados_ProcesosOT.FindAsync(id);

            if (estados_ProcesosOT == null)
            {
                return NotFound();
            }

            return estados_ProcesosOT;
        }

        [HttpGet("consultaGeneral")]
        public ActionResult Get()
        {
#pragma warning disable CS8602 // Desreferencia de una referencia posiblemente NULL.
            var ot = _context.Estados_ProcesosOT
                .Include(estOT => estOT.FallaTecnica)
                .Include(estOT => estOT.Estado_OT)
                .Include(estOt => estOt.UnidadMedida)
                .Select(estOt => new {
                    estOt.EstProcOT_OrdenTrabajo,
                    estOt.EstProcOT_ExtrusionKg,
                    estOt.EstProcOT_ImpresionKg,
                    estOt.EstProcOT_RotograbadoKg,
                    estOt.EstProcOT_LaminadoKg,
                    estOt.EstProcOT_DobladoKg,
                    estOt.EstProcOT_CorteKg,
                    estOt.EstProcOT_EmpaqueKg,
                    estOt.EstProcOT_SelladoKg,
                    estOt.EstProcOT_SelladoUnd,
                    estOt.EstProcOT_WiketiadoKg,
                    estOt.EstProcOT_WiketiadoUnd,
                    estOt.Falla_Id,
                    estOt.FallaTecnica.Falla_Nombre,
                    estOt.Estado_Id,
                    estOt.Estado_OT.Estado_Nombre,
                    estOt.EstProcOT_Observacion,
                    estOt.EstProcOT_FechaCreacion,
                    estOt.EstProcOT_CantidadPedida,
                    estOt.UndMed_Id,
                    estOt.UnidadMedida.UndMed_Nombre
                });
#pragma warning restore CS8602 // Desreferencia de una referencia posiblemente NULL.
            return Ok(ot);
        }

        [HttpGet("consultaPorOT/{EstProcOT_OrdenTrabajo}")]
        public ActionResult GetPorOT(long EstProcOT_OrdenTrabajo)
        {
#pragma warning disable CS8602 // Desreferencia de una referencia posiblemente NULL.
            var ot = _context.Estados_ProcesosOT.Where(epOT => epOT.EstProcOT_OrdenTrabajo == EstProcOT_OrdenTrabajo)
                .Include(estOT => estOT.FallaTecnica)
                .Include(estOT => estOT.Estado_OT)
                .Include(estOt => estOt.UnidadMedida)
                .Select(estOt => new {
                    estOt.EstProcOT_OrdenTrabajo,
                    estOt.EstProcOT_ExtrusionKg,
                    estOt.EstProcOT_ImpresionKg,
                    estOt.EstProcOT_RotograbadoKg,
                    estOt.EstProcOT_LaminadoKg,
                    estOt.EstProcOT_DobladoKg,
                    estOt.EstProcOT_CorteKg,
                    estOt.EstProcOT_EmpaqueKg,
                    estOt.EstProcOT_SelladoKg,
                    estOt.EstProcOT_SelladoUnd,
                    estOt.EstProcOT_WiketiadoKg,
                    estOt.EstProcOT_WiketiadoUnd,
                    estOt.Falla_Id,
                    estOt.FallaTecnica.Falla_Nombre,
                    estOt.Estado_Id,
                    estOt.Estado_OT.Estado_Nombre,
                    estOt.EstProcOT_Observacion,
                    estOt.EstProcOT_FechaCreacion,
                    estOt.EstProcOT_CantidadPedida,
                    estOt.UndMed_Id,
                    estOt.UnidadMedida.UndMed_Nombre
                })
                .ToList();
#pragma warning restore CS8602 // Desreferencia de una referencia posiblemente NULL.
            return Ok(ot);
        }

        [HttpGet("consultaPorFallas/{Falla_Id}")]
        public ActionResult GetPorFallas(int Falla_Id)
        {
#pragma warning disable CS8602 // Desreferencia de una referencia posiblemente NULL.
            var ot = _context.Estados_ProcesosOT.Where(epOT => epOT.Falla_Id == Falla_Id)
                .Include(estOT => estOT.FallaTecnica)
                .Include(estOT => estOT.Estado_OT)
                .Include(estOt => estOt.UnidadMedida)
                .Select(estOt => new {
                    estOt.EstProcOT_OrdenTrabajo,
                    estOt.EstProcOT_ExtrusionKg,
                    estOt.EstProcOT_ImpresionKg,
                    estOt.EstProcOT_RotograbadoKg,
                    estOt.EstProcOT_LaminadoKg,
                    estOt.EstProcOT_DobladoKg,
                    estOt.EstProcOT_CorteKg,
                    estOt.EstProcOT_EmpaqueKg,
                    estOt.EstProcOT_SelladoKg,
                    estOt.EstProcOT_SelladoUnd,
                    estOt.EstProcOT_WiketiadoKg,
                    estOt.EstProcOT_WiketiadoUnd,
                    estOt.Falla_Id,
                    estOt.FallaTecnica.Falla_Nombre,
                    estOt.Estado_Id,
                    estOt.Estado_OT.Estado_Nombre,
                    estOt.EstProcOT_Observacion,
                    estOt.EstProcOT_FechaCreacion,
                    estOt.EstProcOT_CantidadPedida,
                    estOt.UndMed_Id,
                    estOt.UnidadMedida.UndMed_Nombre
                })
                .ToList();
#pragma warning restore CS8602 // Desreferencia de una referencia posiblemente NULL.
            return Ok(ot);
        }

        [HttpGet("consultaPorFecha/{EstProcOT_FechaCreacion}")]
        public ActionResult GetPorFecha(DateTime EstProcOT_FechaCreacion)
        {
#pragma warning disable CS8602 // Desreferencia de una referencia posiblemente NULL.
            var ot = _context.Estados_ProcesosOT.Where(epOT => epOT.EstProcOT_FechaCreacion == EstProcOT_FechaCreacion)
                .Include(estOT => estOT.FallaTecnica)
                .Include(estOT => estOT.Estado_OT)
                .Include(estOt => estOt.UnidadMedida)
                .Select(estOt => new {
                    estOt.EstProcOT_OrdenTrabajo,
                    estOt.EstProcOT_ExtrusionKg,
                    estOt.EstProcOT_ImpresionKg,
                    estOt.EstProcOT_RotograbadoKg,
                    estOt.EstProcOT_LaminadoKg,
                    estOt.EstProcOT_DobladoKg,
                    estOt.EstProcOT_CorteKg,
                    estOt.EstProcOT_EmpaqueKg,
                    estOt.EstProcOT_SelladoKg,
                    estOt.EstProcOT_SelladoUnd,
                    estOt.EstProcOT_WiketiadoKg,
                    estOt.EstProcOT_WiketiadoUnd,
                    estOt.Falla_Id,
                    estOt.FallaTecnica.Falla_Nombre,
                    estOt.Estado_Id,
                    estOt.Estado_OT.Estado_Nombre,
                    estOt.EstProcOT_Observacion,
                    estOt.EstProcOT_FechaCreacion,
                    estOt.EstProcOT_CantidadPedida,
                    estOt.UndMed_Id,
                    estOt.UnidadMedida.UndMed_Nombre
                })
                .ToList();
#pragma warning restore CS8602 // Desreferencia de una referencia posiblemente NULL.
            return Ok(ot);
        }

        [HttpGet("consultaPorFechas/")]
        public ActionResult GetPorFechas(DateTime EstProcOT_FechaCreacion1, DateTime EstProcOT_FechaCreacion2)
        {
#pragma warning disable CS8602 // Desreferencia de una referencia posiblemente NULL.
            var ot = _context.Estados_ProcesosOT.Where(epOT => epOT.EstProcOT_FechaCreacion >= EstProcOT_FechaCreacion1 && epOT.EstProcOT_FechaCreacion <= EstProcOT_FechaCreacion2)
                .Include(estOT => estOT.FallaTecnica)
                .Include(estOT => estOT.Estado_OT)
                .Include(estOt => estOt.UnidadMedida)
                .Select(estOt => new {
                    estOt.EstProcOT_OrdenTrabajo,
                    estOt.EstProcOT_ExtrusionKg,
                    estOt.EstProcOT_ImpresionKg,
                    estOt.EstProcOT_RotograbadoKg,
                    estOt.EstProcOT_LaminadoKg,
                    estOt.EstProcOT_DobladoKg,
                    estOt.EstProcOT_CorteKg,
                    estOt.EstProcOT_EmpaqueKg,
                    estOt.EstProcOT_SelladoKg,
                    estOt.EstProcOT_SelladoUnd,
                    estOt.EstProcOT_WiketiadoKg,
                    estOt.EstProcOT_WiketiadoUnd,
                    estOt.Falla_Id,
                    estOt.FallaTecnica.Falla_Nombre,
                    estOt.Estado_Id,
                    estOt.Estado_OT.Estado_Nombre,
                    estOt.EstProcOT_Observacion,
                    estOt.EstProcOT_FechaCreacion,
                    estOt.EstProcOT_CantidadPedida,
                    estOt.UndMed_Id,
                    estOt.UnidadMedida.UndMed_Nombre
                })
                .ToList();
#pragma warning restore CS8602 // Desreferencia de una referencia posiblemente NULL.
            return Ok(ot);
        }

        [HttpGet("consultaPorOtFalla/{EstProcOT_OrdenTrabajo}/{Falla_Id}")]
        public ActionResult GetPorOtFallas(long EstProcOT_OrdenTrabajo, int Falla_Id)
        {
#pragma warning disable CS8602 // Desreferencia de una referencia posiblemente NULL.
            var ot = _context.Estados_ProcesosOT.Where(epOT => epOT.EstProcOT_OrdenTrabajo == EstProcOT_OrdenTrabajo && epOT.Falla_Id == Falla_Id)
                .Include(estOT => estOT.FallaTecnica)
                .Include(estOT => estOT.Estado_OT)
                .Include(estOt => estOt.UnidadMedida)
                .Select(estOt => new {
                    estOt.EstProcOT_OrdenTrabajo,
                    estOt.EstProcOT_ExtrusionKg,
                    estOt.EstProcOT_ImpresionKg,
                    estOt.EstProcOT_RotograbadoKg,
                    estOt.EstProcOT_LaminadoKg,
                    estOt.EstProcOT_DobladoKg,
                    estOt.EstProcOT_CorteKg,
                    estOt.EstProcOT_EmpaqueKg,
                    estOt.EstProcOT_SelladoKg,
                    estOt.EstProcOT_SelladoUnd,
                    estOt.EstProcOT_WiketiadoKg,
                    estOt.EstProcOT_WiketiadoUnd,
                    estOt.Falla_Id,
                    estOt.FallaTecnica.Falla_Nombre,
                    estOt.Estado_Id,
                    estOt.Estado_OT.Estado_Nombre,
                    estOt.EstProcOT_Observacion,
                    estOt.EstProcOT_FechaCreacion,
                    estOt.EstProcOT_CantidadPedida,
                    estOt.UndMed_Id,
                    estOt.UnidadMedida.UndMed_Nombre
                })
                .ToList();
#pragma warning restore CS8602 // Desreferencia de una referencia posiblemente NULL.
            return Ok(ot);
        }

        [HttpGet("consultaPorOtFecha/{EstProcOT_OrdenTrabajo}/{EstProcOT_FechaCreacion}")]
        public ActionResult GetPorOtFecha(long EstProcOT_OrdenTrabajo, DateTime EstProcOT_FechaCreacion)
        {
#pragma warning disable CS8602 // Desreferencia de una referencia posiblemente NULL.
            var ot = _context.Estados_ProcesosOT.Where(epOT => epOT.EstProcOT_OrdenTrabajo == EstProcOT_OrdenTrabajo && epOT.EstProcOT_FechaCreacion == EstProcOT_FechaCreacion)
                .Include(estOT => estOT.FallaTecnica)
                .Include(estOT => estOT.Estado_OT)
                .Include(estOt => estOt.UnidadMedida)
                .Select(estOt => new {
                    estOt.EstProcOT_OrdenTrabajo,
                    estOt.EstProcOT_ExtrusionKg,
                    estOt.EstProcOT_ImpresionKg,
                    estOt.EstProcOT_RotograbadoKg,
                    estOt.EstProcOT_LaminadoKg,
                    estOt.EstProcOT_DobladoKg,
                    estOt.EstProcOT_CorteKg,
                    estOt.EstProcOT_EmpaqueKg,
                    estOt.EstProcOT_SelladoKg,
                    estOt.EstProcOT_SelladoUnd,
                    estOt.EstProcOT_WiketiadoKg,
                    estOt.EstProcOT_WiketiadoUnd,
                    estOt.Falla_Id,
                    estOt.FallaTecnica.Falla_Nombre,
                    estOt.Estado_Id,
                    estOt.Estado_OT.Estado_Nombre,
                    estOt.EstProcOT_Observacion,
                    estOt.EstProcOT_FechaCreacion,
                    estOt.EstProcOT_CantidadPedida,
                    estOt.UndMed_Id,
                    estOt.UnidadMedida.UndMed_Nombre
                })
                .ToList();
#pragma warning restore CS8602 // Desreferencia de una referencia posiblemente NULL.
            return Ok(ot);
        }

        [HttpGet("consultaPorOtFechas/{EstProcOT_OrdenTrabajo}")]
        public ActionResult GetPorOtFechas(long EstProcOT_OrdenTrabajo, DateTime EstProcOT_FechaCreacion1, DateTime EstProcOT_FechaCreacion2)
        {
#pragma warning disable CS8602 // Desreferencia de una referencia posiblemente NULL.
            var ot = _context.Estados_ProcesosOT
                .Where(epOT => epOT.EstProcOT_OrdenTrabajo == EstProcOT_OrdenTrabajo && epOT.EstProcOT_FechaCreacion >= EstProcOT_FechaCreacion1 && epOT.EstProcOT_FechaCreacion <= EstProcOT_FechaCreacion2)
                .Include(estOT => estOT.FallaTecnica)
                .Include(estOT => estOT.Estado_OT)
                .Include(estOt => estOt.UnidadMedida)
                .Select(estOt => new {
                    estOt.EstProcOT_OrdenTrabajo,
                    estOt.EstProcOT_ExtrusionKg,
                    estOt.EstProcOT_ImpresionKg,
                    estOt.EstProcOT_RotograbadoKg,
                    estOt.EstProcOT_LaminadoKg,
                    estOt.EstProcOT_DobladoKg,
                    estOt.EstProcOT_CorteKg,
                    estOt.EstProcOT_EmpaqueKg,
                    estOt.EstProcOT_SelladoKg,
                    estOt.EstProcOT_SelladoUnd,
                    estOt.EstProcOT_WiketiadoKg,
                    estOt.EstProcOT_WiketiadoUnd,
                    estOt.Falla_Id,
                    estOt.FallaTecnica.Falla_Nombre,
                    estOt.Estado_Id,
                    estOt.Estado_OT.Estado_Nombre,
                    estOt.EstProcOT_Observacion,
                    estOt.EstProcOT_FechaCreacion,
                    estOt.EstProcOT_CantidadPedida,
                    estOt.UndMed_Id,
                    estOt.UnidadMedida.UndMed_Nombre
                })
                .ToList();
#pragma warning restore CS8602 // Desreferencia de una referencia posiblemente NULL.
            return Ok(ot);
        }

        [HttpGet("consultaPorFechasFallas/{Falla_Id}")]
        public ActionResult GetPorFechasFallas(DateTime EstProcOT_FechaCreacion1, DateTime EstProcOT_FechaCreacion2, int Falla_Id)
        {
#pragma warning disable CS8602 // Desreferencia de una referencia posiblemente NULL.
            var ot = _context.Estados_ProcesosOT
                .Where(epOT => epOT.Falla_Id == Falla_Id && epOT.EstProcOT_FechaCreacion >= EstProcOT_FechaCreacion1 && epOT.EstProcOT_FechaCreacion <= EstProcOT_FechaCreacion2)
                .Include(estOT => estOT.FallaTecnica)
                .Include(estOT => estOT.Estado_OT)
                .Include(estOt => estOt.UnidadMedida)
                .Select(estOt => new {
                    estOt.EstProcOT_OrdenTrabajo,
                    estOt.EstProcOT_ExtrusionKg,
                    estOt.EstProcOT_ImpresionKg,
                    estOt.EstProcOT_RotograbadoKg,
                    estOt.EstProcOT_LaminadoKg,
                    estOt.EstProcOT_DobladoKg,
                    estOt.EstProcOT_CorteKg,
                    estOt.EstProcOT_EmpaqueKg,
                    estOt.EstProcOT_SelladoKg,
                    estOt.EstProcOT_SelladoUnd,
                    estOt.EstProcOT_WiketiadoKg,
                    estOt.EstProcOT_WiketiadoUnd,
                    estOt.Falla_Id,
                    estOt.FallaTecnica.Falla_Nombre,
                    estOt.Estado_Id,
                    estOt.Estado_OT.Estado_Nombre,
                    estOt.EstProcOT_Observacion,
                    estOt.EstProcOT_FechaCreacion,
                    estOt.EstProcOT_CantidadPedida,
                    estOt.UndMed_Id,
                    estOt.UnidadMedida.UndMed_Nombre
                })
                .ToList();
#pragma warning restore CS8602 // Desreferencia de una referencia posiblemente NULL.
            return Ok(ot);
        }

        [HttpGet("consultaPorOtFechasFallas/{EstProcOT_OrdenTrabajo}/{Falla_Id}")]
        public ActionResult Get(long EstProcOT_OrdenTrabajo, DateTime EstProcOT_FechaCreacion1, DateTime EstProcOT_FechaCreacion2, int Falla_Id)
        {
#pragma warning disable CS8602 // Desreferencia de una referencia posiblemente NULL.
            var ot = _context.Estados_ProcesosOT
                .Where(epOT => epOT.EstProcOT_OrdenTrabajo == EstProcOT_OrdenTrabajo && epOT.EstProcOT_FechaCreacion >= EstProcOT_FechaCreacion1 && epOT.EstProcOT_FechaCreacion <= EstProcOT_FechaCreacion2 && epOT.Falla_Id == Falla_Id)
                .Include(estOT => estOT.FallaTecnica)
                .Include(estOT => estOT.Estado_OT)
                .Include(estOt => estOt.UnidadMedida)
                .Select(estOt => new {
                    estOt.EstProcOT_OrdenTrabajo,
                    estOt.EstProcOT_ExtrusionKg,
                    estOt.EstProcOT_ImpresionKg,
                    estOt.EstProcOT_RotograbadoKg,
                    estOt.EstProcOT_LaminadoKg,
                    estOt.EstProcOT_DobladoKg,
                    estOt.EstProcOT_CorteKg,
                    estOt.EstProcOT_EmpaqueKg,
                    estOt.EstProcOT_SelladoKg,
                    estOt.EstProcOT_SelladoUnd,
                    estOt.EstProcOT_WiketiadoKg,
                    estOt.EstProcOT_WiketiadoUnd,
                    estOt.Falla_Id,
                    estOt.FallaTecnica.Falla_Nombre,
                    estOt.Estado_Id,
                    estOt.Estado_OT.Estado_Nombre,
                    estOt.EstProcOT_Observacion,
                    estOt.EstProcOT_FechaCreacion,
                    estOt.EstProcOT_CantidadPedida,
                    estOt.UndMed_Id,
                    estOt.UnidadMedida.UndMed_Nombre
                })
                .ToList();
#pragma warning restore CS8602 // Desreferencia de una referencia posiblemente NULL.
            return Ok(ot);
        }

        [HttpGet("consultaPorOtFechsFalla/{EstProcOT_FechaCreacion}/{Falla_Id}")]
        public ActionResult Get(int Falla_Id, DateTime EstProcOT_FechaCreacion)
        {
#pragma warning disable CS8602 // Desreferencia de una referencia posiblemente NULL.
            var ot = _context.Estados_ProcesosOT.Where(epOT => epOT.EstProcOT_FechaCreacion == EstProcOT_FechaCreacion && epOT.Falla_Id == Falla_Id)
                .Include(estOT => estOT.FallaTecnica)
                .Include(estOT => estOT.Estado_OT)
                .Include(estOt => estOt.UnidadMedida)
                .Select(estOt => new {
                    estOt.EstProcOT_OrdenTrabajo,
                    estOt.EstProcOT_ExtrusionKg,
                    estOt.EstProcOT_ImpresionKg,
                    estOt.EstProcOT_RotograbadoKg,
                    estOt.EstProcOT_LaminadoKg,
                    estOt.EstProcOT_DobladoKg,
                    estOt.EstProcOT_CorteKg,
                    estOt.EstProcOT_EmpaqueKg,
                    estOt.EstProcOT_SelladoKg,
                    estOt.EstProcOT_SelladoUnd,
                    estOt.EstProcOT_WiketiadoKg,
                    estOt.EstProcOT_WiketiadoUnd,
                    estOt.Falla_Id,
                    estOt.FallaTecnica.Falla_Nombre,
                    estOt.Estado_Id,
                    estOt.Estado_OT.Estado_Nombre,
                    estOt.EstProcOT_Observacion,
                    estOt.EstProcOT_FechaCreacion,
                    estOt.EstProcOT_CantidadPedida,
                    estOt.UndMed_Id,
                    estOt.UnidadMedida.UndMed_Nombre
                })
                .ToList();
#pragma warning restore CS8602 // Desreferencia de una referencia posiblemente NULL.

            return Ok(ot);
        }

        [HttpGet("consultarPorEstados/{Estado_Id}")]
        public ActionResult Get (int Estado_Id)
        {
#pragma warning disable CS8602 // Desreferencia de una referencia posiblemente NULL.
            var ot = _context.Estados_ProcesosOT.Where(epOT => epOT.Estado_Id == Estado_Id)
                .Include(estOT => estOT.FallaTecnica)
                .Include(estOT => estOT.Estado_OT)
                .Include(estOt => estOt.UnidadMedida)
                .Select(estOt => new {
                    estOt.EstProcOT_OrdenTrabajo,
                    estOt.EstProcOT_ExtrusionKg,
                    estOt.EstProcOT_ImpresionKg,
                    estOt.EstProcOT_RotograbadoKg,
                    estOt.EstProcOT_LaminadoKg,
                    estOt.EstProcOT_DobladoKg,
                    estOt.EstProcOT_CorteKg,
                    estOt.EstProcOT_EmpaqueKg,
                    estOt.EstProcOT_SelladoKg,
                    estOt.EstProcOT_SelladoUnd,
                    estOt.EstProcOT_WiketiadoKg,
                    estOt.EstProcOT_WiketiadoUnd,
                    estOt.Falla_Id,
                    estOt.FallaTecnica.Falla_Nombre,
                    estOt.Estado_Id,
                    estOt.Estado_OT.Estado_Nombre,
                    estOt.EstProcOT_Observacion,
                    estOt.EstProcOT_FechaCreacion,
                    estOt.EstProcOT_CantidadPedida,
                    estOt.UndMed_Id,
                    estOt.UnidadMedida.UndMed_Nombre
                })
                .ToList();
#pragma warning restore CS8602 // Desreferencia de una referencia posiblemente NULL.

            return Ok(ot);
        }

        [HttpGet("consultaPorEstadosFallas/{Estado_Id}/{Falla_Id}")]
        public ActionResult Get (int Estado_Id, int Falla_Id)
        {
#pragma warning disable CS8602 // Desreferencia de una referencia posiblemente NULL.
            var ot = _context.Estados_ProcesosOT.Where(epOT => epOT.Estado_Id == Estado_Id && epOT.Falla_Id == Falla_Id)
                .Include(estOT => estOT.FallaTecnica)
                .Include(estOT => estOT.Estado_OT)
                .Include(estOt => estOt.UnidadMedida)
                .Select(estOt => new {
                    estOt.EstProcOT_OrdenTrabajo,
                    estOt.EstProcOT_ExtrusionKg,
                    estOt.EstProcOT_ImpresionKg,
                    estOt.EstProcOT_RotograbadoKg,
                    estOt.EstProcOT_LaminadoKg,
                    estOt.EstProcOT_DobladoKg,
                    estOt.EstProcOT_CorteKg,
                    estOt.EstProcOT_EmpaqueKg,
                    estOt.EstProcOT_SelladoKg,
                    estOt.EstProcOT_SelladoUnd,
                    estOt.EstProcOT_WiketiadoKg,
                    estOt.EstProcOT_WiketiadoUnd,
                    estOt.Falla_Id,
                    estOt.FallaTecnica.Falla_Nombre,
                    estOt.Estado_Id,
                    estOt.Estado_OT.Estado_Nombre,
                    estOt.EstProcOT_Observacion,
                    estOt.EstProcOT_FechaCreacion,
                    estOt.EstProcOT_CantidadPedida,
                    estOt.UndMed_Id,
                    estOt.UnidadMedida.UndMed_Nombre
                })
                .ToList();
#pragma warning restore CS8602 // Desreferencia de una referencia posiblemente NULL.
            return Ok(ot);
        }

        [HttpGet("consultaPorFechaEstadoFalla/{EstProcOT_FechaCreacion}/{Estado_Id}/{Falla_Id}")]
        public ActionResult Get (DateTime EstProcOT_FechaCreacion, int Estado_Id, int Falla_Id)
        {
#pragma warning disable CS8602 // Desreferencia de una referencia posiblemente NULL.
            var ot = _context.Estados_ProcesosOT.Where(epOT => epOT.EstProcOT_FechaCreacion == EstProcOT_FechaCreacion && epOT.Estado_Id == Estado_Id && epOT.Falla_Id == Falla_Id)
                .Include(estOT => estOT.FallaTecnica)
                .Include(estOT => estOT.Estado_OT)
                .Include(estOt => estOt.UnidadMedida)
                .Select(estOt => new {
                    estOt.EstProcOT_OrdenTrabajo,
                    estOt.EstProcOT_ExtrusionKg,
                    estOt.EstProcOT_ImpresionKg,
                    estOt.EstProcOT_RotograbadoKg,
                    estOt.EstProcOT_LaminadoKg,
                    estOt.EstProcOT_DobladoKg,
                    estOt.EstProcOT_CorteKg,
                    estOt.EstProcOT_EmpaqueKg,
                    estOt.EstProcOT_SelladoKg,
                    estOt.EstProcOT_SelladoUnd,
                    estOt.EstProcOT_WiketiadoKg,
                    estOt.EstProcOT_WiketiadoUnd,
                    estOt.Falla_Id,
                    estOt.FallaTecnica.Falla_Nombre,
                    estOt.Estado_Id,
                    estOt.Estado_OT.Estado_Nombre,
                    estOt.EstProcOT_Observacion,
                    estOt.EstProcOT_FechaCreacion,
                    estOt.EstProcOT_CantidadPedida,
                    estOt.UndMed_Id,
                    estOt.UnidadMedida.UndMed_Nombre
                })
                .ToList();
#pragma warning restore CS8602 // Desreferencia de una referencia posiblemente NULL.
            return Ok(ot);
        }
        
        [HttpGet("consultaPorFechasEstado/{EstProcOT_FechaCreacion1}/{EstProcOT_FechaCreacion2}/{Estado_Id}")]
        public ActionResult Get(DateTime EstProcOT_FechaCreacion1, DateTime EstProcOT_FechaCreacion2, int Estado_Id)
        {
#pragma warning disable CS8602 // Desreferencia de una referencia posiblemente NULL.
            var ot = _context.Estados_ProcesosOT.Where(epOT => epOT.EstProcOT_FechaCreacion >= EstProcOT_FechaCreacion1 && epOT.EstProcOT_FechaCreacion <= EstProcOT_FechaCreacion2 && epOT.Estado_Id == Estado_Id)
                .Include(estOT => estOT.FallaTecnica)
                .Include(estOT => estOT.Estado_OT)
                .Include(estOt => estOt.UnidadMedida)
                .Select(estOt => new {
                    estOt.EstProcOT_OrdenTrabajo,
                    estOt.EstProcOT_ExtrusionKg,
                    estOt.EstProcOT_ImpresionKg,
                    estOt.EstProcOT_RotograbadoKg,
                    estOt.EstProcOT_LaminadoKg,
                    estOt.EstProcOT_DobladoKg,
                    estOt.EstProcOT_CorteKg,
                    estOt.EstProcOT_EmpaqueKg,
                    estOt.EstProcOT_SelladoKg,
                    estOt.EstProcOT_SelladoUnd,
                    estOt.EstProcOT_WiketiadoKg,
                    estOt.EstProcOT_WiketiadoUnd,
                    estOt.Falla_Id,
                    estOt.FallaTecnica.Falla_Nombre,
                    estOt.Estado_Id,
                    estOt.Estado_OT.Estado_Nombre,
                    estOt.EstProcOT_Observacion,
                    estOt.EstProcOT_FechaCreacion,
                    estOt.EstProcOT_CantidadPedida,
                    estOt.UndMed_Id,
                    estOt.UnidadMedida.UndMed_Nombre
                })
                .ToList();
#pragma warning restore CS8602 // Desreferencia de una referencia posiblemente NULL.
            return Ok(ot);
        }

        [HttpGet("consultaPorFechasEstadoFallas/{EstProcOT_FechaCreacion1}/{EstProcOT_FechaCreacion2}/{Estado_Id}/{Falla_Id}")]
        public ActionResult Get (DateTime EstProcOT_FechaCreacion1, DateTime EstProcOT_FechaCreacion2, int Estado_Id, int Falla_Id)
        {
#pragma warning disable CS8602 // Desreferencia de una referencia posiblemente NULL.
            var ot = _context.Estados_ProcesosOT.Where(epOT => epOT.EstProcOT_FechaCreacion >= EstProcOT_FechaCreacion1 && epOT.EstProcOT_FechaCreacion <= EstProcOT_FechaCreacion2 && epOT.Estado_Id == Estado_Id && epOT.Falla_Id == Falla_Id)
                .Include(estOT => estOT.FallaTecnica)
                .Include(estOT => estOT.Estado_OT)
                .Include(estOt => estOt.UnidadMedida)
                .Select(estOt => new {
                    estOt.EstProcOT_OrdenTrabajo,
                    estOt.EstProcOT_ExtrusionKg,
                    estOt.EstProcOT_ImpresionKg,
                    estOt.EstProcOT_RotograbadoKg,
                    estOt.EstProcOT_LaminadoKg,
                    estOt.EstProcOT_DobladoKg,
                    estOt.EstProcOT_CorteKg,
                    estOt.EstProcOT_EmpaqueKg,
                    estOt.EstProcOT_SelladoKg,
                    estOt.EstProcOT_SelladoUnd,
                    estOt.EstProcOT_WiketiadoKg,
                    estOt.EstProcOT_WiketiadoUnd,
                    estOt.Falla_Id,
                    estOt.FallaTecnica.Falla_Nombre,
                    estOt.Estado_Id,
                    estOt.Estado_OT.Estado_Nombre,
                    estOt.EstProcOT_Observacion,
                    estOt.EstProcOT_FechaCreacion,
                    estOt.EstProcOT_CantidadPedida,
                    estOt.UndMed_Id,
                    estOt.UnidadMedida.UndMed_Nombre
                })
                .ToList();
#pragma warning restore CS8602 // Desreferencia de una referencia posiblemente NULL.
            return Ok(ot);
        }

        /** Metodos para Estados OT por Vendedores */
        
        /*1 POR OT Y VENDEDOR */
        [HttpGet("consultaPorOTVendedor/{EstProcOT_OrdenTrabajo}/{Vendedor}")]
        public ActionResult GetXOT(long EstProcOT_OrdenTrabajo, int Vendedor)
        {
            var ot = _context.Estados_ProcesosOT.Where(epOT => epOT.EstProcOT_OrdenTrabajo == EstProcOT_OrdenTrabajo && epOT.Usua_Id == Vendedor)
                .Include(estOT => estOT.FallaTecnica)
                .Include(estOT => estOT.Estado_OT)
                .Include(estOt => estOt.UnidadMedida)
                .Include(estOt => estOt.Usuario)
                .Select(estOt => new {
                    estOt.EstProcOT_OrdenTrabajo,
                    estOt.EstProcOT_ExtrusionKg,
                    estOt.EstProcOT_ImpresionKg,
                    estOt.EstProcOT_RotograbadoKg,
                    estOt.EstProcOT_LaminadoKg,
                    estOt.EstProcOT_DobladoKg,
                    estOt.EstProcOT_CorteKg,
                    estOt.EstProcOT_EmpaqueKg,
                    estOt.EstProcOT_SelladoKg,
                    estOt.EstProcOT_SelladoUnd,
                    estOt.EstProcOT_WiketiadoKg,
                    estOt.EstProcOT_WiketiadoUnd,
                    estOt.Falla_Id,
                    estOt.FallaTecnica.Falla_Nombre,
                    estOt.Estado_Id,
                    estOt.Estado_OT.Estado_Nombre,
                    estOt.EstProcOT_Observacion,
                    estOt.EstProcOT_FechaCreacion,
                    estOt.EstProcOT_CantidadPedida,
                    estOt.UndMed_Id,
                    estOt.UnidadMedida.UndMed_Nombre,
                    estOt.Usua_Id,
                    estOt.Usuario.Usua_Nombre
                })
                .ToList();
            return Ok(ot);
        }

        /*2 POR Fecha Creacion Y VENDEDOR */

        [HttpGet("consultaPorFechaVendedor/{EstProcOT_FechaCreacion}/{Vendedor}")]
        public ActionResult GetXFecha(DateTime EstProcOT_FechaCreacion, int Vendedor)
        {
#pragma warning disable CS8602 // Desreferencia de una referencia posiblemente NULL.
            var ot = _context.Estados_ProcesosOT.Where(epOT => epOT.EstProcOT_FechaCreacion == EstProcOT_FechaCreacion && epOT.Usua_Id == Vendedor)
                .Include(estOT => estOT.FallaTecnica)
                .Include(estOT => estOT.Estado_OT)
                .Include(estOt => estOt.UnidadMedida)
                .Include(estOt => estOt.Usuario)
                .Select(estOt => new {
                    estOt.EstProcOT_OrdenTrabajo,
                    estOt.EstProcOT_ExtrusionKg,
                    estOt.EstProcOT_ImpresionKg,
                    estOt.EstProcOT_RotograbadoKg,
                    estOt.EstProcOT_LaminadoKg,
                    estOt.EstProcOT_DobladoKg,
                    estOt.EstProcOT_CorteKg,
                    estOt.EstProcOT_EmpaqueKg,
                    estOt.EstProcOT_SelladoKg,
                    estOt.EstProcOT_SelladoUnd,
                    estOt.EstProcOT_WiketiadoKg,
                    estOt.EstProcOT_WiketiadoUnd,
                    estOt.Falla_Id,
                    estOt.FallaTecnica.Falla_Nombre,
                    estOt.Estado_Id,
                    estOt.Estado_OT.Estado_Nombre,
                    estOt.EstProcOT_Observacion,
                    estOt.EstProcOT_FechaCreacion,
                    estOt.EstProcOT_CantidadPedida,
                    estOt.UndMed_Id,
                    estOt.UnidadMedida.UndMed_Nombre,
                    estOt.Usua_Id,
                    estOt.Usuario.Usua_Nombre
                })
                .ToList();
#pragma warning restore CS8602 // Desreferencia de una referencia posiblemente NULL.
            return Ok(ot);
        }


        /*3 Por Fechas y Vendedor */
        [HttpGet("consultaPorFechasVendedor/{EstProcOT_FechaCreacion1}/{EstProcOT_FechaCreacion2}/{Vendedor}")]
        public ActionResult GetXFechas(DateTime EstProcOT_FechaCreacion1, DateTime EstProcOT_FechaCreacion2, int Vendedor)
        {
#pragma warning disable CS8602 // Desreferencia de una referencia posiblemente NULL.
            var ot = _context.Estados_ProcesosOT.Where(epOT => epOT.EstProcOT_FechaCreacion >= EstProcOT_FechaCreacion1 && epOT.EstProcOT_FechaCreacion <= EstProcOT_FechaCreacion2 && epOT.Usua_Id == Vendedor)
                .Include(estOT => estOT.FallaTecnica)
                .Include(estOT => estOT.Estado_OT)
                .Include(estOt => estOt.UnidadMedida)
                .Include(estOt => estOt.Usuario)
                .Select(estOt => new {
                    estOt.EstProcOT_OrdenTrabajo,
                    estOt.EstProcOT_ExtrusionKg,
                    estOt.EstProcOT_ImpresionKg,
                    estOt.EstProcOT_RotograbadoKg,
                    estOt.EstProcOT_LaminadoKg,
                    estOt.EstProcOT_DobladoKg,
                    estOt.EstProcOT_CorteKg,
                    estOt.EstProcOT_EmpaqueKg,
                    estOt.EstProcOT_SelladoKg,
                    estOt.EstProcOT_SelladoUnd,
                    estOt.EstProcOT_WiketiadoKg,
                    estOt.EstProcOT_WiketiadoUnd,
                    estOt.Falla_Id,
                    estOt.FallaTecnica.Falla_Nombre,
                    estOt.Estado_Id,
                    estOt.Estado_OT.Estado_Nombre,
                    estOt.EstProcOT_Observacion,
                    estOt.EstProcOT_FechaCreacion,
                    estOt.EstProcOT_CantidadPedida,
                    estOt.UndMed_Id,
                    estOt.UnidadMedida.UndMed_Nombre,
                    estOt.Usua_Id,
                    estOt.Usuario.Usua_Nombre
                })
                .ToList();
#pragma warning restore CS8602 // Desreferencia de una referencia posiblemente NULL.
            return Ok(ot);
        }

        /*4 POR OT, Fecha Ini y Vendedor */

        [HttpGet("consultaPorOtFechaVendedor/{EstProcOT_OrdenTrabajo}/{EstProcOT_FechaCreacion}/{Vendedor}")]
        public ActionResult GetXOtFecha(long EstProcOT_OrdenTrabajo, DateTime EstProcOT_FechaCreacion, int Vendedor)
        {
#pragma warning disable CS8602 // Desreferencia de una referencia posiblemente NULL.
            var ot = _context.Estados_ProcesosOT.Where(epOT => epOT.EstProcOT_OrdenTrabajo == EstProcOT_OrdenTrabajo && epOT.EstProcOT_FechaCreacion == EstProcOT_FechaCreacion && epOT.Usua_Id == Vendedor)
                .Include(estOT => estOT.FallaTecnica)
                .Include(estOT => estOT.Estado_OT)
                .Include(estOt => estOt.UnidadMedida)
                .Include(estOt => estOt.Usuario)
                .Select(estOt => new {
                    estOt.EstProcOT_OrdenTrabajo,
                    estOt.EstProcOT_ExtrusionKg,
                    estOt.EstProcOT_ImpresionKg,
                    estOt.EstProcOT_RotograbadoKg,
                    estOt.EstProcOT_LaminadoKg,
                    estOt.EstProcOT_DobladoKg,
                    estOt.EstProcOT_CorteKg,
                    estOt.EstProcOT_EmpaqueKg,
                    estOt.EstProcOT_SelladoKg,
                    estOt.EstProcOT_SelladoUnd,
                    estOt.EstProcOT_WiketiadoKg,
                    estOt.EstProcOT_WiketiadoUnd,
                    estOt.Falla_Id,
                    estOt.FallaTecnica.Falla_Nombre,
                    estOt.Estado_Id,
                    estOt.Estado_OT.Estado_Nombre,
                    estOt.EstProcOT_Observacion,
                    estOt.EstProcOT_FechaCreacion,
                    estOt.EstProcOT_CantidadPedida,
                    estOt.UndMed_Id,
                    estOt.UnidadMedida.UndMed_Nombre,
                    estOt.Usua_Id,
                    estOt.Usuario.Usua_Nombre
                })
                .ToList();
#pragma warning restore CS8602 // Desreferencia de una referencia posiblemente NULL.
            return Ok(ot);
        }

        /*5 Por Fechas, OT, Vendedor */

        [HttpGet("consultaPorOtFechasVendedor/{EstProcOT_FechaCreacion1}/{EstProcOT_FechaCreacion2}/{EstProcOT_OrdenTrabajo}/{Vendedor}")]
        public ActionResult GetXOtFechas(long EstProcOT_OrdenTrabajo, DateTime EstProcOT_FechaCreacion1, DateTime EstProcOT_FechaCreacion2, int Vendedor)
        {
#pragma warning disable CS8602 // Desreferencia de una referencia posiblemente NULL.
            var ot = _context.Estados_ProcesosOT
                .Where(epOT => epOT.EstProcOT_OrdenTrabajo == EstProcOT_OrdenTrabajo && epOT.EstProcOT_FechaCreacion >= EstProcOT_FechaCreacion1 && epOT.EstProcOT_FechaCreacion <= EstProcOT_FechaCreacion2 && epOT.Usua_Id == Vendedor)
                .Include(estOT => estOT.FallaTecnica)
                .Include(estOT => estOT.Estado_OT)
                .Include(estOt => estOt.UnidadMedida)
                .Include(estOt => estOt.Usuario)
                .Select(estOt => new {
                    estOt.EstProcOT_OrdenTrabajo,
                    estOt.EstProcOT_ExtrusionKg,
                    estOt.EstProcOT_ImpresionKg,
                    estOt.EstProcOT_RotograbadoKg,
                    estOt.EstProcOT_LaminadoKg,
                    estOt.EstProcOT_DobladoKg,
                    estOt.EstProcOT_CorteKg,
                    estOt.EstProcOT_EmpaqueKg,
                    estOt.EstProcOT_SelladoKg,
                    estOt.EstProcOT_SelladoUnd,
                    estOt.EstProcOT_WiketiadoKg,
                    estOt.EstProcOT_WiketiadoUnd,
                    estOt.Falla_Id,
                    estOt.FallaTecnica.Falla_Nombre,
                    estOt.Estado_Id,
                    estOt.Estado_OT.Estado_Nombre,
                    estOt.EstProcOT_Observacion,
                    estOt.EstProcOT_FechaCreacion,
                    estOt.EstProcOT_CantidadPedida,
                    estOt.UndMed_Id,
                    estOt.UnidadMedida.UndMed_Nombre,
                    estOt.Usua_Id,
                    estOt.Usuario.Usua_Nombre
                })
                .ToList();
#pragma warning restore CS8602 // Desreferencia de una referencia posiblemente NULL.
            return Ok(ot);
        }


        /*6 Por Estados y vendedor*/
        [HttpGet("consultarPorEstadosVendedor/{Estado_Id}/{Vendedor}")]
        public ActionResult GetXEstado(int Estado_Id, int Vendedor)
        {
#pragma warning disable CS8602 // Desreferencia de una referencia posiblemente NULL.
            var ot = _context.Estados_ProcesosOT.Where(epOT => epOT.Estado_Id == Estado_Id && epOT.Usua_Id == Vendedor)
                .Include(estOT => estOT.FallaTecnica)
                .Include(estOT => estOT.Estado_OT)
                .Include(estOt => estOt.UnidadMedida)
                .Include(estOt => estOt.Usuario)
                .Select(estOt => new {
                    estOt.EstProcOT_OrdenTrabajo,
                    estOt.EstProcOT_ExtrusionKg,
                    estOt.EstProcOT_ImpresionKg,
                    estOt.EstProcOT_RotograbadoKg,
                    estOt.EstProcOT_LaminadoKg,
                    estOt.EstProcOT_DobladoKg,
                    estOt.EstProcOT_CorteKg,
                    estOt.EstProcOT_EmpaqueKg,
                    estOt.EstProcOT_SelladoKg,
                    estOt.EstProcOT_SelladoUnd,
                    estOt.EstProcOT_WiketiadoKg,
                    estOt.EstProcOT_WiketiadoUnd,
                    estOt.Falla_Id,
                    estOt.FallaTecnica.Falla_Nombre,
                    estOt.Estado_Id,
                    estOt.Estado_OT.Estado_Nombre,
                    estOt.EstProcOT_Observacion,
                    estOt.EstProcOT_FechaCreacion,
                    estOt.EstProcOT_CantidadPedida,
                    estOt.UndMed_Id,
                    estOt.UnidadMedida.UndMed_Nombre,
                    estOt.Usua_Id,
                    estOt.Usuario.Usua_Nombre
                })
                .ToList();
#pragma warning restore CS8602 // Desreferencia de una referencia posiblemente NULL.

            return Ok(ot);
        }

        /*7 Por Fechas, estados y vendedor*/
        [HttpGet("consultaPorFechasEstadoVendedor/{EstProcOT_FechaCreacion1}/{EstProcOT_FechaCreacion2}/{Estado_Id}/{Vendedor}")]
        public ActionResult GetXFechasXEstadoXVendedor(DateTime EstProcOT_FechaCreacion1, DateTime EstProcOT_FechaCreacion2, int Estado_Id, int Vendedor)
        {
#pragma warning disable CS8602 // Desreferencia de una referencia posiblemente NULL.
            var ot = _context.Estados_ProcesosOT.Where(epOT => epOT.EstProcOT_FechaCreacion >= EstProcOT_FechaCreacion1 && epOT.EstProcOT_FechaCreacion <= EstProcOT_FechaCreacion2 && epOT.Estado_Id == Estado_Id && epOT.Usua_Id == Vendedor)
                .Include(estOT => estOT.FallaTecnica)
                .Include(estOT => estOT.Estado_OT)
                .Include(estOt => estOt.UnidadMedida)
                .Include(estOt => estOt.Usuario)
                .Select(estOt => new {
                    estOt.EstProcOT_OrdenTrabajo,
                    estOt.EstProcOT_ExtrusionKg,
                    estOt.EstProcOT_ImpresionKg,
                    estOt.EstProcOT_RotograbadoKg,
                    estOt.EstProcOT_LaminadoKg,
                    estOt.EstProcOT_DobladoKg,
                    estOt.EstProcOT_CorteKg,
                    estOt.EstProcOT_EmpaqueKg,
                    estOt.EstProcOT_SelladoKg,
                    estOt.EstProcOT_SelladoUnd,
                    estOt.EstProcOT_WiketiadoKg,
                    estOt.EstProcOT_WiketiadoUnd,
                    estOt.Falla_Id,
                    estOt.FallaTecnica.Falla_Nombre,
                    estOt.Estado_Id,
                    estOt.Estado_OT.Estado_Nombre,
                    estOt.EstProcOT_Observacion,
                    estOt.EstProcOT_FechaCreacion,
                    estOt.EstProcOT_CantidadPedida,
                    estOt.UndMed_Id,
                    estOt.UnidadMedida.UndMed_Nombre
                })
                .ToList();
#pragma warning restore CS8602 // Desreferencia de una referencia posiblemente NULL.
            return Ok(ot);
        }

        /** Fin Consultas por vendedor */

        [HttpPut("ActualizacionFallaObservacion/{EstProcOT_OrdenTrabajo}")]
        public IActionResult Put(long EstProcOT_OrdenTrabajo, Estados_ProcesosOT Estados_ProcesosOT)
        {
            try
            {
                var Actualizado = _context.Estados_ProcesosOT.Where(x => x.EstProcOT_OrdenTrabajo == EstProcOT_OrdenTrabajo).First<Estados_ProcesosOT>();
                Actualizado.Falla_Id = Estados_ProcesosOT.Falla_Id;
                Actualizado.EstProcOT_Observacion = Estados_ProcesosOT.EstProcOT_Observacion;

                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Estados_ProcesosOTExists(EstProcOT_OrdenTrabajo))
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

        // PUT: api/Estados_ProcesosOT/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstados_ProcesosOT(long id, Estados_ProcesosOT estados_ProcesosOT)
        {
            if (id != estados_ProcesosOT.EstProcOT_Id)
            {
                return BadRequest();
            }

            _context.Entry(estados_ProcesosOT).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Estados_ProcesosOTExists(id))
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

        // POST: api/Estados_ProcesosOT
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Estados_ProcesosOT>> PostEstados_ProcesosOT(Estados_ProcesosOT estados_ProcesosOT)
        {
          if (_context.Estados_ProcesosOT == null)
          {
              return Problem("Entity set 'dataContext.Estados_ProcesosOT'  is null.");
          }
            _context.Estados_ProcesosOT.Add(estados_ProcesosOT);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstados_ProcesosOT", new { id = estados_ProcesosOT.EstProcOT_Id }, estados_ProcesosOT);
        }

        // DELETE: api/Estados_ProcesosOT/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstados_ProcesosOT(long id)
        {
            if (_context.Estados_ProcesosOT == null)
            {
                return NotFound();
            }
            var estados_ProcesosOT = await _context.Estados_ProcesosOT.FindAsync(id);
            if (estados_ProcesosOT == null)
            {
                return NotFound();
            }

            _context.Estados_ProcesosOT.Remove(estados_ProcesosOT);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Estados_ProcesosOTExists(long id)
        {
            return (_context.Estados_ProcesosOT?.Any(e => e.EstProcOT_Id == id)).GetValueOrDefault();
        }
    }
}
