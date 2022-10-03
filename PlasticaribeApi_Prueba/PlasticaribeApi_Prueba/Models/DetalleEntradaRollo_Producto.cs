﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlasticaribeApi_Prueba.Models
{
    public class DetalleEntradaRollo_Producto
    {
        [Key]
        public long DtEntRolloProd_Codigo { get; set; }

        public long EntRolloProd_Id { get; set; }
        public EntradaRollo_Producto? EntRollo_Producto { get; set; }

        [Column(Order = 3)]
        public long Rollo_Id { get; set; }


        [Precision(14, 2)]
        public decimal DtEntRolloProd_Cantidad { get; set; }


        [Column(TypeName = "varchar(10)")]
        public string UndMed_Rollo { get; set; }
        public Unidad_Medida? UndMedida_Rollo { get; set; }


        public int Estado_Id { get; set; }
        public Estado? Estado { get; set; }

        public long DtEntRolloProd_OT { get; set; }

        public int Prod_Id { get; set; }
        public Producto? Prod { get; set; }


        [Column(TypeName = "varchar(10)")]
        public string UndMed_Prod { get; set; }
        public Unidad_Medida? UndMedida_Prod { get; set; }

        [Precision(14, 2)]
        public int Prod_CantPaquetesRestantes  {get; set;}

        [Precision(14, 2)]
        public int Prod_CantBolsasPaquete { get; set; }

        [Precision(14, 2)]
        public int Prod_CantBolsasBulto { get; set; }

        [Precision(14, 2)]
        public int Prod_CantBolsasRestates { get; set; }

        [Precision(14, 2)]
        public int Prod_CantBolsasFacturadas { get; set; }
    }
}
