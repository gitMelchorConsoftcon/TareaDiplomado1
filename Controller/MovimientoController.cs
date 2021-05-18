using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TareaDiplomado.Db;
using TareaDiplomado.Models;

namespace TareaDiplomado.Controller
{
    public class MovimientoController
    {
        readonly Operaciones<Movimientos> ope = new Operaciones<Movimientos>();
        readonly Operaciones<Cuentas> cuenta = new Operaciones<Cuentas>();
        public async  Task<List<Movimientos>> Reporte(int id)
        {
            var lista = await ope.Listar();
            return  lista.Where(x=> x.idcuenta==id).ToList();
        }

        public Movimientos  Buscar(int id)
        {
            var obj = ope.Buscar(id);
            return obj;
          
        }

        public Cuentas BuscarCuenta(int id )
        {
            var obj = cuenta.Buscar(id);
            return obj;
        }

        public async Task<decimal> Saldo(int id)
        {
            var obj = await Reporte(id);
            decimal resultado = 0;


            foreach(var item in obj)
            {
                if (item.tipo == "D")
                    resultado += item.cantidad;
                else
                    resultado -= item.cantidad;
            }

            return resultado;


        }


        public void Nuevo(Movimientos obj)
        {
            ope.Guardar(obj);
            Console.WriteLine("Se guardo con exito....");
        }

        public void Modificar(Movimientos obj)
        {
            ope.Modificar(obj.id, obj);
            Console.WriteLine("Se guardo con exito....");

        }

        public void Borrar(int id)
        {
            ope.Borrar(id);
            Console.WriteLine("Se borro con exito....");

        }
    }
}
