using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_juego_de_naves
{
    internal class Button
    {
        private ConsoleColor ColorDeFuente;
        private string texto;
        private UIType interfaz;
        private Point cursor;
        private string texturaCursor;
        public bool activarCursor;
       
        public string Texto
        {
            get { return texto; }
        }
        public UIType Interfaz
        {
            get { return interfaz; }
        }




        public Button(ConsoleColor colorDeFuente, string texto, UIType interfaz, Point cursor, bool activarCursor)
        {
            this.ColorDeFuente = colorDeFuente;
            this.texto = texto;
            this.interfaz = interfaz;
            this.cursor = cursor;
            this.activarCursor = activarCursor;

            Console.ForegroundColor = ColorDeFuente;
            texturaCursor = "o";
     
            MostrarBoton();
        }

        public void MostrarBoton()
        {
            Console.SetCursorPosition(cursor.X, cursor.Y);

            if (activarCursor)
                Console.Write("{0} {1}", texturaCursor, texto.ToUpper());
            
            else Console.Write("  {0}", texto.ToUpper());
        }





    }
}
