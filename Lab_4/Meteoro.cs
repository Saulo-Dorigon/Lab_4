using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4
{
    class Meteoro
    {

        public int Dano { get; private set; }
        public int[] Posição { get; private set; }

        public Meteoro(int dano, int posiçãoX, int posiçãoY)
        {
            Dano = dano;
            Posição = new int[2] { posiçãoX, posiçãoY };
        }
    }
}
