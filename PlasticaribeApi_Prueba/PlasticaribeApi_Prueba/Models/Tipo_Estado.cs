using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlasticaribeApi_Prueba.Models
{
    public class Tipo_Estado
    {
        [Key]
        public int TpEstado_Id { get; set; }
       
        [Column(TypeName = "varchar(50)")]
        public string TpEstado_Nombre { get; set; }
        
        [Column(TypeName = "text")]
        public string? TpEstado_Descripcion { get; set; }

    }
}
