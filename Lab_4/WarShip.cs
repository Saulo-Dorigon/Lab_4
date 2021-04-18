using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4
{
    class WarShip : Nave, iNave
    {

        public WarShip(string nome, int nivelCombustivel, int energia, int velocidade, int posiçãoX, int posiçãoY, bool Inimigo)
        {
            Nome = nome;
            NivelCombustivel = nivelCombustivel;
            Energia = energia;
            Velocidade = velocidade;
            Posição = new int[2] { posiçãoX, posiçãoY };
            Inimigo = Inimigo;
            Vivo = true;
        }

        public void Atirar()
        {

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
            return $"Energia restante de {Nome} = {Energia}";
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
