using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4
{
    interface iNave
    {

        void MoverCima();
        void MoverBaixo();
        void MoverDireita();
        void MoverEsquerda();
        string VerificarDanos();
        void LevarDano(int dano);
    }
}
