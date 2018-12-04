using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Trabalho2.Models
{
    class Voo
    {
        public int codigo { get; set; }
        public string descricao { get; set; }
        public string horario { get; set; }
        public int limite { get; set; }
        public List<Passageiro> passageiros { get; set; }

        public Voo(int codigo, string descricao, string horario, int limite)
        {
            this.codigo = codigo;
            this.descricao = descricao;
            this.horario = horario;
            this.limite = limite;
            this.passageiros = new List<Passageiro>();
        }

        public void listarPassageiros()
        {
            int status = 1;
            if (contemPassageiros(status))
            {
                int contador = 0;
                Console.WriteLine("\n------------------------------------- ");
                Console.WriteLine("--LISTA DE PASSAGEIROS CONFIRMADOS -- ");
                Console.WriteLine("------------------------------------- ");
                foreach (var passageiro in this.passageiros)
                {
                    // Se o passageiro está confirmado.
                    if (passageiro.status == 1)
                    {
                        Console.WriteLine("Codigo: "+contador+" | Nome: "+passageiro.nome + " Sobrenome: " + passageiro.sobrenome+ " Endereço: "+ passageiro.endereco+ " Telefone: "+ passageiro.telefone+ " Cpf :"+ passageiro.cpf);
                        contador++;
                    }
                }
                Console.WriteLine("------------------------------------- ");
                Console.WriteLine("Pressione <ESC> para retornar ao menu.");
            } else
            {
                Console.WriteLine("\nLista encontra-se vazia!");
            }
        }
        public void listarPassageiroAguardando()
        {
            int status = 0;
            if (contemPassageiros(status))
            {
                Console.WriteLine("------------------------------------- ");
                foreach (var passageiro in this.passageiros)
                {
                    // Se o passageiro está aguardando na lista de espera.
                    if (passageiro.status == 0)
                    {
                        Console.WriteLine(passageiro.nome + " " + passageiro.sobrenome);
                    }
                }
                Console.WriteLine("------------------------------------- ");
            }
            else
            {
                Console.WriteLine("\nLista encontra-se vazia!");
            }
        }

        private bool contemPassageiros(int status)
        {
            var filtrados = this.passageiros.Where((Passageiro p) => { return p.status == status; });
            if (filtrados.Count() > 0)
            {
                return true;
            }
            return false;

        }

        public bool adicionarPassageiro(Passageiro passageiro)
        {
            int sizeOfList = this.passageiros.Count();

            if (passageiro.nome != "" && passageiro.status >= 0)
            {
                // Se existe vagas no voo, então adicionar como confirmado, senão como aguardando vagas.
                if (sizeOfList < this.limite)
                {
                    passageiro.status = 1;
                    this.passageiros.Add(passageiro);
                    return true;
                } else
                {
                    passageiro.status = 0;
                    this.passageiros.Add(passageiro);
                    return true;
                }
            }
            return false;
        }
        public Passageiro pesquisarPassageiro(string cpf)
        {
            var filtrado = this.passageiros.Where((Passageiro p) => { return p.cpf == cpf; });
            if (filtrado.Count() > 0)
            {
                foreach (var passageiro in filtrado)
                {
                    return passageiro;
                }
            }
            return new Passageiro();
        }
        public void removerPassageiro(Passageiro passageiro)
        {
            this.passageiros.Remove(passageiro);
            foreach (var cliente in this.passageiros)
            {
                if (cliente.status == 0)
                {
                    cliente.status = 1;
                    Console.WriteLine("O Passageiro "+cliente.nome+" foi adicionado para status de confirmado.");
                    break;
                }
            }
            Console.WriteLine("Deletado com sucesso.");
        }

    }
}
