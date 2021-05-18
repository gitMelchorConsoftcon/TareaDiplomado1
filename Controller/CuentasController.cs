using System;
using System.Threading.Tasks;
using TareaDiplomado.Db;
using TareaDiplomado.Models;

namespace TareaDiplomado.Controller
{
    public  class CuentasController
    {
        Operaciones<Cuentas> ope = new Operaciones<Cuentas>();
        MovimientoController movs = new MovimientoController();
        public async Task< bool> Reporte()
        {
            int x = 0;
            foreach (var item in await ope.Listar())
            {
                Utilerias.Escribir($"{item.id}  -  {item.nombre.PadRight(40,' ')} {item.email.PadRight(30,' ')} {item.fecha.ToShortDateString()}  =>   {await movs.Saldo(item.id)} ",10,4+x);
                x++;
            }

            Utilerias.Escribir("Nuevo .........1", 10, Console.CursorTop +2);
            Utilerias.Escribir("Borrar ........2", 10, Console.CursorTop + 1);
            Utilerias.Escribir("Modificar .....3", 10, Console.CursorTop + 1);
            Utilerias.Escribir("Movimientos....4", 10, Console.CursorTop + 1);
            Utilerias.Escribir("Salir .........5", 10, Console.CursorTop + 1);
            Utilerias.Escribir("Opcion :", 10, Console.CursorTop + 1);
           

            return true;
        }

        public bool Buscar(int id)
        {
            var obj = ope.Buscar(id);   
            if (obj != null)
            {
                Utilerias.Escribir($"Nombre: {obj.nombre}",10,3);
                Utilerias.Escribir($"Correo: {obj.email}", 10, 4);
                Utilerias.Escribir($"Fecha: {obj.fecha}", 10, 5);
                return true;
           
            }
            else
            {
                Utilerias.Escribir($"Cuenta no encontrada", 10, 4);
                return false;
            }
                
        }

        public void Nuevo(Cuentas obj)
        {
            ope.Guardar(obj);
            Console.WriteLine("Se guardo con exito....");
        }

        public void Modificar(Cuentas obj)
        {
          

            ope.Modificar(obj.id, obj);
            Console.WriteLine("Se guardo con exito....");

        }

        public void Borrar(int id )
        {
            ope.Borrar(id);
            Console.WriteLine("Se borro con exito....");

        }

    }
}
