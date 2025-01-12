using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
namespace Proyecto_juego_de_naves
{
    enum ModosDeInterfaz {Jugar, inicio, salir};
    internal class UIGame //Cambiará de interfaces graficas, junto a su lógica
    {


        private Point interseccionInicio;
        private Point interseccionLimite;



        private Player jugador;
        private ConsoleColor colorDeFondo;
        private ConsoleColor colorDeFuente;
        private bool juegoCompletado;




        public UIGame( Point interseccionInicio, Point interseccionLimite, ConsoleColor colorDeFondo, ConsoleColor colorDeFuente, Player jugador)
        {
            this.interseccionInicio= interseccionInicio; 
            this.interseccionLimite = interseccionLimite;


            this.colorDeFondo = colorDeFondo;
            this.colorDeFuente = colorDeFuente;
            juegoCompletado = false;

            this.jugador = jugador;


            Console.BackgroundColor = colorDeFondo;
            Console.ForegroundColor = colorDeFuente;
            Console.WindowHeight = interseccionLimite.Y;
            Console.WindowWidth = interseccionLimite.X;
            Console.CursorVisible = false;  

        }
        
        public void inicio() //Dibuja una interfaz de inicio del programa
            //incluyendo un cuadro y bótones
        { 
            marco();
            string titulo = "BIENVENIDO";
            int posicionTituloX = (interseccionLimite.X / 2) - titulo.Length / 2;
            int posicionTituloY = (interseccionLimite.Y / 2) - 3;

            Console.SetCursorPosition(posicionTituloX, posicionTituloY);
            Console.Write(titulo);
           
            
            List<Button> buttons = new List<Button>();
            Button jugar = new Button(colorDeFuente,"Jugar",UIType.InitGame,new Point(posicionTituloX,posicionTituloY +4), false);
            Button salir = new Button(colorDeFuente, "salir", UIType.Exit, new Point(posicionTituloX, posicionTituloY + 6), false);
           
            buttons.Add(jugar);
            buttons.Add(salir);

            Button botonSeleccionado = seleccionarBoton(buttons); //Almacena el bóton seleccionado por el jugador
            EjecutarBoton(botonSeleccionado);//ejecuta dicho bóton




        }
        public Button seleccionarBoton(List<Button> button) 
         //Permite mostrar un item al lado del bóton que si le da a enter se seleccionaria
                                                            
        {
            Button botonActual = button[0];

            button[0].activarCursor = true;
            button[0].MostrarBoton();

            bool botonSeleccionado = false;
            while(!botonSeleccionado)
            {

                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.Enter:
                        {
                            botonSeleccionado = true;
                            break;
                        }
                    case ConsoleKey.UpArrow:
                        {
                            button[button.IndexOf(botonActual)].activarCursor = false;
                            button[button.IndexOf(botonActual)].MostrarBoton();

                            botonActual = button[0];
                        
                            button[0].activarCursor = true;
                            button[0].MostrarBoton();
                            break;
                        }
                    case ConsoleKey.DownArrow:
                        {
                            button[button.IndexOf(botonActual)].activarCursor = false;
                            button[button.IndexOf(botonActual)].MostrarBoton();

                            botonActual = button[1];
                            button[1].activarCursor = true;
                            button[1].MostrarBoton();
                            break;
                        }
                }
            }
            return botonActual;
        }
        

        public void EjecutarBoton(Button boton)//Ejecuta el bóton pasado como parámetro
        {
            Console.Clear();
            switch (boton.Interfaz)
            {
                case UIType.Lobby:
                    inicio();
                    break;
                case UIType.InitGame:
                    InitGame();
                    
                    //Player jugador = new Player(100, 1, "Luca", new Point(interseccionLimite.X / 2, interseccionLimite.Y / 2), new Point(interseccionLimite.X - interseccionInicio.X, interseccionLimite.Y - interseccionInicio.Y), new Point(interseccionInicio.X, interseccionInicio.Y), 100);
                    //Thread t = new Thread(jugador.Mover);
                    //t.Start();
                    //Thread t2 = new Thread(jugador.EjecutarBalas);
                    //t2.Start();
                    //while (true)
                    // {


                    //}
                    break;
                case UIType.GameOver:
                    break;
                case UIType.Exit:
                    break;
            }
        }


        public void InitGame()
        {
            jugador.CrearNave();

            marco();

            EstadisticasJugador();


        }

        private void EstadisticasJugador()
        {

            Console.SetCursorPosition(interseccionInicio.X, interseccionInicio.Y - 2);
            Console.Write("Vida: {0}",jugador.Vida);

            Console.SetCursorPosition(interseccionInicio.X + 9 + 2, interseccionInicio.Y - 2);
            Console.Write("Sobrecarga: {0}", jugador.SobreCargar);

            Console.SetCursorPosition(interseccionInicio.X + 9 + 2 + 15 + 2, interseccionInicio.Y - 2);
            
                if (jugador.BalaEspecial)
                Console.ForegroundColor = ConsoleColor.Green;
            else Console.ForegroundColor = ConsoleColor.Red;

            Console.Write("ATAQUE ESPECIAL");
            Console.ForegroundColor = colorDeFuente;
        }









        public void marco()
        {
            marcoX();
            marcoY();
            Console.SetCursorPosition(5, 4);
            Console.Write("╔");
            Console.SetCursorPosition(interseccionLimite.X-5, 4);
            Console.Write("╗");
            Console.SetCursorPosition(5, interseccionLimite.Y-4);
            Console.Write("╚");
            Console.SetCursorPosition(interseccionLimite.X - 5, interseccionLimite.Y - 4);
            Console.Write("╝");
        }
        private void marcoX()
        {

            for (int i = interseccionInicio.X; i < interseccionLimite.X - 5; i++)
            {
                Console.SetCursorPosition(i, 4);
                Console.Write("═");
            }
            for (int i = interseccionInicio.X; i < interseccionLimite.X - 5; i++)
            {
                Console.SetCursorPosition(i, interseccionLimite.Y- 4);
                Console.Write("═");
            }
        }
        private void marcoY()
        {
            for (int i = interseccionInicio.Y; i < interseccionLimite.Y - 4; i++)
            {
                Console.SetCursorPosition(5, i);
                Console.Write("║");
            }
            for (int i = interseccionInicio.Y; i < interseccionLimite.Y - 4; i++)
            {
                Console.SetCursorPosition(interseccionLimite.X - 5, i);
                Console.Write("║");
            }


        }

    }
}
