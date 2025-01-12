using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_juego_de_naves
{
    internal abstract class Bala
    {
        protected int daño;
        protected int velocidad;
        protected Point posicionActual;
        protected Point interseccionLimite;
        protected Point interseccionInicio;
        public Bala(Point posicionSpawn, Point interseccionInicio, Point interseccionLimite)
        {
            posicionActual = posicionSpawn;
            this.interseccionInicio = interseccionInicio;
            this.interseccionLimite = interseccionLimite;
        }



        public abstract bool MoverBala(); //Trayectoria de la bala

        protected abstract bool DetectarColisiones();//detecta enemigos


        protected abstract bool DetectarLimitesDelMapa();//deteca los limites del mapa


        protected abstract void DibujarBala();
        protected abstract void EliminarDibujoBala();
    }
}
