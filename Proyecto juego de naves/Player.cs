using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;
namespace Proyecto_juego_de_naves
{
    enum Direccion { arriba, abajo, izquierda, derecha };
    internal partial class Player
    {
        private int vida;
        private int velocidad;
        private string nombre;
        private Point posicionActual;
        private int sobrecarga;
        private Point interseccionLimite;
        private Point interseccionInicio;

        private List<BalaNormal> balasNormales;
        public Point PosicionActual
        {
            get { return posicionActual; }
        }


        public Player(int vida, int velocidad, string nombre, Point posicionSpawn, Point interseccionLimite, Point interseccionInicio, int sobrecarga)
        {
            this.vida = vida;
            this.velocidad = velocidad;
            this.nombre = nombre;

            posicionActual = posicionSpawn;
            this.interseccionLimite = interseccionLimite;
            this.interseccionInicio = interseccionInicio;


            balasNormales = new List<BalaNormal>();
            this.sobrecarga = sobrecarga;
            CrearNave();
        }
        public void CrearNave()
        {
            Console.SetCursorPosition(posicionActual.X, posicionActual.Y);
            Console.Write("    --    ");
            Console.SetCursorPosition(posicionActual.X, posicionActual.Y + 1);
            Console.Write(@"   /  \   ");
            Console.SetCursorPosition(posicionActual.X, posicionActual.Y + 2);
            Console.Write("  |-  -|  ");
            Console.SetCursorPosition(posicionActual.X, posicionActual.Y + 3);
            Console.Write("|-|----|-|");
        }
        public void Mover()
        {
            ConsoleKeyInfo key = Console.ReadKey(true);



            

            switch (key.Key)
            {
                case ConsoleKey.W:
                    EjecutarMovimiento(Direccion.arriba);

                    break;
                case ConsoleKey.S:
                    EjecutarMovimiento(Direccion.abajo);

                    break;
                case ConsoleKey.A:
                    EjecutarMovimiento(Direccion.izquierda);
                    
                    break;
                case ConsoleKey.D:
                    EjecutarMovimiento(Direccion.derecha);
                    
                    break;
                case ConsoleKey.E:
                    BalaNormal balaN = new BalaNormal(new Point(posicionActual.X, posicionActual.Y - 2), interseccionInicio, interseccionLimite);
                    balasNormales.Add(balaN);
                    EjecutarBala();
                    break;

            }

            

        }
        public void EjecutarBala()
        {
            Thread t = new Thread(balasNormales[balasNormales.Count - 1].MoverBala);
            t.Start();
        }

    }
    
    internal partial class Player
    {

        private void EliminarNave()
        {
            Console.SetCursorPosition(posicionActual.X, posicionActual.Y);
            Console.Write("          ");
            Console.SetCursorPosition(posicionActual.X, posicionActual.Y + 1);
            Console.Write("          ");
            Console.SetCursorPosition(posicionActual.X, posicionActual.Y + 2);
            Console.Write("          ");
            Console.SetCursorPosition(posicionActual.X, posicionActual.Y + 3);
            Console.Write("          ");
        }


        private void EjecutarMovimiento(Direccion dir)
        {
            EliminarNave();

            switch (dir)
            {
                case Direccion.arriba:
                    if (VerificarLimitesDeMovimiento(Direccion.arriba))
                        posicionActual.Y -= velocidad;

                    break;
                case Direccion.abajo:
                    if (VerificarLimitesDeMovimiento(Direccion.abajo))
                        posicionActual.Y += velocidad;

                    break;
                case Direccion.izquierda:
                    if (VerificarLimitesDeMovimiento(Direccion.izquierda))
                        posicionActual.X -= velocidad;

                    break;
                case Direccion.derecha:
                    if (VerificarLimitesDeMovimiento(Direccion.derecha))
                        posicionActual.X += velocidad;

                    break;

            }
            CrearNave();
        }
        private bool VerificarLimitesDeMovimiento(Direccion dir)
        {
            switch (dir)
            {
                case Direccion.arriba:
                    if (posicionActual.Y > interseccionInicio.Y)
                        return true;

                    break;
                case Direccion.abajo:
                    if (posicionActual.Y + 3 < interseccionLimite.Y)
                        return true;

                    break;
                case Direccion.izquierda:
                    if (posicionActual.X > interseccionInicio.X)
                    {

                        return true;
                    }

                    break;
                case Direccion.derecha:
                    if (posicionActual.X + 9 < interseccionLimite.X)
                        return true;

                    break;

                default: return false;
            }
            return false;
        }
    }
}
