﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_juego_de_naves
{
    internal class BalaNormal : Bala
    {
        private int daño;
        private int velocidad;
        protected Point posicionActual;
        protected Point interseccionLimite;
        protected Point interseccionInicio;

        public BalaNormal(Point posicionSpawn, Point interseccionInicio, Point interseccionLimite) : base(posicionSpawn, interseccionInicio, interseccionLimite)
        {
            posicionActual = posicionSpawn;
            this.interseccionInicio = interseccionInicio;
            this.interseccionLimite = interseccionLimite;

            daño = 15;
            velocidad = 15;
    
        }



        public override bool MoverBala() //Mueve la bala hacia arriba
            //si se encuentra de los limites o choco con algo desaparece
        {

            if (DetectarLimitesDelMapa() && DetectarColisiones())
            {
                EliminarDibujoBala();
                posicionActual.Y -= 1;
                DibujarBala();
                Thread.Sleep(25);
                return true;
            }
            EliminarDibujoBala();
            return false;
            
        }

        protected override bool DetectarColisiones()
        {//Si toca un enemigo
            return true;
        }

        protected override bool DetectarLimitesDelMapa()
        {//si su futura posicion está fuera de los limites retorna false
            if (posicionActual.Y - 1 >= interseccionInicio.Y)
                return true;
            return false;
        }
        protected override void DibujarBala()
        {
            Console.SetCursorPosition(posicionActual.X, posicionActual.Y);
            Console.Write("o");
        }

        protected override void EliminarDibujoBala()
        {
            Console.SetCursorPosition(posicionActual.X, posicionActual.Y);
            Console.Write(" ");
        }
    }
}
