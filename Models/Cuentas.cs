using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TareaDiplomado.Models
{
    public class Cuentas
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }
        public string email { get; set; }
        public DateTime fecha { get; set; }


        //[NotMapped]
        //public decimal Retiros { get { return Movimientos.Sum(x => x.Retiros); } }

        //[NotMapped]
        //public decimal Depositos { get { return Movimientos.Sum(x => x.Depositos); } }


        //[NotMapped]
        //public decimal Saldo { get { return Depositos - Retiros; } }


        public Cuentas(string nombre, string email, DateTime fecha)
        {
            this.nombre = nombre;
            this.email = email;
            this.fecha=fecha;
        }


        [NotMapped]
        public virtual List<Movimientos> Movimientos{ get; set; }

    }
}
