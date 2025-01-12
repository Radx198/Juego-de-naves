using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_juego_de_naves
{
    public enum UIType //Tipos de interfaces graficas.
    {
        InitGame, //De gameplay.
        Lobby, //De presentación al abrir el juego.
        Exit, //Cierra el juego.
        GameOver //Cuando muere el jugador
    }
}
