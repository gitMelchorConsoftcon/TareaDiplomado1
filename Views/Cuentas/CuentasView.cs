using System;
using TareaDiplomado.Controller;
using TareaDiplomado.Views.Movimientos;

namespace TareaDiplomado.Views.Cuentas
{
    public class CuentasView
    {
        public void Principal()
        {
            int opcion;
            CuentasController con = new CuentasController();
            do
            {
                int id;
                Utilerias.LipiarPantalla();

                Utilerias.Escribir("Catalogo de cuentas", 10, 1);


                con.Reporte();

                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Nuevo();
                        break;
                    case 2:
                        Utilerias.Escribir("¿Cual es el id de la cuenta que quieres Borrar? ", 10, Console.CursorTop + 2);
                        id= int.Parse( Console.ReadLine());
                        Borrar(id);
                        break;
                    case 3:
                        Utilerias.Escribir("¿Cual es el id de la cuenta que quieres modificar? ", 10, Console.CursorTop + 2);
                         id = int.Parse(Console.ReadLine());
                        Modificar(id);
                        break;
                    case 4:
                        Utilerias.Escribir("¿Cual es el id de la cuenta que quieres ver los movimientos? ", 10, Console.CursorTop + 2);
                        id = int.Parse(Console.ReadLine());
                        MovimientosView mov = new MovimientosView();
                        mov.MovimientoCuenta(id);
                        break;

                    default:
                        Utilerias.Escribir("Opcion no valida", 10, 12);
                        break;
                }
            }
            while (opcion != 5);
        }

        private void Borrar(int id)
        {
            Utilerias.LipiarPantalla();
            Utilerias.Escribir("Borrar Registro de cuentas", 10, 1);
            CuentasController controller = new CuentasController();

            controller.Buscar(id);

        }

        public void Modificar(int id )
        {
            Utilerias.LipiarPantalla();
            Utilerias.Escribir("Modificar Registro de cuentas", 10, 1);
            CuentasController controller = new CuentasController();

           //if ( controller.Buscar(id))
           // {
                int ultimorow = Console.CursorTop;
                Utilerias.Escribir("Nombre :", 10, ultimorow + 2);
                Utilerias.Escribir("Correo :", 10, ultimorow + 3);
                Utilerias.Escribir("Fecha  :", 10, ultimorow + 4);


                string nombre = Utilerias.Leer(19, ultimorow+2);
                string correo = Utilerias.Leer(19, ultimorow+3);
                DateTime fecha = DateTime.Parse(Utilerias.Leer(19, ultimorow+4));

                Utilerias.Escribir("Desea Guardar el registo Y/N :", 10, ultimorow+6);
                string opcion = Console.ReadLine();
                if (opcion == "Y" || opcion == "y")
                {
                    TareaDiplomado.Models.Cuentas cuentas = new TareaDiplomado.Models.Cuentas(nombre, correo, fecha);
                    cuentas.id = id;

                    controller.Modificar(cuentas);
                }
            //}

           

        }

        public void Nuevo()
        {
            Utilerias.LipiarPantalla();
            Utilerias.Escribir("Nuevo Registro de cuentas", 10, 1);

            Utilerias.Escribir("Nombre :", 10, 3);
            Utilerias.Escribir("Correo :", 10, 4);
            Utilerias.Escribir("Fecha  :", 10, 5);


            string nombre= Utilerias.Leer(19, 3);
            string correo = Utilerias.Leer(19, 4);
            DateTime fecha = DateTime.Parse( Utilerias.Leer(19, 5));

            Utilerias.Escribir("Desea Guardar el registo Y/N :", 10, 7);
            string opcion = Console.ReadLine();
            if (opcion=="Y" || opcion== "y")
            {
                TareaDiplomado.Models.Cuentas cuentas = new TareaDiplomado.Models.Cuentas(nombre, correo, fecha);
                CuentasController controller = new CuentasController();
                controller.Nuevo(cuentas);
            }




        }
    }
}
