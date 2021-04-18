using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4
{
    class Projetil
    {

        public int ForcaTiro { get; private set; }
        public int VeldeTiro { get; private set; }
        public int[] Posição { get; private set; }

        public Projetil(int forcaTiro, int veldeTiro, int posiçãoX, int posiçãoY)
        {
            VeldeTiro = veldeTiro;
            ForcaTiro = forcaTiro;
            Posição = new int[2] { posiçãoX, posiçãoY };
        }

        public void MovimentaçãoTiro()
        {
            Posição[1] += VeldeTiro;
        }
    }
}
