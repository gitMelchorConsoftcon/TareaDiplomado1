using System;

namespace TareaDiplomado
{
    public static  class Utilerias
    {

        public static void Escribir(string cadena, int x, int y)
        {
            try
            {
                Console.SetCursorPosition( x, y);
                Console.Write(cadena);
            }
            catch (ArgumentOutOfRangeException e)
            {
                LipiarPantalla();
                Console.WriteLine(e.Message);
            }
        }

        public static string Leer( int x, int y)
        {
            
                Console.SetCursorPosition(x, y);
            return Console.ReadLine();
           
        }

        public static void LipiarPantalla()
        {
            Console.Clear();
        }




    }
}
