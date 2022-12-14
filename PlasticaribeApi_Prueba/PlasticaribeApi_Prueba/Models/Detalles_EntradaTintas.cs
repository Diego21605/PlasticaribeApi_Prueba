using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlasticaribeApi_Prueba.Models
{
    public class Detalles_EntradaTintas
    {
        public int EntTinta_Id { get; set; }
        public Entrada_Tintas? Entrada_Tinta { get; set; }

        public long Tinta_Id { get; set; }
        public Tinta? Tintas { get; set; }

        [Precision(18, 2)]
        public decimal DtEntTinta_Cantidad { get; set; }
        public string UndMed_Id { get; set; }
        public Unidad_Medida? UndMed { get; set; }
    }
}
