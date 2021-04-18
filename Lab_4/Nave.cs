using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4
{
    abstract class Nave
    {

        public string Nome { get; protected set; }
        public int NivelCombustivel { get; protected set; }
        public int Energia { get; protected set; }
        public int Velocidade { get; protected set; }
        public int[] Posição { get; protected set; }
        public bool Vivo { get; protected set; }
        public bool Inimigo { get; protected set; }
        public void Morte()
        {
            Vivo = false;
        }
        public void LevarDano(int dano)
        {
            Energia -= dano;
            if (Energia <= 1)
            {
                Morte();
            }
        }
    }
}