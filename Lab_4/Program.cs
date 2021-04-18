using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4
{
    class Program
    {
        static void Main(string[] args)
        {

            WarShip NavePlayer = new WarShip("Bob Nelson", 100, 30, 1, 10, 10, false);
            CargoShip NavePlayerCena2 = new CargoShip("Bob Nelson", 200, 30, 1, 10, 10);
            WarShip NaveInimigo1 = new WarShip("inimigoTeste1", 100, 1, 1, 15, 20, true);
            WarShip NaveInimigo2 = new WarShip("inimigoTeste2", 100, 1, 1, 10, 20, true);
            WarShip NaveInimigo3 = new WarShip("inimigoTeste3", 100, 1, 1, 5, 20, true);
            WarShip [] NavesEmJogo = new Warship[] { NavePlayer, NaveInimigo1, NaveInimigo2, NaveInimigo3 };
            int cena = 1;
            int delayTiro = 1;
            int delayMeteoros = 1;
            bool verificarDanos = false;
            bool atirou = false;
            int ação = 0;
            List<Projetil> ListaTiros = new List<Projetil>();
            List<Meteoro> ListaMeteoros = new List<Meteoro>();
            ListaMeteoros.Add(new Meteoro(10, 0, NavePlayer.Posição[1] - 1));
            string[,] Campo;
            Campo = new string[20, 20];
            while (NavePlayer.Energia > 0)
            {

                DelimitarEspaço();
                if (atirou)
                {
                    AtirarPlayer();
                    atirou = false;
                }
                Colisoes();
                DeterminarEspaços();
                DesenharEspaço();
                FimDeJogo();
                foreach (Projetil elemento in ListaTiros)
                {
                    elemento.MovimentaçãoTiro();
                }
                foreach (Meteoro elementoMeteoro in ListaMeteoros)
                {
                    elementoMeteoro.Posição[0] += 1;
                }
                ação = int.Parse(Console.ReadLine());

                switch (ação)
                {
                    case 5:
                        if (cena == 1)
                            atirou = true;
                        break;
                    case 0:
                        verificarDanos = true;
                        break;
                    case 8:
                        NavePlayer.MoverCima();
                        NavePlayer.LimitarEspaço();
                        break;
                    case 2:
                        NavePlayer.MoverBaixo();
                        NavePlayer.LimitarEspaço();
                        break;
                    case 6:
                        NavePlayer.MoverDireita();
                        NavePlayer.LimitarEspaço();
                        break;
                    case 4:
                        NavePlayer.MoverEsquerda();
                        NavePlayer.LimitarEspaço();
                        break;
                }
                AtirarInimigo();
                CriarMeteoros();
                Console.Clear();

            }

            while (NavePlayer.Energia > 0)
            {
            }


            Console.Read();

            void DesenharEspaço()
            {
                for (int i = 0; i < 20; i++)
                {
                    for (int j = 0; j < 20; j++)
                    {
                        Console.Write(Campo[i, j]);
                    }
                    Console.WriteLine("");
                }
                if (verificarDanos == true)
                {
                    Console.WriteLine($"{NavePlayer.VerificarDanos()}\n(5)Ataque\n(0)Dano\n(8)Cima\n(2)Baixo\n" +
                        "(6)Direira\n(4)Esquerda\n");
                    verificarDanos = false;
                }
                else
                    Console.WriteLine("\n(5)Ataque\n(0)Dano\n(8)Cima\n(2)Bbaixo\n" +
                        "(6)Direita\n(4)Esquerda\n");

            }
            void DelimitarEspaço()
            {
                for (int i = 0; i < 20; i++)
                {
                    for (int j = 0; j < 20; j++)
                    {
                        Campo[i, j] = "    ";
                    }
                }
            }
            void DeterminarEspaços()
            {
                foreach (Warship Naves in NavesEmJogo)
                {
                    for (int i = 0; i < 20; i++)
                    {
                        for (int j = 0; j < 20; j++)
                        {
                            if (Naves.Posição[0] == i + 1 && Naves.Posição[1] == j + 1)
                            {
                                if (Naves.EInimigo == true && Naves.Vivo == true)
                                {
                                    Campo[i, j] = "<=E   ";
                                }
                                else if (Naves.EInimigo == false && Naves.Vivo == true)
                                {
                                    Campo[i, j] = "B=>   ";
                                }
                                else
                                {

                                }
                            }
                            if (ListaTiros.Count > 0)
                            {
                                foreach (Projetil elemento in ListaTiros)
                                {
                                    if (elemento.Posição[0] == i && elemento.Posição[1] == j)
                                    {
                                        if (elemento.VeldeTiro > 0)
                                        {
                                            Campo[i, j] = "*   ";
                                        }
                                        else
                                        {
                                            Campo[i, j] = "-   ";
                                        }
                                    }
                                }
                            }
                            if (ListaMeteoros.Count > 0)
                            {
                                foreach (Meteoro elementoAsteroide in ListaMeteoros)
                                {
                                    if (elementoAsteroide.Posição[0] == i && elementoAsteroide.Posição[1] == j)
                                    {
                                        Campo[i, j] = "O   ";
                                    }
                                }
                            }
                        }
                    }
                }
            }
            void AtirarPlayer()
            {
                atirou = true;
                ListaTiros.Add(new Projetil(10, 1, NavePlayer.Posição[0] - 1, NavePlayer.Posição[1]));
            }
            void AtirarInimigo()
            {
                foreach (Nave elementoNave in NavesEmJogo)
                {
                    if (elementoNave.EInimigo && elementoNave.Vivo && delayTiro >= 5)
                    {
                        ListaTiros.Add(new Projetil(10, -1, elementoNave.Posição[0] - 1, elementoNave.Posição[1] - 2));
                        delayTiro = 0;
                    }
                    delayTiro += 1;
                }
            }
            void Colisoes()
            {
                foreach (Projetil elementoTiro in ListaTiros)
                {
                    foreach (Nave elementoNave in NavesEmJogo)
                        if (elementoTiro.Posição[0] + 1 == elementoNave.Posição[0] && elementoTiro.Posição[1] + 1 == elementoNave.Posição[1])
                        {
                            elementoNave.LevarDano(elementoTiro.ForcaTiro);
                        }
                }
                foreach (Meteoro elementoMeteoro in ListaMeteoros)
                {
                    if (elementoMeteoro.Posição[0] + 1 == NavePlayer.Posição[0] && elementoMeteoro.Posição[1] + 1 == NavePlayer.Posição[1])
                    {
                        NavePlayer.LevarDano(elementoMeteoro.Dano);
                    }
                }
            }
            void FimDeJogo()
            {
                if (NavePlayer.Vivo == false || NavePlayer.NivelCombustivel <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("A carga foi perdida. Fim de Jogo.");
                    Console.ReadLine();
                    Environment.Exit(0);
                }
                else if (NaveInimigo1.Vivo == false &&
                    NaveInimigo2.Vivo == false &&
                    NaveInimigo3.Vivo == false)
                {
                    Console.Clear();
                    Console.WriteLine("Bob Nelson passou pela armadilha dos piratas do espaço e entregou a carga. Fim de Jogo.");
                    Console.ReadLine();
                    Environment.Exit(0);
                }
                else
                {
                    return;
                }
            }
            void CriarMeteoros()
            {
                if (delayMeteoros >= 5)
                {
                    ListaMeteoros.Add(new Meteoro(10, 0, NavePlayer.Posição[1] - 1));
                    delayMeteoros = 0;
                }
                else
                {
                    delayMeteoros += 1;
                }

            }
        }
    }
}