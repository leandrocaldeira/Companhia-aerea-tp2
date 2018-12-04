using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Trabalho2.Models;

namespace Trabalho2
{
    class Program
    {
        static void Main(string[] args)
        {
            int codigo;
            int opcao;

            Voo voo1 = new Voo(1, "SP/BH", "22/11/2018 19:00:30", 300);
            Voo voo2 = new Voo(2, "RJ/BH", "22/11/2018 19:00:30", 300);
            Voo voo3 = new Voo(3, "SP/RE", "22/11/2018 19:00:30", 300);

            // TESTE VOO1
            Passageiro passageiro1 = new Passageiro();
            passageiro1.nome = "Fulando";
            passageiro1.sobrenome = "de Tal";
            passageiro1.status = 1;
            voo1.adicionarPassageiro(passageiro1);

            Passageiro passageiro3 = new Passageiro();
            passageiro3.nome = "Leandro";
            passageiro3.sobrenome = "Caldeira";
            passageiro3.status = 1;
            voo1.adicionarPassageiro(passageiro3);

            // TESTE VOO2
            Passageiro passageiro2 = new Passageiro();
            passageiro2.nome = "Fulando de tal no Voo2";
            passageiro2.status = 1;
            voo2.adicionarPassageiro(passageiro2);

            /* 
             * Adicionar voos na companhia; 
             * Exibir voos cadastrados; 
             * Recuperar codigo do voos selecionado;
             */
            Companhia companhia = new Companhia();
            companhia.listaDeVoos.Add(voo1);
            companhia.listaDeVoos.Add(voo2);
            companhia.listaDeVoos.Add(voo3);
            Console.WriteLine("------- Companhia Aérea Cotocos -------");
            companhia.exibirVoos();
            Console.Write("Digite uma opção: ");
            codigo = Int32.Parse(Console.ReadLine());
            Console.Clear();

            /* Buscar voo aparti do codigo informado */
            var VooSelecionado = companhia.listaDeVoos.Where(voo => voo.codigo == codigo);
            string cpf;
            var cliente = new Passageiro() ;

            foreach (var voo in VooSelecionado)
            {
                do
                {
                    Console.WriteLine("------- Companhia Aérea Cotocos -------");
                    Console.WriteLine("------------------------------------- " + voo.descricao);
                    Console.WriteLine("[ 1 ] Lista de Passageiros");
                    Console.WriteLine("[ 2 ] Pesquisar");
                    Console.WriteLine("[ 3 ] Cadastrar Passageiro");
                    Console.WriteLine("[ 4 ] Excluir Passageiro da Lista");
                    Console.WriteLine("[ 5 ] Mostrar Fila de Espera");
                    Console.WriteLine("[ ESC ] Sair do programa");
                    Console.WriteLine("-------------------------------------");
                    Console.Write("Digite uma opção: ");

                    opcao = Int32.Parse(Console.ReadLine());

                    switch (opcao)
                    {
                        case 1:
                            voo.listarPassageiros();
                            break;
                        case 2:
                            Console.WriteLine("Informe o CPF: ");
                            cpf = Console.ReadLine();
                            cliente = voo.pesquisarPassageiro(cpf);
                            if (!String.IsNullOrEmpty(cliente.cpf))
                            {
                                Console.WriteLine("Nome: "+cliente.nome+"Sobrenome: "+cliente.sobrenome+"endereço: "+cliente.endereco+"Telefone: "+cliente.telefone+ "CPF: "+cliente.cpf);
                            } else
                            {
                                Console.WriteLine("Passageiro não encontrado.");
                            }
                            break;
                        case 3:
                            Passageiro passageiro = new Passageiro();

                            Console.WriteLine("Nome: ");
                            passageiro.nome = Console.ReadLine();
                            Console.WriteLine("Sobrenome: ");
                            passageiro.sobrenome = Console.ReadLine();;
                            Console.WriteLine("Endereço: ");
                            passageiro.endereco = Console.ReadLine(); ;
                            Console.WriteLine("Telefone: ");
                            passageiro.telefone = Console.ReadLine(); ;
                            Console.WriteLine("Cpf: ");
                            passageiro.cpf = Console.ReadLine(); ;
                            

                            voo.adicionarPassageiro(passageiro);
                            break;
                        case 4:
                            Console.WriteLine("Informe o CPF: ");
                            cpf = Console.ReadLine();
                            cliente = voo.pesquisarPassageiro(cpf);
                            voo.removerPassageiro(cliente);
                            break;
                        case 5:
                            voo.listarPassageiroAguardando();
                            break;
                        case 27:

                            opcao = 0;
                            break;
                        default:
                            //
                            break;
                    }
                    Console.ReadKey();
                    Console.Clear();
                }
                while (opcao != 0);
            }


            Console.ReadKey();
        }
    }
}
