using System.Drawing;
namespace Proyecto_juego_de_naves
{
    internal class Program
    {
        static void Main(string[] args)
        {

            UIGame pantalla = new UIGame(new Point(6,5), new Point(120, 30), ConsoleColor.Black, ConsoleColor.DarkRed);
            pantalla.inicio();

            Console.ReadLine();
        
        }
    }
}
