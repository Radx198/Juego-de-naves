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
        protected int time;
        public Bala(Point posicionSpawn, Point interseccionInicio, Point interseccionLimite)
        {
            posicionActual = posicionSpawn;
            this.interseccionInicio = interseccionInicio;
            this.interseccionLimite = interseccionLimite;
            time = 100;
        }



        public abstract void MoverBala();

        protected abstract bool DetectarColisiones();

        protected abstract bool DetectarLimitesDelMapa();


        protected abstract void DibujarBala();
        protected abstract void EliminarDibujoBala();
    }
}
