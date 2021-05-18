using System;
using TareaDiplomado.Views.Home;

namespace TareaDiplomado
{
    class Program
    {
        
       public static  void Main()
        {
            Principal p = new Principal();
            
            p.Menu();
            Utilerias.LipiarPantalla();
            Utilerias.Escribir("Cerrando sistema.....", 10, 20);
            Console.ReadKey();
        }
    }
}
