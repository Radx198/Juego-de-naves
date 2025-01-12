using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_juego_de_naves
{
    internal class Game // Métodos para iniciar el juego y cambiar de escena
    {
        Point interseccionInicio = new Point(6, 5);
        Point interseccionLimite = new Point(120, 30);
        

        public void Init()
        {




            Player jugador = new Player(100, 1, new Point(interseccionLimite.X / 2, interseccionLimite.Y / 2), new Point(interseccionLimite.X - interseccionInicio.X, interseccionLimite.Y - interseccionInicio.Y), new Point(interseccionInicio.X, interseccionInicio.Y), 100);
            Thread t2 = new Thread(jugador.EjecutarBalas);
            Thread t = new Thread(jugador.Mover);

            UIGame pantalla = new UIGame(new Point(6, 5), new Point(120, 30), ConsoleColor.Black, ConsoleColor.DarkRed, jugador);
            pantalla.inicio();




            t.Start();
           
            t2.Start();
            
            while (true)
            {


            }

        }
    }
}
