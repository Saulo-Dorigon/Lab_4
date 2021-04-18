using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4
{
    class CargoShip : Nave, iNave
    {

        public CargoShip(string nome, int nivelCombustivel, int energia, int velocidade, int posiçãoX, int posiçãoY)
        {
            Nome = nome;
            NivelCombustivel = nivelCombustivel;
            Energia = energia;
            Velocidade = velocidade;
            Posição = new int[2] { posiçãoX, posiçãoY };

            Vivo = true;
        }

        public void MoverCima()
        {
            Posição[0] -= Velocidade;
        }
        public void MoverBaixo()
        {
            Posição[0] += Velocidade;
        }
        public void MoverDireita()
        {
            Posição[1] += Velocidade;
        }
        public void MoverEsquerda()
        {
            Posição[1] -= Velocidade;
        }
        public string VerificarDanos()
        {
            throw new NotImplementedException();
        }
        public void LimitarEspaço()
        {
            for (int i = 0; i < Posição.Length; i++)
            {
                if (Posição[i] < 1)
                {
                    Posição[i] = 1;
                }
                if (Posição[i] > 20)
                {
                    Posição[i] = 20;
                }
            }
        }
    }
}
