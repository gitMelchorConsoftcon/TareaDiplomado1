using System;
using TareaDiplomado.Controller;
using TareaDiplomado.Views.Cuentas;

namespace TareaDiplomado.Views.Home
{
    public class Principal
    {
        
        public void Menu()
        {
            int opcion ;

            do
            {
                Utilerias.LipiarPantalla();

                Utilerias.Escribir("Menu principal", 10, 1);
                Utilerias.Escribir("Cuentas .........1", 10, 3);

                Utilerias.Escribir("Salir............2", 10, 5);
                Utilerias.Escribir("Opcion :", 10, 6);
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        CuentasView view = new CuentasView();
                        view.Principal();
                        break;

                    case 3:
                        break;
                    default:
                        Utilerias.Escribir("Opcion no valida", 10, 12);
                        break;
                }


            }
            while (opcion !=2);
        }
   
    
       
    
    }
}
