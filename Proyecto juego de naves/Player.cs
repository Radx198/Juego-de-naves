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
    internal partial class Player //La nave en sí, podra moverse y disparar, entre otras cosas
    {
        private int vida;
        private int velocidad;
        private Point posicionActual;
        private int sobreCarga;
        private Point interseccionLimite;
        private Point interseccionInicio;
        private bool balaEspecial;

        private object lockBalas = new object(); //usado para usar lock(){}

        private List<BalaNormal> balasNormales; //lista de balas que estan en pantalla

        public Point PosicionActual
        {
            get { return posicionActual; }
        }
        public int Vida
        {
            get { return vida; }
        }
        public int SobreCargar
        {
            set { sobreCarga = value; }
            get { return sobreCarga; }
        }

        public bool BalaEspecial
        {
            get { return balaEspecial; }
        }
        public Player(int vida, int velocidad, Point posicionSpawn, Point interseccionLimite, Point interseccionInicio, int sobreCarga)
        {

            this.vida = vida;
            this.velocidad = velocidad;


            posicionActual = posicionSpawn;
            this.interseccionLimite = interseccionLimite;
            this.interseccionInicio = interseccionInicio;


            balaEspecial = false;
            balasNormales = new List<BalaNormal>();
            this.sobreCarga = sobreCarga;



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
        public void Mover()//Método en el que espera una entrada por teclado
            //y si es la esperada la ejecuta.
        {
            while (true)
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
                        lock (lockBalas)
                        {
                            BalaNormal balaN = new BalaNormal(new Point(posicionActual.X, posicionActual.Y + 2), interseccionInicio, interseccionLimite);
                            balasNormales.Add(balaN);
                            
                        }
                        break;

                }
            }
            

        }
        public void EjecutarBalas()//Si hay balas en la lista 
            //con un for las mueve una a una hasta que no 
        {
            List<BalaNormal> eliminar = new List<BalaNormal>();
            while (true)
            {
                
                lock (lockBalas)
                { 

                    for (int i = 0; i < balasNormales.Count; i++)
                    {
                        if (!balasNormales[i].MoverBala())
                        {
                            eliminar.Add(balasNormales[i]);
                        }
                    }
                    for (int i = 0; i < eliminar.Count; i++)
                        balasNormales.Remove(eliminar[i]);
                }
                Thread.Sleep(50);
                eliminar.Clear();
            }
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


        private void EjecutarMovimiento(Direccion dir) //Ejecuta el movimiento de la nave
            //si esta dentro de los limites de movimiento.
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
            }
            return false;
        }
    }
}
