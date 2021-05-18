using System;
using TareaDiplomado.Controller;

namespace TareaDiplomado.Views.Movimientos
{
    public class MovimientosView
    {
        MovimientoController movs = new MovimientoController();

        public void MovimientoCuenta (int idCuenta)
        {
            int opcion;
            do
            {
                var c = movs.BuscarCuenta(idCuenta);

                Utilerias.LipiarPantalla();
                Utilerias.Escribir($"Movimientos de la cuenta : {idCuenta}", 10, 1);
                Utilerias.Escribir($"Nombre Cuenta : {c.nombre}", 10, 2);

                ReporteCuentas(idCuenta);

                opcion = int.Parse(Console.ReadLine());
                String tm = "";
                int id = 0;
                switch (opcion)
                {
                    case 1:
                        Utilerias.Escribir("¿Que tipo movimiento desear realizar D-Deposito, R-Retiro? ", 10, Console.CursorTop + 2);
                        tm = Console.ReadLine();
                        Nuevo(tm, idCuenta);
                        break;
                    case 2:
                        Utilerias.Escribir("¿Cual es el id del Movimiento que quieres Borrar? ", 10, Console.CursorTop + 2);
                        id = int.Parse(Console.ReadLine());
                        Borrar(id);
                        break;
                    case 3:
                        Utilerias.Escribir("¿Cual es el id del movimiento que quieres modificar? ", 10, Console.CursorTop + 2);
                        id = int.Parse(Console.ReadLine());
                        Modificar(id,idCuenta);
                        break;
                   

                    default:
                        Utilerias.Escribir("Opcion no valida", 10, 12);
                        break;
                }





            } while (opcion != 4);
            

        }

        private void Modificar(int id,int idCuenta)
        {
            Utilerias.LipiarPantalla();

            var c = movs.BuscarCuenta(idCuenta);

            Utilerias.LipiarPantalla();
            Utilerias.Escribir($"Modificar Movimientos de la cuenta : {idCuenta}", 10, 1);
            Utilerias.Escribir($"Nombre Cuenta : {c.nombre}", 10, 2);

            int ultimorow = Console.CursorTop;
            Utilerias.Escribir("Fecha :", 10, ultimorow + 2);
            Utilerias.Escribir("Cantidad :", 10, ultimorow + 3);
       
            var obj = movs.Buscar(id);

            
            DateTime fecha = DateTime.Parse(Utilerias.Leer(22, ultimorow + 2));
            decimal cantidad = decimal.Parse(Utilerias.Leer(22, ultimorow + 3));

            Utilerias.Escribir("Desea Guardar el registo Y/N :", 10, ultimorow + 6);
            string opcion = Console.ReadLine();
            if (opcion == "Y" || opcion == "y")
            {

                obj.cantidad = cantidad;
                obj.fecha = fecha;

                movs.Modificar(obj);
            }
           
        }

        private void Borrar(int id)
        {
            Utilerias.LipiarPantalla();
            Utilerias.Escribir("Borrar Registro de movimientos", 10, 1);
            movs.Borrar(id);


        }

        private void Nuevo(string tm, int idCuenta)
        {

           if (tm=="R" || tm == "r" || tm == "D" || tm == "d")
            {
                Utilerias.LipiarPantalla();

                var c = movs.BuscarCuenta(idCuenta);

                Utilerias.LipiarPantalla();
                Utilerias.Escribir($"Nuevo Movimientos de la cuenta : {idCuenta}", 10, 1);
                Utilerias.Escribir($"Nombre Cuenta : {c.nombre}", 10, 2);

                Utilerias.Escribir("Fecha :", 10, 4);
                Utilerias.Escribir("Cantidad :", 10, 5);


 
                DateTime fecha = DateTime.Parse(Utilerias.Leer(22, 4));
                decimal cantidad = decimal.Parse(Utilerias.Leer(22, 5));

                Utilerias.Escribir("Desea Guardar el registo Y/N :", 10, 7);
                string opcion = Console.ReadLine();
                if (opcion == "Y" || opcion == "y")
                {
                    TareaDiplomado.Models.Movimientos obj = new TareaDiplomado.Models.Movimientos(idCuenta, fecha,tm.ToUpper(),cantidad);
                    MovimientoController controller = new MovimientoController();
                    controller.Nuevo(obj);
                }


            }
            else
            {
                Utilerias.Escribir("La opcion de movimiento es invalida",10,Console.CursorTop+2);
                Console.ReadKey();
            }
        }

        private async void ReporteCuentas (int idCuenta)
        {
            int x = 0;
            decimal saldo = 0;
            foreach(var item in await movs.Reporte(idCuenta))
            {

                Utilerias.Escribir($"{item.id} - {item.fecha.ToShortDateString()}  {item.tipo}    {item.cantidad} ", 10, 5 + x);
                if (item.tipo == "D")
                    saldo += item.cantidad;
                else
                    saldo -= item.cantidad;
                
                x++;
            }
            Utilerias.Escribir($"Saldo de la cuenta : {saldo}", 10, 5 + x);


            Utilerias.Escribir("Nuevo .........1", 10, Console.CursorTop + 2);
            Utilerias.Escribir("Borrar ........2", 10, Console.CursorTop + 1);
            Utilerias.Escribir("Modificar .....3", 10, Console.CursorTop + 1);
            Utilerias.Escribir("Salir .........4", 10, Console.CursorTop + 1);
            Utilerias.Escribir("Opcion :", 10, Console.CursorTop + 1);
        }

    }
}
