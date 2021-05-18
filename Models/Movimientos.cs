using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TareaDiplomado.Models
{
    public class Movimientos
    {
        [Key]
        public int id { get; set; }
        public int idcuenta { get; set; }
        public DateTime fecha { get; set; }
        public string tipo { get; set; }
        public decimal cantidad { get; set; }

        //[NotMapped]
        //public decimal Depositos { get { return tipo == "D" ?cantidad:0 ; }  }
        //[NotMapped]
        //public decimal Retiros { get { return tipo == "R" ? cantidad : 0; } }

        public Movimientos(int idcuenta,DateTime fecha,string tipo,decimal cantidad )
        {
            this.idcuenta = idcuenta;
            this.fecha = fecha;
            this.tipo = tipo;
            this.cantidad = cantidad;
        }

        [NotMapped]
        [ForeignKey("idcuenta")]
        public virtual Cuentas Cuentas { get; set; }

    }
}
